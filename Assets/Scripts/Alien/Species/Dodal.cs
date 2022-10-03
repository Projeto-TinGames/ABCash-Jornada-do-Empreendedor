using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodal : Alien {
    public Dodal() {
        speciesId = 0;
        
        namesArray = new string[]{"Dodala", "Dodalo", "Dodalio"};
        knowledgeMultiplier = 2;
        species = "Dodal";
    }

    public override void Work() {
        Debug.Log("Dodal");
    }
}
