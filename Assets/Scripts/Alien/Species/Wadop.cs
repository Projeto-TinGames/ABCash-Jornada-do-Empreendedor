using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wadop : Alien {
    
    public Wadop() {
        SetSpeciesId(2);
        
        SetAvailableNames(new string[]{"Stanley", "Angela", "Oscar"});
        SetAgilityMultiplier(2);
        SetSpecies("Wadop");

        GenerateStats();
    }

    public override void Work() {
        Debug.Log("Wadop");
    }
}
