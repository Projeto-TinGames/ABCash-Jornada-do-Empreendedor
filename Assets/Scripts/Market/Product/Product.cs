using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Product {
    public string name;
    public int workRequired;
    public float price;

    public Product(string name, int workRequired, float price) {
        this.name = name;
        this.workRequired = workRequired;
        this.price = price;
    }
}

[System.Serializable]
public class ProductData {
    public List<Product> products;

    public ProductData(List<Product> products) {
        this.products = products;
    }
}