using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductListDisplay : MonoBehaviour {
    private List<ProductDisplay> listProductDisplay = new List<ProductDisplay>();

    [SerializeField]private ProductDisplay productDisplayPrefab;

    private void Start() {
        for (int i = 0; i < ProductManager.GetProducts().Count; i++) {
            Product product = ProductManager.GetProducts(i);

            ProductDisplay display = Instantiate(productDisplayPrefab);

            display.SetProduct(product);

            display.transform.SetParent(transform);
            display.transform.localScale = Vector3.one;

            listProductDisplay.Add(display);
        }
    }

    private void Update() {
        int productId = 0;
        Product product = ProductUI.GetProduct();

        if (product != null) {
            productId = product.GetId();
        }

        listProductDisplay[productId].SelectProduct();
    }
}