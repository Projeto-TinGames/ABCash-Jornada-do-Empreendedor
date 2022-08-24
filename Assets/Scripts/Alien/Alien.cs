using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    public AlienStats stats;

    [SerializeField]private Sprite sprite;
    [SerializeField]private string[] namesArray;
    [SerializeField]private int agilityMultiplier = 1;
    [SerializeField]private int knowledgeMultiplier = 1;

    public void GenerateStats() {
        stats = new AlienStats(sprite, namesArray, GetType().ToString(), agilityMultiplier, knowledgeMultiplier);
    }

    //Implementar lógicas de trabalho do alien

}
