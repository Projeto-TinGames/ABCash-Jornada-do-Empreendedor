using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product {
    [SerializeField]private int id;
    [SerializeField]private string name;
    [SerializeField]private float price;

    [SerializeField]private int productionTimeCounter;
    private int productionTimeDays;
    private int productionTimeHours;
    private int productionTimeMinutes;
    private int productionTimeSeconds;

    public Product(string name, float price, int productionTimeCounter) {
        this.name = name;
        this.price = price;
        SetProductionTimeCounter(productionTimeCounter);
    }

    #region Getters

        public int GetId() {
            return id;
        }

        public string GetName() {
            return name;
        }

        public float GetPrice() {
            return price;
        }

        public int GetProductionTimeCounter() {
            return productionTimeCounter;
        }

        public int GetProductionTimeDays() {
            return productionTimeDays;
        }

        public int GetProductionTimeHours() {
            return productionTimeHours;
        }

        public int GetProductionTimeMinutes() {
            return productionTimeMinutes;
        }

        public int GetProductionTimeSeconds() {
            return productionTimeSeconds;
        }

    #endregion

    #region Setters

        public void SetId(int value) {
            id = value;
        }

        public void SetName(string value) {
            name = value;
        }

        public void SetPrice(float value) {
            price = value;
        }

        public void SetProductionTimeCounter() {
            TimeConverter timeConverter = new TimeConverter(productionTimeDays, productionTimeHours, productionTimeMinutes, productionTimeSeconds);
            productionTimeCounter = timeConverter.GetCounter();
        }

        public void SetProductionTimeCounter(int value) {
            productionTimeCounter = value;
            SetProductionTimeMetrics();
        }

        public void SetProductionTimeMetrics() {
            TimeConverter timeConverter = new TimeConverter(productionTimeCounter);

            productionTimeDays = timeConverter.GetDays();
            productionTimeHours = timeConverter.GetHours();
            productionTimeMinutes = timeConverter.GetMinutes();
            productionTimeSeconds = timeConverter.GetSeconds();
        }

        public void SetProductionTimeDays(int value) {
            productionTimeDays = value;
        }

        public void SetProductionTimeHours(int value) {
            productionTimeHours = value;
        }

        public void SetProductionTimeMinutes(int value) {
            productionTimeMinutes = value;
        }

        public void SetProductionTimeSeconds(int value) {
            productionTimeSeconds = value;
        }

    #endregion
}