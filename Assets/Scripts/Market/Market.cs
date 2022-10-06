using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market {
    public List<Product> products = new List<Product>();
    public List<float> percentages = new List<float>(); //Porcentagem de valorização

    public Market() {
        foreach (Product product in ProductManager.GetProducts()) {
            products.Add(product);
            
            float percentage = (float)Random.Range(-100, 101)/100;
            percentages.Add(percentage);
        }
    }

    public Market(MarketData marketData) {
        foreach (Product product in ProductManager.GetProducts()) {
            products.Add(product);
        }
        
        this.percentages = marketData.percentages;
    }
}