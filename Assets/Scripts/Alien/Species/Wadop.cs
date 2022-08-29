using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wadop : Alien {
    
    public Wadop() {
        namesArray = new string[]{"Wadopo", "Wadopa", "Wadopio"};
        agilityMultiplier = 2;
    }

    public override void Work() {
        Debug.Log("Wadop");
    }
}
