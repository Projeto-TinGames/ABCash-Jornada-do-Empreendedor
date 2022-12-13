using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ProductDisplayUI : MonoBehaviour {
    protected static UnityEvent refreshDisplayEvent = new UnityEvent();

    protected static bool isSelectingGalaxy;
    protected static int rumorDay;
    protected static int productId;
    protected static int galaxyId = -1;

    protected static string scene;

    [SerializeField]private ProductDisplayInfo productDisplayInfo;
    [SerializeField]private TextMeshProUGUI galaxyName;

    [SerializeField]private GameObject calendarButton;

    private void Awake() {
        transform.SetAsFirstSibling();

        refreshDisplayEvent.AddListener(productDisplayInfo.Refresh);
        refreshDisplayEvent.AddListener(SetGalaxyUI);
    }

    protected virtual void Start() {
        FinishGalaxySelection();
        
        SetGalaxyUI();

        refreshDisplayEvent.Invoke();
    }

    private void SetCalendarUI(bool active) {
        calendarButton.SetActive(active);
        calendarButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Dia\n{rumorDay+1}";
    }

    private void SetGalaxyUI() {
        if (galaxyId != -1) {
            Galaxy galaxy = Universe.GetGalaxies(galaxyId);
            galaxyName.text = galaxy.GetName();
            SetCalendarUI(true);
        }
        else {
            SetCalendarUI(false);
        }
    }

    private void FinishGalaxySelection() {
        if (!isSelectingGalaxy) {
            galaxyId = -1;
            productId = rumorDay = 0;
        }
        isSelectingGalaxy = false;
    }

    public void SelectGalaxy() {
        isSelectingGalaxy = true;
        UniverseDisplay.SetIsSelectingGalaxy(true);
        
        CompanyNavUI.SetBlockActive(true);
        SceneController.instance.Load("sc_universe");
    }

    public void Research() {
        Galaxy galaxy = Universe.GetGalaxies(galaxyId);
        Tendency tendency = galaxy.GetMarket().GetTendencies(productId);
        tendency.Research(rumorDay);
        refreshDisplayEvent.Invoke();
    }

    public void Upgrade() {
        Product product = Company.GetProducts(productId);
        product.Upgrade();
        refreshDisplayEvent.Invoke();
    }

    public void Exit() {
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public static string GetScene() {
            return scene;
        }

        public static int GetRumorDay() {
            return rumorDay;
        }

        public static Product GetProduct() {
            Product product = Company.GetProducts(productId);
            return product;
        }

        public static Galaxy GetGalaxy() {
            if (galaxyId != -1) {
                Galaxy galaxy = Universe.GetGalaxies(galaxyId);
                return galaxy;
            }
            return null;
        }

    #endregion

    #region Setters

        public static void SetRumorDay(int value) {
            rumorDay = value;
            refreshDisplayEvent.Invoke();
        }

        public static void SetProductId(int value) {
            productId = value;
            refreshDisplayEvent.Invoke();
        }

        public static void SetGalaxyId(int value) {
            galaxyId = value;
            refreshDisplayEvent.Invoke();
        }

    #endregion
}
