//Quinn Nash
//qnash@cnm.edu
//NashP7

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    internal class PortableHidingPlace : GameObject, IHidingPlace, IPortable
    {
        //fields
        private GameObject item;


        //Properties
        public GameObject HiddenObject
        {
            get { return item; }
            set { item = value; }
        }

        public int Size { get; set; }


        //constructors
        public PortableHidingPlace(string description, int size) : this(description, size, null)
        {

        }


        public PortableHidingPlace(string desription, int size, GameObject item)
        {
            Description = desription;
            Size = size;
            HiddenObject = item;
        }


        //Method
        public GameObject Search()
        {
            GameObject foundObject = item;

            item = null;

            return foundObject;
        }

    }
}
