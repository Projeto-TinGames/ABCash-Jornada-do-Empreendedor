using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market {
    private List<Product> products = new List<Product>();

    public Market() {
        foreach (Product product in ProductManager.instance.GetProducts()) {
            Product modifiedProduct = new Product(product.name, product.workRequired, product.price);

            float percentage = (float)Random.Range(-100, 101)/100;
            modifiedProduct.price = modifiedProduct.price + percentage * modifiedProduct.price;
            modifiedProduct.price = (Mathf.Round(modifiedProduct.price * 100)) / 100;

            products.Add(modifiedProduct);
        }
    }

    #region Get Functions

        public List<Product> GetProducts() {
            return products;
        }

        public Product GetProduct(int id) {
            return products[id];
        }

    #endregion
}