using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Product", fileName = "scriptable_product_")]
public class ProductObject : ScriptableObject {
    [SerializeField]private Product product;

    #region Getters

        public Product GetProduct() {
            return product;
        }

    #endregion
}