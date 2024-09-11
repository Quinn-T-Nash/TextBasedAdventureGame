//Quinn Nash
//qnash@cnm.edu
//Nash P7

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    internal class Player
    {
        //Fields
        private int inventorySize;


        //Properties
        public List<IPortable> Inventory { get; set; }

        public MapLocation Location { get; set; }

        public int MaxInventory {  get; set; }

        public Player(MapLocation location)
        {
            Location = location;
            Inventory = new List<IPortable>();
            MaxInventory = 6;

            //add starting item
            Inventory.Add(new InventoryItem("Pocket Lint"));
            Calc();
            
        }

        //Methods
        /// <summary>
        /// Adds a portable item as long as it does not exceed max inventory
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddInventoryItem(IPortable item)
        {
            bool space = false;

            if (inventorySize + item.Size <= MaxInventory)
            {
                Inventory.Add(item);
                Calc();
                space = true;
            }

            return space;
        }


        /// <summary>
        /// Determines size of players inventory
        /// </summary>
        private void Calc()
        {
            inventorySize = 0;

            foreach(IPortable item in Inventory)
            {
                inventorySize += item.Size;
            }
        }


        /// <summary>
        /// Gets rid of inventory item
        /// </summary>
        /// <param name="item"></param>
        public void RemoveInventoryItem(IPortable item)
        {
            Inventory.Remove(item);
        }
    }
}
