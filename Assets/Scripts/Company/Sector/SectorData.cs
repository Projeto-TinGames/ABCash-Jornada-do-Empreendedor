using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SectorData {
    [SerializeField]private int productId;
    [SerializeField]private int galaxyId;
    [SerializeField]private int productionTime;

    [SerializeField]private AlienData chief;
    [SerializeField]private List<AlienData> employees = new List<AlienData>();

    public SectorData(Sector sector) {
        this.productionTime = sector.GetProductionTimeCounter();
        this.productId = sector.GetProduct().GetId();
        this.galaxyId = sector.GetGalaxy().GetId();

        this.chief = new AlienData(sector.GetChief());
        
        foreach (Alien alien in sector.GetAliens()) {
            if (alien != null) {
                this.employees.Add(new AlienData(alien));
            }
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

        public AlienData GetChief() {
            return chief;
        }

        public List<AlienData> GetEmployees() {
            return employees;
        }

        public AlienData GetEmployees(int index) {
            return employees[index];
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

        public void SetChief(AlienData value) {
            chief = value;
        }

        public void SetEmployees(List<AlienData> value) {
            employees = value;
        }

        public void SetEmployees(int index, AlienData value) {
            employees[index] = value;
        }

    #endregion
}