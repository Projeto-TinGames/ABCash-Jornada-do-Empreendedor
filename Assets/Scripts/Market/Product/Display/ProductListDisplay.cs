using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductListDisplay : MonoBehaviour {
    [SerializeField]private ProductDisplay productDisplay;

    private void Start() {
        for (int i = 0; i < ProductManager.GetProducts().Count; i++) {
            Product product = ProductManager.GetProducts(i);

            ProductDisplay display = Instantiate(productDisplay);

            display.SetProduct(product);

            display.transform.SetParent(transform);
            display.transform.localScale = Vector3.one;

            if (i == 0) {
                display.SelectProduct();
            }

            if (BranchCreation.GetProduct() != null) {
                if (product.GetId() == BranchCreation.GetProduct().GetId()) {
                    display.SelectProduct();
                }
            }
        }
    }
}