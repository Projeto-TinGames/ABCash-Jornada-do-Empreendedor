using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector {
    private Galaxy galaxy; // Galaxy that the sector sell its products to
    private Product product;
    private Alien[] aliens = new Alien[5];

    private float productionRate;
    private float productionTimeCounter;

    public Sector(Product product, Galaxy galaxy) {
        this.product = product;
        this.galaxy = galaxy;
    }

    public Sector(SectorData sectorData) {
        AlienGenerator alienGenerator;

        this.galaxy = Universe.GetGalaxies(sectorData.GetGalaxyId());
        this.product = ProductManager.GetProducts(sectorData.GetProductId());

        this.productionTimeCounter = sectorData.GetProductionTime();

        for (int i = 0; i < sectorData.GetAliens().Count; i++) {
            AlienData alienData = sectorData.GetAliens(i);

            if (!alienData.GetIsNull()) {
                alienGenerator = new AlienGenerator();
                Alien alien = alienGenerator.LoadAlien(alienData);
                this.aliens[i] = alien;
            }
            else {
                this.aliens[i] = null;
            }
        }

        this.SetProductionRate();
    }

    public void Update() {
        Produce();
    }

    private void Produce() {
        Market market = galaxy.GetMarket();

        productionTimeCounter += productionRate;

        if (productionTimeCounter >= product.GetProductionTimeCounter()) {
            float money = market.GetTendencies(product).GetProductNormalizedPrice();
            Company.AddMoney(money);
                
            productionTimeCounter -= product.GetProductionTimeCounter();

            if (productionTimeCounter >= product.GetProductionTimeCounter()) {
                productionTimeCounter = 0;
            }

            Debug.Log(Company.GetMoney());
        }
    }

    #region Add

        public void AddProductionTimeCounter(int value) {
            productionTimeCounter += value;
        }

    #endregion

    #region Remove

        public void RemoveProductionTimeCounter(int value) {
            productionTimeCounter -= value;
        }

        public void RemoveAlien(Alien alien) {
            for (int i = 0; i < aliens.Length; i++) {
                if (aliens[i] == alien) {
                    aliens[i] = null;
                    break;
                }
            }
        }

    #endregion

    #region Getters

        public TimeConverter GetRelativeProductionTime() {
            return new TimeConverter(product.GetProductionTimeCounter() - productionTimeCounter,productionRate);
        }

        public float GetProductionTimeCounter() {
            return productionTimeCounter;
        }

        public Galaxy GetGalaxy() {
            return galaxy;
        }

        public Product GetProduct() {
            return product;
        }

        public Alien[] GetAliens() {
            return aliens;
        }

        public Alien GetAliens(int index) {
            return aliens[index];
        }

        public bool GetHasAliens() {
            for (int i = 0; i < aliens.Length; i++) {
                if (aliens[i] != null) {
                    return true;
                }
            }
            return false;
        }

        public int GetAlienCounter() {
            int alienCounter = 0;

            for (int i = 0; i < aliens.Length; i++) {
                if (aliens[i] != null) {
                    alienCounter++;
                }
            }

            return alienCounter;
        }

    #endregion

    #region Setters

        public void SetProductionTimeCounter(float value) {
            productionTimeCounter = value;
        }

        public void SetGalaxy(Galaxy value) {
            galaxy = value;
        }

        public void SetProduct(Product value) {
            product = value;
        }

        public void SetAliens(Alien[] value) {
            aliens = value;
        }

        public void SetAliens(int index, Alien value) {
            aliens[index] = value;
        }

        public void SetProductionRate() {
            float managerBonus = 0f;
            float employeeBonus = 0f;

            productionRate = 1f;

            if (aliens[0] != null) {
                managerBonus = (float)(aliens[0].GetWisdom()/100f);
            }

            for (int i = 1; i < aliens.Length; i++) {
                Alien alien = aliens[i];

                if (alien != null) {
                    employeeBonus = (float)(alien.GetAgility()/100f);
                    productionRate += (float)(managerBonus + employeeBonus);
                }
            }
        }

    #endregion

}