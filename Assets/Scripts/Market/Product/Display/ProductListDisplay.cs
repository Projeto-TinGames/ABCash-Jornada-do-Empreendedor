using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductListDisplay : MonoBehaviour {
    private static Market market;
    [SerializeField]private ProductDisplay productDisplay;

    private List<ProductDisplay> listProductDisplay = new List<ProductDisplay>();

    private void Start() {
        for (int i = 0; i < ProductManager.GetProducts().Count; i++) {
            Product product = ProductManager.GetProducts(i);

            ProductDisplay display = Instantiate(productDisplay);

            display.SetProduct(product);

            display.transform.SetParent(transform);
            display.transform.localScale = Vector3.one;

            listProductDisplay.Add(display);
        }

        if (ProductInfoDisplay.GetProduct() != null) {
            listProductDisplay[ProductInfoDisplay.GetProduct().GetId()].SelectProduct();
        }
        else {
            listProductDisplay[0].SelectProduct();
        }
    }

    private void Update() {
        //if (EventSystem.current.lastSelectedGameObject.)
    }
}