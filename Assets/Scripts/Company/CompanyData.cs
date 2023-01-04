using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompanyData {
    [SerializeField]private string name;
    [SerializeField]private float money;

    [SerializeField]private List<BranchData> branches = new List<BranchData>();
    [SerializeField]private List<AlienData> aliens = new List<AlienData>();
    [SerializeField]private List<Product> products = new List<Product>();

    public CompanyData() {
        this.name = Company.GetName();
        this.money = Company.GetMoney();

        foreach (KeyValuePair<int, Branch> entry in Company.GetBranches()) {
            BranchData branch = new BranchData(entry.Value);
            this.branches.Add(branch);
        }

        foreach (Alien alien in Company.GetAliens()) {
            this.aliens.Add(new AlienData(alien));
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

        public List<AlienData> GetAliens() {
            return aliens;
        }

        public AlienData GetAliens(int index) {
            return aliens[index];
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