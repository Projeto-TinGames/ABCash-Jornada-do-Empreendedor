using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repinch : Alien {
    
    public Repinch() {
        SetSpeciesId(1);
        SetAvailableNames(new string[]{"Pam", "Phyllis", "Dwight"});
        SetSpecies("Repinch");
        
        GenerateStats();
    }

    public override void Work() {
        Debug.Log("Repinch");
    }
}
