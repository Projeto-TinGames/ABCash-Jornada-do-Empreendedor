using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Product {
    public int id;
    public string name;
    public float price;
    public int work;

    public Product(string name, float price, int work) {
        this.name = name;
        this.price = price;
        this.work = work;
    }
}