using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wadop : Alien {
    
    public Wadop() {
        speciesId = 2;
        
        namesArray = new string[]{"Wadopo", "Wadopa", "Wadopio"};
        agilityMultiplier = 2;
        species = "Wadop";
    }

    public override void Work() {
        Debug.Log("Wadop");
    }
}
