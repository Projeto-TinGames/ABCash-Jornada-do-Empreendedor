using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector {
    private Galaxy galaxy; // Galaxy that the sector sell its products to
    private Product product;
    private List<Alien> aliens = new List<Alien>();

    private int productionTimeCounter;

    public Sector(Product product, Galaxy galaxy) {
        this.product = product;
        this.galaxy = galaxy;
    }

    public Sector(SectorData sectorData) {
        this.galaxy = Universe.GetGalaxies(sectorData.GetGalaxyId());
        this.product = ProductManager.GetProducts(sectorData.GetProductId());
        this.productionTimeCounter = sectorData.GetProductionTime();

        foreach (AlienData alienData in sectorData.GetAliens()) {
            AlienGenerator alienGenerator = new AlienGenerator();
            Alien alien = alienGenerator.LoadAlien(alienData);
            aliens.Add(alien);
        }
    }

    public void Update() {
        Produce();
    }

    private void Produce() {
        Market market = galaxy.GetMarket();

        if (aliens.Count > 0) {
            foreach (Alien alien in aliens) {
                productionTimeCounter++;
            }
            if (productionTimeCounter >= product.GetProductionTimeCounter()) {
                float money = market.GetTendencies(product).GetProductNormalizedPrice();
                Company.AddMoney(money);
                
                productionTimeCounter = 0;
            }

            TimeConverter time = new TimeConverter(product.GetProductionTimeCounter() - productionTimeCounter, aliens.Count);
            //Debug.Log($"{time.GetDays()}, {time.GetHours()}, {time.GetMinutes()}, {time.GetSeconds()}");
        }
    }

    #region Add

        public void AddProductionTimeCounter(int value) {
            productionTimeCounter += value;
        }

        public void AddAlien(Alien alien) {
            aliens.Add(alien);
        }

    #endregion

    #region Remove

        public void RemoveProductionTimeCounter(int value) {
            productionTimeCounter -= value;
        }

        public void RemoveAlien(Alien alien) {
            aliens.Remove(alien);
        }

        public void RemoveAlien(int index) {
            aliens.RemoveAt(index);
        }

    #endregion

    #region Getters

        public int GetProductionTimeCounter() {
            return productionTimeCounter;
        }

        public Galaxy GetGalaxy() {
            return galaxy;
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

        public void SetProductionTimeCounter(int value) {
            productionTimeCounter = value;
        }

        public void SetGalaxy(Galaxy value) {
            galaxy = value;
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