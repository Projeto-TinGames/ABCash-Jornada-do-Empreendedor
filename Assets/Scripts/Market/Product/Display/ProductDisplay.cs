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

        if (ProductDisplayUI.GetProduct() != null) {
            if (ProductDisplayUI.GetProduct().GetId() != product.GetId()) {
                ProductDisplayUI.SetProduct(product);
            }
        }
        else {
            ProductDisplayUI.SetProduct(ProductManager.GetProducts(product.GetId()));
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
