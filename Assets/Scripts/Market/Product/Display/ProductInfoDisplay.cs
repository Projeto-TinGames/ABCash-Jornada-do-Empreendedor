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

    public void DisplayProduct(Product product) {
        name.text = product.GetName();
        //image = product.GetSprite();
        price.text = product.GetPrice().ToString("C2");
        time.text = $"{product.GetProductionTimeDays()}d {product.GetProductionTimeHours()}h {product.GetProductionTimeMinutes()}m {product.GetProductionTimeSeconds()}s";
    }
}
