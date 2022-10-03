using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repinch : Alien {
    
    public Repinch() {
        speciesId = 1;
        namesArray = new string[]{"Repincha", "Repincho", "Repinchio"};
        species = "Repinch";
    }

    public override void Work() {
        Debug.Log("Repinch");
    }
}
