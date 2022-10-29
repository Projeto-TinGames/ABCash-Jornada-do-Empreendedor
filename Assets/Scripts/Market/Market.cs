using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market {
    private List<Product> products = new List<Product>();
    private List<float> percentages = new List<float>(); //Porcentagem de valorização

    public Market() {
        foreach (Product product in ProductManager.GetProducts()) {
            products.Add(product);
            
            float percentage = (float)Random.Range(-100, 101)/100;
            percentages.Add(percentage);
        }
    }

    public Market(MarketData marketData) {
        foreach (Product product in ProductManager.GetProducts()) {
            products.Add(product);
        }
        
        this.percentages = marketData.GetPercentages();
    }

    #region Add

        public void AddProduct(Product product) {
            products.Add(product);
        }

        public void AddPercentage(float percentage) {
            percentages.Add(percentage);
        }

    #endregion

    #region Remove

        public void RemoveProduct(Product product) {
            products.Remove(product);
        }
        
        public void RemoveProduct(int index) {
            products.RemoveAt(index);
        }

        public void RemovePercentage(float percentage) {
            percentages.Remove(percentage);
        }

        public void RemovePercentage(int index) {
            percentages.RemoveAt(index);
        }

    #endregion

    #region Getters

        public List<Product> GetProducts() {
            return products;
        }

        public Product GetProducts(int index) {
            return products[index];
        }

        public List<float> GetPercentages() {
            return percentages;
        }

        public float GetPercentages(int index) {
            return percentages[index];
        }

    #endregion

    #region Setters

        public List<Product> SetProducts() {
            return products;
        }

        public Product SetProducts(int index) {
            return products[index];
        }

        public List<float> SetPercentages() {
            return percentages;
        }

        public float SetPercentages(float value, int index) {
            return percentages[index];
        }

    #endregion
    
}