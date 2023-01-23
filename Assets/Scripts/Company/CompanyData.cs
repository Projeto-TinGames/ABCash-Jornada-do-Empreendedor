using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompanyData {
    [SerializeField]private string name;
    [SerializeField]private float money;

    [SerializeField]private List<BranchData> branches = new List<BranchData>();
    [SerializeField]private List<AlienData> unemployedAliens = new List<AlienData>();
    [SerializeField]private List<AlienData> employedAliens = new List<AlienData>();
    [SerializeField]private List<Product> products = new List<Product>();

    public CompanyData() {
        this.name = Company.GetName();
        this.money = Company.GetMoney();

        foreach (KeyValuePair<int, Branch> entry in Company.GetBranches()) {
            BranchData branch = new BranchData(entry.Value);
            this.branches.Add(branch);
        }

        foreach (Alien alien in Company.GetUnemployedAliens()) {
            this.unemployedAliens.Add(new AlienData(alien));
        }

        foreach (Alien alien in Company.GetEmployedAliens()) {
            this.employedAliens.Add(new AlienData(alien));
        }

        this.products = Company.GetProducts();
    }

    #region Getters

        public string GetName() {
            return name;
        }

        public float GetMoney() {
            return money;
        }

        public List<AlienData> GetUnemployedAliens() {
            return unemployedAliens;
        }

        public AlienData GetUnemployedAliens(int index) {
            return unemployedAliens[index];
        }

        public List<AlienData> GetEmployedAliens() {
            return employedAliens;
        }

        public AlienData GetEmployedAliens(int index) {
            return employedAliens[index];
        }

        public List<BranchData> GetBranches() {
            return branches;
        }

        public BranchData GetBranches(int index) {
            return branches[index];
        }

        public List<Product> GetProducts() {
            return products;
        }

        public Product GetProducts(int index) {
            return products[index];
        }

    #endregion
}