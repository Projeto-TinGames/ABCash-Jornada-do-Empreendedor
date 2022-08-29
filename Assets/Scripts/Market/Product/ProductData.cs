using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProductData {
    public List<Product> products;

    public ProductData(List<Product> products) {
        this.products = products;
    }
}
