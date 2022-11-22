using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductInfoDisplay : MonoBehaviour {
    [SerializeField]new private TextMeshProUGUI name;
    [SerializeField]private Image image;
    [SerializeField]private TextMeshProUGUI price;
    [SerializeField]private TextMeshProUGUI time;
    [SerializeField]private GameObject buttons;
    [SerializeField]private Button research;
    [SerializeField]private Button upgrade;

    public void DisplayProduct() {
        Product product = ProductUI.GetProduct();
        Galaxy galaxy = ProductUI.GetGalaxy();
        name.text = product.GetName();
        //image = product.GetSprite();

        price.text = $"{product.GetPrice().ToString("C2")}";
        price.color = Color.white;

        research.gameObject.SetActive(false);

        if (galaxy != null) {
            Tendency tendency = galaxy.GetMarket().GetTendencies(product.GetId());

            if (tendency.GetIsRumor(0)) {
                research.gameObject.SetActive(true);
                price.text += $" + ({tendency.GetValorizations(0)*100}%)";
                price.text += $" = {tendency.GetProductNormalizedPrice().ToString("C2")}";
                price.color = Color.red;
            }
            else {
                research.gameObject.SetActive(false);
                price.text += $" + ({tendency.GetRumorValorizations(0)*100}%)";
                price.text += $" = {tendency.GetProductRumorNormalizedPrice().ToString("C2")}";
                price.color = Color.green;
            }
        }

        time.text = $"{product.GetProductionTimeDays()}d {product.GetProductionTimeHours()}h {product.GetProductionTimeMinutes()}m {product.GetProductionTimeSeconds()}s";
    }
}
