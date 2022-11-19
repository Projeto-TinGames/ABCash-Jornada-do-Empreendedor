using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SectorData {
    [SerializeField]private int productId;
    [SerializeField]private int galaxyId;
    [SerializeField]private int productionTime;

    [SerializeField]private List<AlienData> aliens = new List<AlienData>();

    public SectorData(Sector sector) {
        this.productionTime = sector.GetProductionTimeCounter();
        this.productId = sector.GetProduct().GetId();
        this.galaxyId = sector.GetGalaxy().GetId();
        
        foreach (Alien alien in sector.GetAliens()) {
            this.aliens.Add(new AlienData(alien));
        }
    }

    #region Getters

        public int GetProductionTime() {
            return productionTime;
        }

        public int GetGalaxyId() {
            return galaxyId;
        }

        public int GetProductId() {
            return productId;
        }

        public List<AlienData> GetAliens() {
            return aliens;
        }

        public AlienData GetAliens(int index) {
            return aliens[index];
        }

    #endregion

    #region Setters

        public void SetProductionTime(int value) {
            productionTime = value;
        }

        public void SetGalaxyId(int value) {
            galaxyId = value;
        }

        public void SetProductId(int value) {
            productId = value;
        }

        public void SetAliens(List<AlienData> value) {
            aliens = value;
        }

        public void SetAliens(int index, AlienData value) {
            aliens[index] = value;
        }

    #endregion
}