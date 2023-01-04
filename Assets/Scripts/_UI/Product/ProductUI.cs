using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductUI : MonoBehaviour {
    public static UnityEvent<ProductDisplay> onChangeProduct = new UnityEvent<ProductDisplay>();
    private ProductDisplay selectedDisplay;

    [SerializeField]private ProductDisplay displayPrefab;

    [SerializeField]private Transform productList;
    [SerializeField]private Transform productInfo;

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
        //
    }
}