using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector {
    public int work;

    public Market market;
    public Product product;
    public List<Alien> employees = new List<Alien>();

    public Sector (Market market, Product product) {
        this.market = market;
        this.product = product;
    }

    private void Produce() {
        foreach (Alien employee in employees) {
            work += 10;
        }
        if (work >= product.work) {
            float revenue = product.price * market.percentages[product.id];
            Company.instance.revenue += revenue;
            
            work = 0;
        }
    }
}
