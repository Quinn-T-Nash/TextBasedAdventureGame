using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Interaction logic for SearchResults.xaml
    /// </summary>
    public partial class SearchResults : Window
    {
        GameObject foundItem;
        public SearchResults()
        {
            InitializeComponent();
            lblFound.Content = "Nothing Here";
            btnTake.Visibility = Visibility.Hidden;
        }

        //Show hidden item
        public SearchResults(GameObject found)
        {
            InitializeComponent();
            foundItem = found;
            lblFound.Content = found.Description;

            btnTake.Visibility = Visibility.Visible;
        }

        private void btnTake_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
