using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ProductUI : MonoBehaviour {
    public static UnityEvent<Galaxy> onChangeGalaxy = new UnityEvent<Galaxy>();
    public static UnityEvent<int> onChangeDay = new UnityEvent<int>();
    public static UnityEvent<ProductDisplay> onChangeProduct = new UnityEvent<ProductDisplay>();

    private static Galaxy selectedGalaxy;
    private static int selectedDay;
    private static ProductDisplay selectedDisplay;
    [SerializeField]private ProductDisplay displayPrefab;

    [SerializeField]private Transform productList;
    [SerializeField]private Transform productInfo;

    [SerializeField]private TextMeshProUGUI infoName;
    [SerializeField]private Image infoImage;
    [SerializeField]private TextMeshProUGUI infoPrice;
    [SerializeField]private TextMeshProUGUI infoTime;
    [SerializeField]private GameObject researchButton;
    [SerializeField]private GameObject upgradeButton;

    private void Awake() {
        gameObject.AddComponent<FirstSiblingUI>();
        onChangeProduct.AddListener(ChangeProduct);
    }

    private void Start() {
        foreach (Product product in ProductManager.GetProducts()) {
            ProductDisplay display = Instantiate(displayPrefab);
            display.SetProduct(product);

            display.transform.SetParent(productList);
            display.transform.localScale = Vector3.one;

            if (selectedDisplay == null) {
                display.Click();
            }
        }
    }

    private void Update() {
        if (selectedDisplay != null) {
            selectedDisplay.Select();
        }    
    }

    private void ChangeProduct(ProductDisplay display) {
        selectedDisplay = display;
        UpdateInfo(display.GetProduct());
    }

    private void UpdateInfo(Product product) {
        infoName.text = product.GetName();
        infoImage.sprite = product.GetSprite();
        DisplayPrice(product);
        DisplayUpgrade(product);
        infoTime.text = $"Tempo: {product.GetProductionTime()}";
    }

    private void DisplayPrice(Product product) {
        infoPrice.text = $"Preço: {product.GetPrice().ToString("C2")}";
        infoPrice.color = Color.white;

        researchButton.gameObject.SetActive(false);

        if (selectedGalaxy != null) {
            Tendency tendency = selectedGalaxy.GetMarket().GetTendencies(product);

            if (tendency.GetIsRumor(selectedDay)) {
                researchButton.gameObject.SetActive(true);
                infoPrice.text += $" + ({tendency.GetRumorValorizations(selectedDay)*100}%)";
                infoPrice.text += $" = {tendency.GetProductRumorNormalizedPrice(selectedDay).ToString("C2")}";
                infoPrice.color = Color.red;
            }
            else {
                infoPrice.text += $" + ({tendency.GetValorizations(selectedDay)*100}%)";
                infoPrice.text += $" = {tendency.GetProductNormalizedPrice(selectedDay).ToString("C2")}";
                infoPrice.color = Color.green;
            }
        }
    }

    private void DisplayUpgrade(Product product) {
        upgradeButton.gameObject.SetActive(true);
        
        if (product.GetLevel() >= 5) {
            upgradeButton.gameObject.SetActive(false);
        }
    }
}