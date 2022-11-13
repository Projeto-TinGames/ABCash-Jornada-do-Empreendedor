using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product {
    [SerializeField]private int id;
    [SerializeField]private string name;
    [SerializeField]private float price;
    [SerializeField]private int productionTime;

    public Product(string name, float price, int productionTime) {
        this.name = name;
        this.price = price;
        this.productionTime = productionTime;
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

        public int GetProductionTime() {
            return productionTime;
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

        public void SetProductionTime(int value) {
            productionTime = value;
        }

    #endregion
}