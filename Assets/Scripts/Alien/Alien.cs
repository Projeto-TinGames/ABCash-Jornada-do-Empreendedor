using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Alien {
    //Species values
    private int speciesId = 0;
    protected string[] availableNames;
    protected int agilityMultiplier = 1;
    protected int wisdomMultiplier = 1;

    //Stats
    private string name;
    private string species;
    private Sprite sprite;
    private Color color;
    private string planet;
    private string sector;
    private int age;
    private int rank;
    private int status = 100;
    private int agility;
    private int wisdom;
    private float salary;

    public abstract void Work();

    #region Generate

        protected void GenerateStats() {
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
            name = availableNames[Random.Range(0,availableNames.Length)];
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
            wisdom = Random.Range(1,25)*rank*wisdomMultiplier + (age/25);
        }

        private void GenerateSalary() { //Precisa criar lógica para levar em conta a distância do planeta em que mora
            salary = (agility+wisdom)*100;
        }

    #endregion

    #region Getters

        public int GetSpeciesId() {
            return speciesId;
        }

        protected string[] GetAvailableNames() {
            return availableNames;
        }

        protected int GetAgilityMultiplier() {
            return agilityMultiplier;
        }

        protected int GetWisdomMultiplier() {
            return wisdomMultiplier;
        }

        public string GetName() {
            return name;
        }

        public string GetSpecies() {
            return species;
        }

        public Sprite GetSprite() {
            return sprite;
        }

        public Color GetColor() {
            return color;
        }

        public string GetPlanet() {
            return planet;
        }

        public string GetSector() {
            return sector;
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

    #region Setters

        public void LoadStats(AlienData alienData) {
            name = alienData.GetName();
            sprite = Resources.Load<Sprite>($"Sprites/Aliens/{species}");
            color = new Color(alienData.GetColor(0), alienData.GetColor(1), alienData.GetColor(2));
            planet = alienData.GetPlanet();
            sector = alienData.GetSector();
            age = alienData.GetAge();
            rank = alienData.GetRank();
            status = alienData.GetStatus();
            agility = alienData.GetAgility();
            wisdom = alienData.GetWisdom();
            salary = alienData.GetSalary();
        }

        protected void SetSpeciesId(int value) {
            speciesId = value;
        }

        protected void SetAvailableNames(string[] value) {
            availableNames = value;
        }

        protected void SetAgilityMultiplier(int value) {
            agilityMultiplier = value;
        }

        protected void SetWisdomMultiplier(int value) {
            wisdom = value;
        }

        public void SetName(string value) {
            name = value;
        }

        public void SetSpecies(string value) {
            species = value;
        }

        public void SetSprite(Sprite value) {
            sprite = value;
        }

        public void SetColor(Color value) {
            color = value;
        }

        public void SetPlanet(string value) {
            planet = value;
        }

        public void SetSector(string value) {
            sector = value;
        }

        public void SetAge(int value) {
            age = value;
        }

        public void SetRank(int value) {
            rank = value;
        }

        public void SetStatus(int value) {
            status = value;
        }

        public void SetAgility(int value) {
            agility = value;
        }

        public void SetWisdom(int value) {
            wisdom = value;
        }

        public void SetSalary(float value) {
            salary = value;
        }

    #endregion

}