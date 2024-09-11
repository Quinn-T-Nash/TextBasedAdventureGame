// TravelWindow
// Programer: Rob Garner (rgarner7@cnm.edu)     Editted by Quinn Nash
// Date: 25 May 2016
// User interface that provides user capability to travel
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Window that shows player where they are and provides capability to move from location to location in the map.
    /// </summary>
    public partial class TravelWindow : Window
    {
        /// <summary>
        /// Game object that has map
        /// </summary>
        Map game;

        Player player; //Quinn Nash

        List<String> gameActions; // For recording game actions

        /// <summary>
        /// Initialize the form, the game and call display location to start the form.
        /// </summary>
        public TravelWindow()
        {
            InitializeComponent();
            game = new Map();

            player = new Player(game.Locations[0]);

            gameActions = new List<String>();

            DisplayLocation();
        }

        /// <summary>
        /// Tells the player where they are.
        /// </summary>
        private void DisplayLocation()
        {
            lbError.Content = "";

            txbLocationDescription.Text = game.PlayerLocation.Description;
            lbTraveOptions.ItemsSource = game.PlayerLocation.TravelOptions;
            lbInventory.ItemsSource = player.Inventory;
            lbSearch.ItemsSource = game.PlayerLocation.Items;
        }

        /// <summary>
        /// Double click a travel option to move to a new location on the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTraveOptions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TravelOption to = (TravelOption)lbTraveOptions.SelectedItem;
            game.PlayerLocation = to.Location;

            gameActions.Add($"Location Changed: {game.PlayerLocation}");
            lbGameStatus.ItemsSource = gameActions;
            lbGameStatus.Items.Refresh();
            DisplayLocation();
        }


        //Quinn Nash Searches items and determines if it can or cannot be taken depending on if it is
        //searchable
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int index = lbSearch.SelectedIndex;

            //If -1 then they search inventory box instead of search box
            if (index != -1)
            {
                GameObject searched = game.PlayerLocation.Items[index];
                GameObject found = new GameObject();
                HidingPlace hidingPlace;
                PortableHidingPlace portableHidingPlace;
                SearchResults form;

                if (searched is HidingPlace)
                {
                    hidingPlace = (HidingPlace)searched;
                    found = hidingPlace.Search();

                    //show pop up form
                    if (found != null)
                    {
                        form = new SearchResults(found);
                        form.ShowDialog();
                    }
                    else
                    {
                        form = new SearchResults();
                        form.ShowDialog();
                    }
                    gameActions.Add($"Item Searched {found.Description}");
                }
                else if (searched is PortableHidingPlace)
                {
                    portableHidingPlace = (PortableHidingPlace)searched;
                    found = portableHidingPlace.Search();

                    //show pop up form
                    if (found != null)
                    {
                        gameActions.Add($"Item Searched {found.Description}");
                        form = new SearchResults(found);
                        form.ShowDialog();
                    }
                    else
                    {
                        form = new SearchResults();
                        form.ShowDialog();
                    }

                }
                else
                {
                    gameActions.Add($"Item Searched, nothing found");
                    form = new SearchResults();
                    form.ShowDialog();
                }

                if (form.DialogResult == true)
                {
                    //add item to inventory
                    if (found is InventoryItem)
                    {
                        InventoryItem item = (InventoryItem)found;
                        player.Inventory.Add(item);
                        gameActions.Add($"Item Taken {found.Description}");
                    }
                    else if (found is PortableHidingPlace)
                    {
                        PortableHidingPlace item = (PortableHidingPlace)found;
                        player.Inventory.Add(item);
                        gameActions.Add($"Item Taken {found.Description}");
                    }
                    lbInventory.ItemsSource = player.Inventory;
                    lbInventory.Items.Refresh();
                }
                else
                {
                    //put back the object if you decide to leave it
                    if (found != null)
                    {
                        if (searched is HidingPlace)
                        {
                            hidingPlace = (HidingPlace)searched;
                            hidingPlace.HiddenObject = found;
                        }
                    }
                }

                lbGameStatus.ItemsSource = gameActions;
                lbGameStatus.Items.Refresh();

                lbError.Content = "";

            }
            else
            {
                index = lbInventory.SelectedIndex;

                if (index != -1)
                {
                    IPortable searched = player.Inventory[index];

                    SearchResults form;

                    if (searched is PortableHidingPlace)
                    {
                        PortableHidingPlace pack = (PortableHidingPlace)searched;

                        GameObject found = pack.Search();

                        if (found != null)
                        {
                            form = new SearchResults(found);
                            form.ShowDialog();
                        }
                        else
                        {
                            form = new SearchResults();
                            form.ShowDialog();
                        }

                        gameActions.Add($"Inventory Searched {pack.Description}");

                        if (form.DialogResult == true)
                        {
                            //add item to inventory
                            if (found is InventoryItem)
                            {
                                InventoryItem item = (InventoryItem)found;
                                player.Inventory.Add(item);

                                gameActions.Add($"Item Taken {found.Description}");
                            }
                            lbInventory.ItemsSource = player.Inventory;
                            lbInventory.Items.Refresh();
                        }
                        else
                        {
                            //put object back
                            if (found != null)
                            {
                                pack.HiddenObject = found;
                                gameActions.Add($"Item Returned {found.Description}");
                            }
                        }

                        lbGameStatus.ItemsSource = gameActions;
                        lbGameStatus.Items.Refresh();

                    }

                    lbError.Content = "";

                }
                else
                {
                    lbError.Content = "Select a valid item to search";
                }
            }

        }


        //Take item form location if it is portable
        private void btnTake_Click(object sender, RoutedEventArgs e)
        {
            int index = lbSearch.SelectedIndex;

            if (index != -1)
            {
                GameObject itemToTaken = game.PlayerLocation.Items[index];
                if (game.PlayerLocation.Items[index] is IPortable)
                {
                    IPortable item = (IPortable)game.PlayerLocation.Items[index];
                    //If returns true means there is space to add this item
                    if (player.AddInventoryItem(item))
                    {
                        lbInventory.ItemsSource = player.Inventory;
                        lbInventory.Items.Refresh();

                        //remove the item form the location
                        game.PlayerLocation.Items.Remove(game.PlayerLocation.Items[index]);
                        lbSearch.ItemsSource = game.PlayerLocation.Items;
                        lbSearch.Items.Refresh();

                        gameActions.Add($"Item Taken {itemToTaken.Description}");
                    }
                }
                else
                {
                    NoSpaceForm form = new NoSpaceForm();
                    form.ShowDialog();
                }

                lbGameStatus.ItemsSource = gameActions;
                lbGameStatus.Items.Refresh();

                lbError.Content = "";

            }
            else
            {
                lbError.Content = "Select an item if you want to take something";
            }
        }


        //remove the item and add it the the playerlocation as a inventory object
        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            int index = lbInventory.SelectedIndex;

            if (index != -1)
            {
                IPortable item = player.Inventory[index];

                player.Inventory.RemoveAt(index);

                if (item is InventoryItem)
                {
                    InventoryItem dropped = (InventoryItem)item;
                    game.PlayerLocation.Items.Add(dropped);

                    gameActions.Add($"Item dropped {dropped.Description}");
                }
                else
                {
                    PortableHidingPlace dropped = (PortableHidingPlace)item;
                    game.PlayerLocation.Items.Add(dropped);

                    gameActions.Add($"Item dropped {dropped.Description}");
                }



                lbInventory.ItemsSource = player.Inventory;
                lbInventory.Items.Refresh();
                lbSearch.ItemsSource = game.PlayerLocation.Items;
                lbSearch.Items.Refresh();
                lbGameStatus.ItemsSource = gameActions;
                lbGameStatus.Items.Refresh();

                lbError.Content = "";

            }
            else
            {
                lbError.Content = "Select an item in inventory to drop";
            }

        }
    }
}
