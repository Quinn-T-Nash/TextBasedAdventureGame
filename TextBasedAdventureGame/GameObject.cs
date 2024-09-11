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
    public class GameObject
    {
        //properties
        public virtual string Description {  get; set; }

        //Constructors
        /// <summary>
        /// Parameterless constructor dfaults to Unknow object
        /// </summary>
        public GameObject() : this("Unknown Object")
        {

        }
        
        /// <summary>
        /// One parameter constructor
        /// </summary>
        /// <param name="description"></param>
        public GameObject(string description)
        {
            Description = description;
        }

        //Methods
        public override string ToString()
        {

            return Description;
        }
    }
}
