using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ProductInfoDisplay : MonoBehaviour {
    private static Product product;
    private static UnityEvent productChangeEvent = new UnityEvent();

    [SerializeField]new private TextMeshProUGUI name;
    [SerializeField]private Image image;
    [SerializeField]private TextMeshProUGUI price;
    [SerializeField]private TextMeshProUGUI time;
    [SerializeField]private GameObject buttons;
    [SerializeField]private Button research;
    [SerializeField]private Button upgrade;
    [SerializeField]private Button choose;

    private void Awake() {
        productChangeEvent.AddListener(DisplayProduct);
    }

    private void DisplayProduct() {
        name.text = product.GetName();
        //image = product.GetImage();
        price.text = product.GetPrice().ToString("C2");
        time.text = $"{product.GetProductionTimeDays()}d {product.GetProductionTimeHours()}h {product.GetProductionTimeMinutes()}m {product.GetProductionTimeSeconds()}s";
    }

    public void Choose() {
        BranchCreation.SetProduct(product);
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public static Product GetProduct() {
            return product;
        }

    #endregion

    #region Setters

        public static void SetProduct(Product value) {
            product = value;
            productChangeEvent.Invoke();
        }

    #endregion
}
