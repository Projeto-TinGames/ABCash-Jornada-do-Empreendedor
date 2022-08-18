using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    [System.NonSerialized]public Market market;

    public GameObject panel;
    public TMP_Dropdown products;
    public TextMeshProUGUI productModifier;

    public virtual void OpenPanel() {
        if (products.options.Count == 0) {
            List<string> productNames = new List<string>();
            foreach (Product product in market.GetProducts()) {
                productNames.Add(product.name);
            }
            products.AddOptions(productNames);

            ChangeProductValue();
        }
        panel.SetActive(true);
    }

    public void ClosePanel() {
        panel.SetActive(false);
    }

    public void ChangeProductValue() {
        float percentage = market.GetModifier(products.value) * 100;

        if (percentage > 0) {
            productModifier.color = Color.green;
        }
        else if (percentage < 0) {
            productModifier.color = Color.red;
        }
        else {
            productModifier.color = Color.yellow;
        }

        productModifier.text = percentage.ToString() + "%";
    }
}
