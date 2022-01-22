using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
    public Alien alien;
    public AlienDisplay display;
    public List<AlienStats> statsList = new List<AlienStats>();

    private void Awake() {
        GenerateRandomAlien();
    }

    public void GenerateRandomAlien() {
        alien.stats = statsList[Random.Range(0,statsList.Count)];
        alien.stats.Randomize();

        display.RefreshDisplay();
    }
}
