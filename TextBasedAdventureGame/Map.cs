// TravelOption
// Programer: Rob Garner (rgarner7@cnm.edu)  Edited by Quinn Nash
// Date: 25 May 2016
// Represents a travel option.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Class that represents the game. 
    /// Has a map and location of player.
    /// </summary>
    class Map
    {
        /// <summary>
        /// List of map locations.
        /// </summary>
        public List<MapLocation> Locations { get; set; }

        /// <summary>
        /// Player's location.
        /// </summary>
        public MapLocation PlayerLocation { get; set; }

        /// <summary>
        /// Constructor that creates the game map.
        /// </summary>
        public Map()
        {
            //Create map locations first
            Locations = new List<MapLocation>();           
            Locations.Add(new MapLocation("You are on a road leading to a town."));
            Locations.Add(new MapLocation("You are on a road in front of a saloon."));
            Locations.Add(new MapLocation("You are in a saloon."));
            Locations.Add(new MapLocation("You are on a road in front of a jail."));
            Locations.Add(new MapLocation("You are in a jail."));
            Locations.Add(new MapLocation("You are on a road in front of a general store."));
            Locations.Add(new MapLocation("You are in a general store."));

            //Now add travel options to each map location

            //Road outside town
            Locations[0].TravelOptions.Add(new TravelOption("A town is to the west of you.",Locations[1]));

            //Road in front of salloon
            Locations[1].TravelOptions.Add(new TravelOption("The road out of town is to the east of you.", Locations[0]));            
            Locations[1].TravelOptions.Add(new TravelOption("A salloon is to the north of you.", Locations[2]));            
            Locations[1].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[3]));

            //Salloon
            Locations[2].TravelOptions.Add(new TravelOption("The saloon door leads out to the street.", Locations[1]));

            //Road in front of jail
            Locations[3].TravelOptions.Add(new TravelOption("A road is to the east of you.", Locations[1]));
            Locations[3].TravelOptions.Add(new TravelOption("A jail is to the north of you.", Locations[4]));
            Locations[3].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[5]));

            //Jail
            Locations[4].TravelOptions.Add(new TravelOption("The jail door leads out to the street.", Locations[3]));

            //Road in front of general store
            Locations[5].TravelOptions.Add(new TravelOption("A road is to the east of you.", Locations[3]));
            Locations[5].TravelOptions.Add(new TravelOption("A general store is to the north of you.", Locations[6]));

            //Jail
            Locations[6].TravelOptions.Add(new TravelOption("The store door leads out to the street.", Locations[5]));

            //Set the player's starting location.
            PlayerLocation = Locations[0];


            //Quinn Nash
            //Add some items. 
            Locations[0].Items.Add(new InventoryItem("Broken Rifle", 3));

            HidingPlace rock = new HidingPlace("Large Rock");
            rock.HiddenObject = new InventoryItem("Snow Globe");
            Locations[1].Items.Add(rock);

            Locations[2].Items.Add(new PortableHidingPlace("Backpack", 1, new InventoryItem("Peanut butter and jelly sandwich")));

            Locations[3].Items.Add(new HidingPlace("Car"));

            HidingPlace rubble = new HidingPlace("Rubble");
            rubble.HiddenObject = new InventoryItem("Gold Locket");

            Locations[3].Items.Add(rubble);

            Locations[4].Items.Add(new InventoryItem("Hammer", 2));
            Locations[4].Items.Add(new PortableHidingPlace("Briefcase", 1, new InventoryItem("Letters to Paul")));

            Locations[5].Items.Add(new InventoryItem("Pendant"));

            Locations[6].Items.Add(new InventoryItem("Knife"));
            HidingPlace shelf = new HidingPlace("Shelf");
            shelf.HiddenObject = new InventoryItem("Paul's Address");

            Locations[6].Items.Add(shelf);



        }

    }
}
