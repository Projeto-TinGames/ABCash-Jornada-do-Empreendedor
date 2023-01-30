using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product {
    [SerializeField]private int id;
    [SerializeField]private string name;
    [SerializeField]private float price;
    [SerializeField]private int level = 1;

    [SerializeField]private float productionTimeCounter;
    private int productionTimeDays;
    private int productionTimeHours;
    private int productionTimeMinutes;
    private int productionTimeSeconds;

    //Criar uma classe de Price que terá todos valores relacionados ao preço do produto, similar ao Salary do alien

    private Sprite sprite;

    /*public Product(int id, string name, float price, int productionTimeCounter) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.level = 1;
        SetProductionTimeCounter(productionTimeCounter);
    }*/

    public void Upgrade() {
        level++;
    }

    #region Getters

        public int GetId() {
            return id;
        }

        public string GetName() {
            return name;
        }

        public Sprite GetSprite() {
            return sprite;
        }

        public float GetBasePrice() {
            return price;
        }

        public float GetUpgradePrice() {
            return price*level - price;
        }

        public float GetPrice() {
            return price*level;
        }

        public int GetLevel() {
            return level;
        }

        public float GetProductionTimeCounter() {
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

        public string GetProductionTime() {
            return $"{GetProductionTimeDays()}d {GetProductionTimeHours()}h {GetProductionTimeMinutes()}m {GetProductionTimeSeconds()}s";
        }

    #endregion

    #region Setters

        public void SetId(int value) {
            id = value;
        }

        public void SetName(string value) {
            name = value;
        }

        public void SetSprite() {
            sprite = Resources.Load<Sprite>($"Sprites/Products/{id}");
        }

        public void SetBasePrice(float value) {
            price = value;
        }

        public void SetLevel(int value) {
            level = value;
        }

        public void SetProductionTimeCounter() {
            TimeConverter timeConverter = new TimeConverter(productionTimeDays, productionTimeHours, productionTimeMinutes, productionTimeSeconds);
            productionTimeCounter = timeConverter.GetCounter();
        }

        public void SetProductionTimeCounter(float value) {
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