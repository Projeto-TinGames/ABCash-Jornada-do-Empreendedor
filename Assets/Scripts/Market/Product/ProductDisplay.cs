    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductDisplay : MonoBehaviour {
    private Market market;

    [SerializeField]private GameObject panel;
    [SerializeField]private TMP_Dropdown dropdown;
    [SerializeField]private TextMeshProUGUI productPrice;

    public virtual void OpenPanel() {
        if (dropdown.options.Count == 0) {
            List<string> productNames = new List<string>();
            foreach (Product product in market.GetProducts()) {
                productNames.Add(product.GetName());
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
        float price = market.GetProducts(dropdown.value).GetPrice() * market.GetPercentages(dropdown.value);
        productPrice.text = "$" + price.ToString();
    }

    #region Getters

        protected Market GetMarket() {
            return market;
        }

        protected TMP_Dropdown GetDropdown() {
            return dropdown;
        }

    #endregion

    #region Setters

        protected void SetMarket(Market value) {
            market = value;
        }

        protected void SetDropdown(TMP_Dropdown value) {
            dropdown = value;
        }

    #endregion
}
