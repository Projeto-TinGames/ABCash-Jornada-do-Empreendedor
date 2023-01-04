using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector {
    private Galaxy galaxy; // Galaxy that the sector sell its products to
    private Product product;
    private Alien chief;
    private Alien[] employees = new Alien[4];

    private int productionTimeCounter;
    private int employeeCounter;

    public Sector(Product product, Galaxy galaxy) {
        this.product = product;
        this.galaxy = galaxy;
    }

    public Sector(SectorData sectorData) {
        AlienGenerator alienGenerator;

        this.galaxy = Universe.GetGalaxies(sectorData.GetGalaxyId());
        this.product = ProductManager.GetProducts(sectorData.GetProductId());

        alienGenerator = new AlienGenerator();
        Alien chief = alienGenerator.LoadAlien(sectorData.GetChief());
        this.chief = chief;

        this.productionTimeCounter = sectorData.GetProductionTime();

        foreach (AlienData alienData in sectorData.GetEmployees()) {
            alienGenerator = new AlienGenerator();
            Alien alien = alienGenerator.LoadAlien(alienData);
            AddEmployee(alien);
        }
    }

    public void Update() {
        Produce();
    }

    private void Produce() {
        Market market = galaxy.GetMarket();

        //Criar lógica para empregados e chefe separados

        /*if (aliens.Length > 0) {
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
        }*/
    }

    #region Add

        public void AddProductionTimeCounter(int value) {
            productionTimeCounter += value;
        }

        public void AddEmployee(Alien alien) {
            employees[employeeCounter] = alien;
            employeeCounter++;
        }

    #endregion

    #region Remove

        public void RemoveProductionTimeCounter(int value) {
            productionTimeCounter -= value;
        }

        public void RemoveAlien(Alien alien) {
            for (int i = 0; i < employeeCounter; i++) {
                if (employees[i] == alien) {
                    RemoveAlien(i);
                    break;
                }
            }
        }

        public void RemoveAlien(int index) {
            employees[index] = null;
            employeeCounter--;
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

        public Alien GetChief() {
            return chief;
        }

        public Alien[] GetEmployees() {
            return employees;
        }

        public Alien GetAliens(int index) {
            return employees[index];
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

        public void SetChief(Alien value) {
            chief = value;
        }

        public void SetAliens(Alien[] value) {
            employees = value;
        }

        public void SetAliens(int index, Alien value) {
            employees[index] = value;
        }

    #endregion

}