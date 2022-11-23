using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplayInfo : MonoBehaviour {
    [SerializeField]new private TextMeshProUGUI name;
    [SerializeField]private Image image;
    [SerializeField]private TextMeshProUGUI price;
    [SerializeField]private TextMeshProUGUI time;
    [SerializeField]private GameObject buttons;
    [SerializeField]private Button research;
    [SerializeField]private Button upgrade;

    public void UpdateDisplay() {
        Product product = ProductDisplayUI.GetProduct();
        Galaxy galaxy = ProductDisplayUI.GetGalaxy();

        name.text = product.GetName();
        //image = product.GetSprite();
        DisplayPrice(product,galaxy);
        time.text = $"{product.GetProductionTimeDays()}d {product.GetProductionTimeHours()}h {product.GetProductionTimeMinutes()}m {product.GetProductionTimeSeconds()}s";
    }

    private void DisplayPrice(Product product, Galaxy galaxy) {
        price.text = $"{product.GetPrice().ToString("C2")}";
        price.color = Color.white;

        research.gameObject.SetActive(false);

        if (galaxy != null) {
            int rumorDay = ProductDisplayUI.GetRumorDay();

            Tendency tendency = galaxy.GetMarket().GetTendencies(product);

            if (tendency.GetIsRumor(rumorDay)) {
                research.gameObject.SetActive(true);
                price.text += $" + ({tendency.GetValorizations(rumorDay)*100}%)";
                price.text += $" = {tendency.GetProductNormalizedPrice(rumorDay).ToString("C2")}";
                price.color = Color.red;
            }
            else {
                research.gameObject.SetActive(false);
                price.text += $" + ({tendency.GetRumorValorizations(rumorDay)*100}%)";
                price.text += $" = {tendency.GetProductRumorNormalizedPrice(rumorDay).ToString("C2")}";
                price.color = Color.green;
            }
        }
    }
}
