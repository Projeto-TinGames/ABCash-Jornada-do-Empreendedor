using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product {
    [SerializeField]private int id;
    [SerializeField]private string name;
    [SerializeField]private float price;
    [SerializeField]private int work;

    public Product(string name, float price, int work) {
        this.name = name;
        this.price = price;
        this.work = work;
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

        public int GetWork() {
            return work;
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

        public void SetWork(int value) {
            work = value;
        }

    #endregion
}