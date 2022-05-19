using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats {
    //Race variables
    private string[] namesArray;
    private int agilityMultiplier = 1;
    private int knowledgeMultiplier = 1;

    //Alien stats
    public Sprite sprite;
    public string name;
    public string race;
    public string planet;
    public string sector;
    public int age;
    public int rank;
    public int status = 100;
    public int agility;
    public int knowledge;
    public int salary;

    public AlienStats(Sprite sprite, string[] namesArray, string race, int agilityMultiplier, int knowledgeMultiplier) {
        this.sprite = sprite;
        this.namesArray = namesArray;
        this.race = race;
        this.agilityMultiplier = agilityMultiplier;
        this.knowledgeMultiplier = knowledgeMultiplier;

        Randomize();
    }

    private void Randomize() {
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
        name = namesArray[Random.Range(0,namesArray.Length)];
    }

    private void GeneratePlanet() {
        string[] planets = new string[]{"Sinertag","Lemeb Vono", "Amenaip"};
        planet = planets[Random.Range(0,planets.Length)];
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
        agility = Random.Range(1,25)*rank*agilityMultiplier - (age/25);
    }

    private void GenerateKnowledge() {
        knowledge = Random.Range(1,25)*rank*knowledgeMultiplier + (age/25);
    }

    private void GenerateSalary() { //Precisa criar lógica para levar em conta a distância do planeta em que mora
        salary = (agility+knowledge)*100;
    }

}
