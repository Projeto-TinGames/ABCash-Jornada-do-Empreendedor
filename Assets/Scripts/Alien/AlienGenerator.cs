using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGenerator {
    private Alien[] species = new Alien[] {
        new Dodal(),
        new Repinch(),
        new Wadop()
    };

    public Alien GetRandomAlien() {
        int randomIndex = Random.Range(0, species.Length);
        return species[randomIndex];
    }

    public Alien LoadAlien(AlienData alienData) {
        Alien alien = species[alienData.speciesId];
        alien.SetStats(alienData);
        return alien;
    }
}
