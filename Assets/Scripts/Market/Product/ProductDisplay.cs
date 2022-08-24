using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    [System.NonSerialized]public Market market;

    public GameObject panel;
    public TMP_Dropdown products;
    public TextMeshProUGUI productPrice;

    public virtual void OpenPanel() {
        if (products.options.Count == 0) {
            List<string> productNames = new List<string>();
            foreach (Product product in market.GetProducts()) {
                productNames.Add(product.name);
            }
            products.AddOptions(productNames);

            ChangeProductPrice();
        }
        panel.SetActive(true);
    }

    public void ClosePanel() {
        panel.SetActive(false);
    }

    public void ChangeProductPrice() {
        float price = market.GetProduct(products.value).price;
        productPrice.text = "$" + price.ToString();
    }
}
