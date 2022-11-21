using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    private Product product;

    public void SelectProduct() {
        ProductUI.SetProduct(product);
        GetComponent<Button>().Select();
    }

    #region Getters

        public Product GetProduct() {
            return product;
        }

    #endregion

    #region Setters

        public void SetProduct(Product product) {
            this.product = product;
        }

    #endregion
}
