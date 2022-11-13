using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SectorData {
    [SerializeField]public int productId;
    [SerializeField]public int productionTime;

    [SerializeField]public MarketData market;
    [SerializeField]public List<AlienData> aliens = new List<AlienData>();

    public SectorData(Sector sector) {
        this.productionTime = sector.GetProductionTime();
        this.productId = sector.GetProduct().GetId();
        this.market = new MarketData(sector.GetMarket());
        
        foreach (Alien alien in sector.GetAliens()) {
            this.aliens.Add(new AlienData(alien));
        }
    }

    #region Getters

        public int GetProductionTime() {
            return productionTime;
        }

        public MarketData GetMarket() {
            return market;
        }

        public int GetProduct() {
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

        public void SetMarket(MarketData value) {
            market = value;
        }

        public void SetProduct(int value) {
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