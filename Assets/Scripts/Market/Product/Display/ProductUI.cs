using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ProductUI : MonoBehaviour {
    protected static bool isSelectingGalaxy;
    protected static UnityEvent<Product> productChangeEvent;
    protected static Product product;
    protected static Galaxy galaxy;

    [SerializeField]private ProductInfoDisplay productInfoDisplay;
    [SerializeField]private TextMeshProUGUI galaxyName;

    protected void Awake() {
        productChangeEvent = new UnityEvent<Product>();
        productChangeEvent.AddListener(productInfoDisplay.DisplayProduct);

        if (!isSelectingGalaxy) {
            product = null;
            galaxy = null;
        }
    }

    protected virtual void Start() {
        transform.SetAsFirstSibling();

        if (galaxy != null) {
            galaxyName.text = galaxy.GetName();
        }

        isSelectingGalaxy = false;
    }

    public void SelectGalaxy() {
        isSelectingGalaxy = true;
        SceneController.instance.Load("sc_universe");
    }

    public void Exit() {
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public static bool GetIsSelectingGalaxy() {
            return isSelectingGalaxy;
        }

        public static Product GetProduct() {
            return product;
        }

        public static Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public static void SetProduct(Product value) {
            product = value;
            productChangeEvent.Invoke(value);
        }

        public static void SetGalaxy(Galaxy value) {
            galaxy = value;
        }

    #endregion
}
