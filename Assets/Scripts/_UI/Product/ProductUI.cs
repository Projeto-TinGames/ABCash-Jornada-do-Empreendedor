using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ProductUI : MonoBehaviour {
    private static int galaxyId;
    private static int productId;
    private static int dayId;
    private List<ProductDisplay> displayList = new List<ProductDisplay>();

    private static UnityEvent updateInfo = new UnityEvent();
    private static UnityEvent updateDay = new UnityEvent();

    [SerializeField]private ProductDisplay displayPrefab;

    [SerializeField]private Transform productList;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private TextMeshProUGUI dayName;

    [SerializeField]private TextMeshProUGUI infoName;
    [SerializeField]private Image infoImage;
    [SerializeField]private TextMeshProUGUI infoPrice;
    [SerializeField]private TextMeshProUGUI infoTime;
    [SerializeField]private GameObject researchButton;
    [SerializeField]private GameObject upgradeButton;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.setProduct.AddListener(SetProduct);
        EventHandlerUI.selectGalaxy.AddListener(SetGalaxy);
        EventHandlerUI.setDay.AddListener(SetDay);
    }

    private void Awake() {
        gameObject.AddComponent<FirstSiblingUI>();

        updateInfo.AddListener(UpdateInfo);
        updateDay.AddListener(UpdateDay);
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
        Tendency tendency = Universe.GetGalaxies(galaxyId).GetMarket().GetTendencies(product);
        Sector sector = SectorUI.GetSector();

        float price;

        researchButton.gameObject.SetActive(false);
        
        if (tendency.GetIsRumor(dayId)) {
            researchButton.gameObject.SetActive(true);
            price = tendency.GetProductRumorNormalizedPrice(dayId);
        }
        else {
            price = tendency.GetProductNormalizedPrice(dayId);
        }

        if (SectorUI.GetIsEditing()) {
            price -= sector.GetExportationTax();
        }

        infoPrice.text = $"Preço: {price.ToString("C2")}";
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

    #region Getters

        public static Tendency GetTendency() {
            Product product = Company.GetProducts(productId);
            return Universe.GetGalaxies(galaxyId).GetMarket().GetTendencies(product);
        }

        public static int GetDay() {
            return dayId;
        }

    #endregion

    #region Setters

        private static void SetProduct(Product product) {
            productId = product.GetId();
            
            updateInfo.Invoke();
        }

        private static void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

        private static void SetDay(int day) {
            dayId = day;

            updateDay.Invoke();
            updateInfo.Invoke();
        }

    #endregion
}