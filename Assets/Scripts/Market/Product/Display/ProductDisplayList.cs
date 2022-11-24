using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductDisplayList : MonoBehaviour {
    private List<ProductDisplay> listProductDisplay = new List<ProductDisplay>();

    [SerializeField]private ProductDisplay productDisplayPrefab;

    private void Start() {
        for (int i = 0; i < Company.GetProducts().Count; i++) {
            Product product = Company.GetProducts(i);

            ProductDisplay display = Instantiate(productDisplayPrefab);

            display.SetProductId(i);

            display.transform.SetParent(transform);
            display.transform.localScale = Vector3.one;

            listProductDisplay.Add(display);
        }
    }

    private void Update() {
        int productId = 0;
        Product product = ProductDisplayUI.GetProduct();

        if (product != null) {
            productId = product.GetId();
        }

        listProductDisplay[productId].SelectProduct();
    }
}