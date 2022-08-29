using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Alien {
    //Species Variables
    public string[] namesArray;
    public int agilityMultiplier = 1;
    public int knowledgeMultiplier = 1;

    //Alien Stats
    public int id;
    public string name;
    public string species;
    public Sprite sprite;
    public Color color;
    public string planet;
    public string sector;
    public int age;
    public int rank;
    public int status = 100;
    public int agility;
    public int knowledge;
    public float salary;

    public abstract void Work();

    public void SetStats(Alien alien) {
        name = alien.name;
        species = alien.species;
        sprite = Resources.Load<Sprite>($"Sprites/Aliens/{species}");
        color = alien.color;
        planet = alien.planet;
        sector = alien.sector;
        age = alien.age;
        rank = alien.rank;
        status = alien.status;
        agility = alien.agility;
        knowledge = alien.knowledge;
        salary = alien.salary;
    }

    public void GenerateStats() {
        species = this.GetType().ToString();
        sprite = Resources.Load<Sprite>($"Sprites/Aliens/{species}");

        GenerateName();
        GenerateColor();
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

    private void GenerateColor() {
        color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1F));
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
