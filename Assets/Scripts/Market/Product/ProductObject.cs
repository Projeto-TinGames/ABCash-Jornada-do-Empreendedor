using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Product", fileName = "scriptable_product_")]
public class ProductObject : ScriptableObject {
    public Product product;

    #region Get Functions
        
        public string GetName() {
            return product.name;
        }

        public int GetWork() {
            return product.workRequired;
        }

        public float GetPrice() {
            return product.price;
        }

    #endregion

    #region Set Functions

        public void SetName(string name) {
            product.name = name;
        }

        public void SetWork(int workRequired) {
            product.workRequired = workRequired;
        }

        public void SetPrice(float price) {
            product.price = price;
        }

    #endregion

}