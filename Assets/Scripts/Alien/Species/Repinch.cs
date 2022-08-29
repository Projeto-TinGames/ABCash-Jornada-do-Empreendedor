using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repinch : Alien {
    
    public Repinch() {
        namesArray = new string[]{"Repincha", "Repincho", "Repinchio"};
    }

    public override void Work() {
        Debug.Log("Repinch");
    }
}
