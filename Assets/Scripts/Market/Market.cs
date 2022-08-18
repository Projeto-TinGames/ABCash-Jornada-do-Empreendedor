using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Market {
    private List<Product> products = new List<Product>();
    private List<float> percentageModifier = new List<float>(); //Percentagem de valorização/desvalorização

    public Market() {
        string filePath = Application.streamingAssetsPath + "/Products/products.json";
        string dataAsJson = File.ReadAllText(filePath);
        ProductData data = JsonUtility.FromJson<ProductData>(dataAsJson);

        foreach (Product product in data.products) {
            products.Add(product);

            float percentage = (float)Random.Range(-100, 101)/100;
            percentageModifier.Add(percentage);
        }
    }

    #region Get Functions

        public List<Product> GetProducts() {
            return products;
        }

        public Product GetProduct(int id) {
            return products[id];
        }

        public float GetModifier(int id) {
            return percentageModifier[id];
        }

        public float GetModifierForProduct(Product product) {
            int id = products.IndexOf(product);
            return percentageModifier[id];
        }

    #endregion
}