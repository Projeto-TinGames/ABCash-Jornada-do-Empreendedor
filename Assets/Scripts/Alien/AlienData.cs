using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AlienData {
    [SerializeField]private int speciesId;
    [SerializeField]private string name;
    [SerializeField]private float[] color;
    [SerializeField]private int galaxyId;
    [SerializeField]private int productId;
    [SerializeField]private int age;
    [SerializeField]private int rank;
    [SerializeField]private int status = 100;
    [SerializeField]private int agility;
    [SerializeField]private int wisdom;
    [SerializeField]private float salary;
    
    public AlienData(Alien alien) {
        this.speciesId = alien.GetSpeciesId();
        this.name = alien.GetName();
        this.color = new float[]{alien.GetColor().r, alien.GetColor().g, alien.GetColor().b};
        this.galaxyId = alien.GetGalaxyId();
        this.productId = alien.GetProductId();
        this.age = alien.GetAge();
        this.rank = alien.GetRank();
        this.status = alien.GetStatus();
        this.agility = alien.GetAgility();
        this.wisdom = alien.GetWisdom();
        this.salary = alien.GetSalary();
    }

    #region Getters

        public int GetSpeciesId() {
            return speciesId;
        }

        public string GetName() {
            return name;
        }

        public float[] GetColor() {
            return color;
        }

        public float GetColor(int index) {
            return color[index];
        }

        public int GetGalaxyId() {
            return galaxyId;
        }

        public int GetProductId() {
            return productId;
        }

        public int GetAge() {
            return age;
        }

        public int GetRank() {
            return rank;
        }

        public int GetStatus() {
            return status;
        }

        public int GetAgility() {
            return agility;
        }

        public int GetWisdom() {
            return wisdom;
        }

        public float GetSalary() {
            return salary;
        }

    #endregion
}