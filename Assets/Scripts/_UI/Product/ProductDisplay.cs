using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductDisplay : ClickableDisplayUI {
    private int productId;

    public override void Click() {
        ProductUI.onChangeProduct.Invoke(this);
    }

    #region Getters

        public Product GetProduct() {
            return ProductManager.GetProducts(productId);
        }

    #endregion

    #region Setters

        public void SetProduct(Product product) {
            this.productId = product.GetId();
        }

    #endregion
}