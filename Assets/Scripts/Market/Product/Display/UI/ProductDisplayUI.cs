using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ProductDisplayUI : MonoBehaviour {
    protected static UnityEvent refreshDisplayEvent = new UnityEvent();

    protected static bool isSelectingGalaxy;
    protected static int rumorDay;
    protected static Product product;
    protected static Galaxy galaxy;

    [SerializeField]private ProductDisplayInfo productDisplayInfo;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private TextMeshProUGUI rumorDayText;

    protected void Awake() {
        refreshDisplayEvent.AddListener(productDisplayInfo.Refresh);
        refreshDisplayEvent.AddListener(SetRumorDayText);

        if (!isSelectingGalaxy) {
            product = null;
            galaxy = null;
            rumorDay = 0;
        }
    }

    protected virtual void Start() {
        transform.SetAsFirstSibling();

        if (galaxy != null) {
            galaxyName.text = galaxy.GetName();
            refreshDisplayEvent.Invoke();
        }

        SetRumorDayText();

        isSelectingGalaxy = false;
    }

    protected void SetRumorDayText() {
        rumorDayText.text = $"Dia\n{rumorDay+1}";
    }

    public void SelectGalaxy() {
        isSelectingGalaxy = true;
        UniverseDisplay.SetIsSelectingGalaxy(true);
        
        CompanyNavUI.SetBlockActive(true);
        SceneController.instance.Load("sc_universe");
    }

    public void Research() {
        Tendency tendency = galaxy.GetMarket().GetTendencies(product.GetId());
        tendency.Research(rumorDay);
        refreshDisplayEvent.Invoke();
    }

    public void Upgrade() {
        product.Upgrade();
        refreshDisplayEvent.Invoke();
    }

    public void Exit() {
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public static int GetRumorDay() {
            return rumorDay;
        }

        public static Product GetProduct() {
            return product;
        }

        public static Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public static void SetRumorDay(int value) {
            rumorDay = value;
            refreshDisplayEvent.Invoke();
        }

        public static void SetProduct(Product value) {
            product = value;
            refreshDisplayEvent.Invoke();
        }

        public static void SetGalaxy(Galaxy value) {
            galaxy = value;
        }

    #endregion
}
