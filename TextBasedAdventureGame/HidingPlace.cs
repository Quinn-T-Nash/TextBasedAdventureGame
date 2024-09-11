
//Quinn Nash
//qnash@cnm.edu
//NashP7

using System;
//Quinn Nash
//qnash@cnm.edu
//Nash P7

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    public class HidingPlace : GameObject, IHidingPlace
    {
        //Field
        private GameObject hiddenObject;

        //Property
        public GameObject HiddenObject
        {
            get { return hiddenObject; }
            set { hiddenObject = value; }
        }

        //Constructors
        public HidingPlace(string description) : base(description)
        {
            
        }

        public HidingPlace(string description, GameObject hiddenObject)
        {
            Description = description; //from GameObject the base class

        }


        //Method
        public GameObject Search()
        {
            GameObject foundObject = HiddenObject;

            HiddenObject = null;

            return foundObject;
        }

    }
}
