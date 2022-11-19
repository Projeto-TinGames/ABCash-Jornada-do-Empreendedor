using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    private Product product;

    public void SelectProduct() {
        ProductInfoDisplay.SetProduct(product);
        GetComponent<Button>().Select();
    }

    #region Setters

        public void SetProduct(Product product) {
            this.product = product;
        }

    #endregion
}
