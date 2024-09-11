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
    internal interface IHidingPlace
    {
        GameObject Search();

        GameObject HiddenObject { get; set; }
    
    }
}
