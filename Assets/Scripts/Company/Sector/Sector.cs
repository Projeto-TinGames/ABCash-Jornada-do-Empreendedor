using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector {
    private int productionTime;

    private Market market;
    private Product product;
    private List<Alien> aliens = new List<Alien>();

    public Sector(Market market, Product product) {
        this.market = market;
        this.product = product;
    }

    public Sector(SectorData sectorData) {
        this.productionTime = sectorData.productionTime;
        this.market = new Market(sectorData.market);
        this.product = ProductManager.GetProduct(sectorData.productId);

        AlienGenerator alienGenerator = new AlienGenerator();
        foreach (AlienData alienData in sectorData.aliens) {
            Alien alien = alienGenerator.LoadAlien(alienData);
            aliens.Add(alien);
        }
    }

    public void Produce() {
        foreach (Alien alien in aliens) {
            productionTime += 10;
        }
        if (productionTime >= product.GetProductionTime()) {
            float money = product.GetPrice() * market.GetPercentages(product.GetId());
            Company.AddMoney(money);
            
            productionTime = 0;
        }

        TimeData timeData = new TimeData((product.GetProductionTime() - productionTime)/10);
        Debug.Log($"{timeData.GetDays()}, {timeData.GetHours()}, {timeData.GetMinutes()}, {timeData.GetSeconds()}");
    }

    #region Add

        public void AddProductionTime(int value) {
            productionTime += value;
        }

        public void AddAlien(Alien alien) {
            aliens.Add(alien);
        }

    #endregion

    #region Remove

        public void RemoveProductionTime(int value) {
            productionTime -= value;
        }

        public void RemoveAlien(Alien alien) {
            aliens.Remove(alien);
        }

        public void RemoveAlien(int index) {
            aliens.RemoveAt(index);
        }

    #endregion

    #region Getters

        public int GetProductionTime() {
            return productionTime;
        }

        public Market GetMarket() {
            return market;
        }

        public Product GetProduct() {
            return product;
        }

        public List<Alien> GetAliens() {
            return aliens;
        }

        public Alien GetAliens(int index) {
            return aliens[index];
        }

    #endregion

    #region Setters

        public void SetProductionTime(int value) {
            productionTime = value;
        }

        public void SetMarket(Market value) {
            market = value;
        }

        public void SetProduct(Product value) {
            product = value;
        }

        public void SetAliens(List<Alien> value) {
            aliens = value;
        }

        public void SetAliens(int index, Alien value) {
            aliens[index] = value;
        }

    #endregion


}
