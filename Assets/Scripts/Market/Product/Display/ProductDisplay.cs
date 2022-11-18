    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    private Product product;

    #region Getters

        public void GetProduct() {
            Debug.Log(product.GetName());
            //return product;
        }

    #endregion

    #region Setters

        public void SetProduct(Product product) {
            this.product = product;
        }

    #endregion
}
