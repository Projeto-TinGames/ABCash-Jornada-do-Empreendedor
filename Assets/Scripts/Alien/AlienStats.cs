using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AlienStats")]
public class AlienStats : ScriptableObject {

    //Race variables
    [SerializeField]private string[] possibleNames;
    public string race;

    [SerializeField]private int agilityModifier = 1;
    [SerializeField]private int knowledgeModifier = 1;
    
    public Sprite sprite;

    //Stats strings
    [System.NonSerialized]public new string name;
    [System.NonSerialized]public string planet;
    [System.NonSerialized]public string sector;
    
    //Stats ints
    [System.NonSerialized]public int age;
    [System.NonSerialized]public int rank;
    [System.NonSerialized]public int status = 100;
    [System.NonSerialized]public int agility;
    [System.NonSerialized]public int knowledge;
    [System.NonSerialized]public int salary;

    public void Randomize() {
        GenerateName();
        GeneratePlanet();
        GenerateSector();
        GenerateAge();
        GenerateRank();
        GenerateAgility();
        GenerateKnowledge();
        GenerateSalary();
    }

    private void GenerateName() {
        name = possibleNames[Random.Range(0,possibleNames.Length)];
    }

    private void GeneratePlanet() {
        string[] possiblePlanets = new string[]{"Sinertag","Lemeb Vono", "Amenaip"};
        planet = possiblePlanets[Random.Range(0,possibleNames.Length)];
    }

    private void GenerateSector() {
        sector = "Test";
    }

    private void GenerateAge() {
        age = Random.Range(18,100);
    }

    private void GenerateRank() {
        int randomInt = Random.Range(1,100);
        if (randomInt <= 50) {
            rank = 1;
        }
        else if (randomInt <= 80) {
            rank = 2;
        }
        else if (randomInt <= 95) {
            rank = 3;
        }
        else {
            rank = 4;
        }
    }

    private void GenerateAgility() {
        agility = Random.Range(1,25)*rank*agilityModifier - (age/25);
    }

    private void GenerateKnowledge() {
        knowledge = Random.Range(1,25)*rank*knowledgeModifier + (age/25);
    }

    private void GenerateSalary() { //Precisa criar lógica para levar em conta a distância do planeta em que mora
        salary = (agility+knowledge)*100;
    }

}
