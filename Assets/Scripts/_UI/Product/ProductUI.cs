using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ProductUI : MonoBehaviour {
    [SerializeField]private ProductDisplay displayPrefab;

    [SerializeField]private Transform productList;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private TextMeshProUGUI dayName;
    private List<ProductDisplay> displayList = new List<ProductDisplay>();
    private static int galaxyId;
    private static int productId;
    private static int dayId;

    [SerializeField]private Transform productInfo;
    [SerializeField]private TextMeshProUGUI infoName;
    [SerializeField]private Image infoImage;
    [SerializeField]private TextMeshProUGUI infoPrice;
    [SerializeField]private TextMeshProUGUI infoTime;
    [SerializeField]private GameObject researchButton;
    [SerializeField]private GameObject upgradeButton;

    private void Awake() {
        gameObject.AddComponent<FirstSiblingUI>();

        EventHandlerUI.setProduct.AddListener(SetProduct);
        EventHandlerUI.setGalaxy.AddListener(SetGalaxy);
        EventHandlerUI.setDay.AddListener(SetDay);
    }

    private void Start() {
        foreach (Product product in Company.GetProducts()) {
            ProductDisplay display = Instantiate(displayPrefab);
            display.SetProduct(product);

            display.transform.SetParent(productList);
            display.transform.localScale = Vector3.one;

            displayList.Add(display);
        }

        displayList[productId].Click();
        UpdateGalaxy();
        UpdateDay();
    }

    private void Update() {
        UpdateProduct();
    }

    private void UpdateProduct() {
        displayList[productId].Select();
    }

    private void UpdateGalaxy() {
        galaxyName.text = Universe.GetGalaxies(galaxyId).GetName();
    }

    private void UpdateDay() {
        dayName.text = $"Dia\n{dayId+1}";
    }

    private void UpdateInfo() {
        Product product = Company.GetProducts(productId);

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

        Tendency tendency = Universe.GetGalaxies(galaxyId).GetMarket().GetTendencies(product);

        if (tendency.GetIsRumor(dayId)) {
            researchButton.gameObject.SetActive(true);
            infoPrice.text += $" + ({tendency.GetRumorValorizations(dayId)*100}%)";
            infoPrice.text += $" = {tendency.GetProductRumorNormalizedPrice(dayId).ToString("C2")}";
            infoPrice.color = Color.red;
        }
        else {
            infoPrice.text += $" + ({tendency.GetValorizations(dayId)*100}%)";
            infoPrice.text += $" = {tendency.GetProductNormalizedPrice(dayId).ToString("C2")}";
            infoPrice.color = Color.green;
        }
    }

    private void DisplayUpgrade(Product product) {
        upgradeButton.gameObject.SetActive(true);
        
        if (product.GetLevel() >= 5) {
            upgradeButton.gameObject.SetActive(false);
        }
    }

    public void SelectGalaxy() {
        SceneController.instance.Load("sc_universe_select");
    }

    public void Upgrade() {
        Product product = Company.GetProducts(productId);
        product.Upgrade();

        UpdateInfo();
    }

    public void Research() {
        Galaxy galaxy = Universe.GetGalaxies(galaxyId);
        Tendency tendency = galaxy.GetMarket().GetTendencies(productId);
        tendency.Research(dayId);

        UpdateInfo();
    }

    #region Setters

        private void SetProduct(Product product) {
            productId = product.GetId();
            UpdateInfo();
        }

        private static void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

        private void SetDay(int day) {
            dayId = day;

            UpdateDay();
            UpdateInfo();
        }

    #endregion
}