using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AlienData {
    public int speciesId;
    public string name;
    public float[] color;
    public string planet;
    public string sector;
    public int age;
    public int rank;
    public int status = 100;
    public int agility;
    public int knowledge;
    public float salary;
    
    public AlienData(Alien alien) {
        this.speciesId = alien.speciesId;
        this.name = alien.name;
        this.color = new float[]{alien.color.r, alien.color.g, alien.color.b};
        this.planet = alien.planet;
        this.sector = alien.sector;
        this.age = alien.age;
        this.rank = alien.rank;
        this.status = alien.status;
        this.agility = alien.agility;
        this.knowledge = alien.knowledge;
        this.salary = alien.salary;
    }
}