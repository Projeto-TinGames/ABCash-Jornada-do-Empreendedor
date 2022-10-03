    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    [System.NonSerialized]public Market market;

    public GameObject panel;
    public TMP_Dropdown dropdown;
    public TextMeshProUGUI productPrice;

    public virtual void OpenPanel() {
        if (dropdown.options.Count == 0) {
            List<string> productNames = new List<string>();
            foreach (Product product in market.products) {
                productNames.Add(product.name);
            }
            dropdown.AddOptions(productNames);

            ChangeProductPrice();
        }
        panel.SetActive(true);
    }

    public void ClosePanel() {
        panel.SetActive(false);
    }

    public void ChangeProductPrice() {
        float price = market.products[dropdown.value].price * market.percentages[dropdown.value];
        productPrice.text = "$" + price.ToString();
    }
}
