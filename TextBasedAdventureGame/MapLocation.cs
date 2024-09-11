// GameLocation
// Programer: Rob Garner (rgarner7@cnm.edu)
// Date: 25 May 2016
// Represents a travel option.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Represents a location on the map
    /// </summary>
    public class MapLocation
    {
        /// <summary>
        /// Description of the location that will be shown to player.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of travel options which are a link to where you can go from this location.
        /// </summary>
        public List<TravelOption> TravelOptions { get; set; }

        public List<GameObject> Items { get; set; } //Quinn Nash


        /// <summary>
        /// Single parameter constructor for game location.
        /// </summary>
        /// <param name="description">Description of the location that will be shown to player.</param>
        public MapLocation(string description)
        {
            Description = description;
            TravelOptions = new List<TravelOption>();
            Items = new List<GameObject>(); //Quinn Nash
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
