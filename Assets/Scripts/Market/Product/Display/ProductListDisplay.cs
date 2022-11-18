using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductListDisplay : MonoBehaviour {
    [SerializeField]private ProductDisplay productDisplay;

    private void Start() {
        ProductManager.Load();

        foreach (Product product in ProductManager.GetProducts()) {
            ProductDisplay display = Instantiate(productDisplay);

            display.SetProduct(product);

            display.transform.SetParent(transform);
            display.transform.localScale = Vector3.one;
        }
    }


}
