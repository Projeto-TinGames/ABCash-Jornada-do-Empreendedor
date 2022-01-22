using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AlienStats")]
public class AlienStats : ScriptableObject {

    //Race variables
    public string[] possibleNames;
    public string race;
    public int agilityModifier = 1;
    public int knowledgeModifier = 1;
    public Sprite sprite;

    //Stats strings
    [System.NonSerialized]public string name;
    [System.NonSerialized]public string planet;
    [System.NonSerialized]public string status;
    [System.NonSerialized]public string[] likes;
    [System.NonSerialized]public string[] dislikes;
    
    //Stats ints
    [System.NonSerialized]public int age;
    [System.NonSerialized]public int rank;
    [System.NonSerialized]public int exigence;
    [System.NonSerialized]public int agility;
    [System.NonSerialized]public int knowledge;

    public void Randomize() {
        GenerateName();
        GeneratePlanet();
        GenerateLikes();
        GenerateDislikes();
        GenerateAge();
        GenerateRank();
        GenerateExigence();
        GenerateAgility();
        GenerateKnowledge();
    }

    private void GenerateName() {
        name = possibleNames[Random.Range(0,possibleNames.Length)];
    }

    private void GeneratePlanet() {
        string[] possiblePlanets = new string[]{"Sinertag","Lemeb Vono", "Amenaip"};
        planet = possiblePlanets[Random.Range(0,possibleNames.Length)];
    }

    private void GenerateLikes() {
        likes = new string[]{"TestLikes"};
    }

    private void GenerateDislikes() {
        dislikes = new string[]{"TestDislikes"};
    }

    private void GenerateAge() {
        age = Random.Range(18,100);
    }

    private void GenerateRank() {
        rank = Random.Range(1,4);
    }

    private void GenerateExigence() {
        exigence = Random.Range(1,25*rank);
    }

    private void GenerateAgility() {
        agility = Random.Range(1,25*rank)*agilityModifier - (age/25);
    }

    private void GenerateKnowledge() {
        knowledge = Random.Range(1,25*rank)*knowledgeModifier + (age/25);
    }

}
