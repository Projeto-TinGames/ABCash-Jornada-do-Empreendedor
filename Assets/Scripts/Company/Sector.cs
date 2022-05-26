using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour {
    private Company company;
    private List<Alien> employees = new List<Alien>();
    public Product product;
    private int workProgress;

    private void Start() {
        company = Company.instance;
    }

    private void FixedUpdate() {
        Produce();
    }

    private void Produce() {
        foreach (Alien employee in employees) {
            workProgress += 10;
        }
        if (workProgress >= product.workRequired) {
            workProgress = 0;
            company.AddRevenue(product.price);
        }
    }

    public List<Alien> GetEmployees() {
        return employees;
    }

    public void AddEmployee(Alien employee) {
        if (company.GetEmployees().Count > 0) {
            employees.Add(employee);
        }
    }

    public void RemoveEmployee(Alien employee) {
        employees.Remove(employee);
    }

}
