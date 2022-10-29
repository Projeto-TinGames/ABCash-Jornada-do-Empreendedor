using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProductData {
    [SerializeField]private List<Product> products;

    public ProductData(List<Product> products) {
        this.products = products;
    }

    #region Add

        public void AddProduct(Product product) {
            products.Add(product);
        }

    #endregion

    #region Getters

        public List<Product> GetProducts() {
            return products;
        }

        public Product GetProducts(int index) {
            return products[index];
        }

    #endregion

}
