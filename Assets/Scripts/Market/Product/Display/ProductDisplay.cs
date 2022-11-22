using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    private Product product;
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
    }

    public void SelectProduct() {
        button.Select();

        if (ProductUI.GetProduct() != null) {
            if (ProductUI.GetProduct().GetId() != product.GetId()) {
                ProductUI.SetProduct(product);
            }
        }
        else {
            ProductUI.SetProduct(product);
        }
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
