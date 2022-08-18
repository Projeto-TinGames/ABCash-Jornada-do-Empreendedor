using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector {
    private Market market;
    private Product product;

    private List<Alien> employees = new List<Alien>();
    private int workProgress;

    public Sector (Market market, Product product) {
        this.market = market;
        this.product = product;
    }

    private void Produce() {
        foreach (Alien employee in employees) {
            workProgress += 10;
        }
        if (workProgress >= product.workRequired) {
            float revenue = product.price + product.price*market.GetModifierForProduct(product);
            Company.instance.AddRevenue(revenue);
            
            workProgress = 0;
        }
    }

    #region Get Functions

        public Product GetProduct() {
            return product;
        }

        public List<Alien> GetEmployees() {
            return employees;
        }

    #endregion

    #region Add Functions

        public void AddEmployee(Alien employee) {
            if (Company.instance.GetEmployees().Count > 0) {
                employees.Add(employee);
            }
        }

    #endregion

    #region Remove Functions

        public void RemoveEmployee(Alien employee) {
            employees.Remove(employee);
        }

    #endregion

}
