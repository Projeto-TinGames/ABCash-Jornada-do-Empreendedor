using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductDisplay : ClickableDisplayUI {
    private int productId;

    public override void Click() {
        EventHandlerUI.setProduct.Invoke(GetProduct());
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