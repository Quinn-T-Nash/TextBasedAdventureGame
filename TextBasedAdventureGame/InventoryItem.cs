using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    internal class InventoryItem : GameObject, IPortable
    {
        public int Size { get; set; }

        public InventoryItem(string description) : this(description, 1)
        {
            
        }

        public InventoryItem(string description, int size) 
        {
            Size = size;
            Description = description;
        }
    }
}
