using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    private int productId;
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
    }

    public void SelectProduct() {
        button.Select();

        if (ProductDisplayUI.GetProduct() != null) {
            if (ProductDisplayUI.GetProduct().GetId() != productId) {
                ProductDisplayUI.SetProductId(productId);
            }
        }
    }

    #region Setters

        public void SetProductId(int productId) {
            this.productId = productId;
        }

    #endregion
}
