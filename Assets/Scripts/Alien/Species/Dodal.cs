using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodal : Alien {
    public Dodal() {
        SetSpeciesId(0);
        
        SetAvailableNames(new string[]{"Michael", "Jim", "Andy"});
        SetWisdomMultiplier(2);
        SetSpecies("Dodal");

        GenerateStats();
    }

    public override void Work() {
        Debug.Log("Dodal");
    }
}
