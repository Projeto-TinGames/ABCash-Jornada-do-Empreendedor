using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplayInfo : MonoBehaviour {
    private Product product;
    private Galaxy galaxy;

    [SerializeField]new private TextMeshProUGUI name;
    [SerializeField]private Image image;
    [SerializeField]private TextMeshProUGUI price;
    [SerializeField]private TextMeshProUGUI time;
    [SerializeField]private GameObject buttons;
    [SerializeField]private Button research;
    [SerializeField]private Button upgrade;

    public void Refresh() {
        product = ProductDisplayUI.GetProduct();
        galaxy = ProductDisplayUI.GetGalaxy();

        name.text = product.GetName();
        //image = product.GetSprite();
        DisplayPrice();
        DisplayUpgrade();
        time.text = $"{product.GetProductionTimeDays()}d {product.GetProductionTimeHours()}h {product.GetProductionTimeMinutes()}m {product.GetProductionTimeSeconds()}s";
    }

    private void DisplayPrice() {
        price.text = $"{product.GetPrice().ToString("C2")}";
        price.color = Color.white;

        research.gameObject.SetActive(false);

        if (galaxy != null) {
            int rumorDay = ProductDisplayUI.GetRumorDay();

            Tendency tendency = galaxy.GetMarket().GetTendencies(product);

            if (tendency.GetIsRumor(rumorDay)) {
                research.gameObject.SetActive(true);
                price.text += $" + ({tendency.GetRumorValorizations(rumorDay)*100}%)";
                price.text += $" = {tendency.GetProductRumorNormalizedPrice(rumorDay).ToString("C2")}";
                price.color = Color.red;
            }
            else {
                price.text += $" + ({tendency.GetValorizations(rumorDay)*100}%)";
                price.text += $" = {tendency.GetProductNormalizedPrice(rumorDay).ToString("C2")}";
                price.color = Color.green;
            }
        }
    }

    private void DisplayUpgrade() {
        upgrade.gameObject.SetActive(true);
        
        if (product.GetLevel() >= 5) {
            upgrade.gameObject.SetActive(false);
        }
    }
}
