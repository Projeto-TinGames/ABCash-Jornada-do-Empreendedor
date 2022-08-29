using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodal : Alien {
    
    public Dodal() {
        namesArray = new string[]{"Dodala", "Dodalo", "Dodalio"};
        knowledgeMultiplier = 2;
    }

    public override void Work() {
        Debug.Log("Dodal");
    }
}
