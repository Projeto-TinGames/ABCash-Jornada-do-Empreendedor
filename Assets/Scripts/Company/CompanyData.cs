using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CompanyData {
    private bool isLoading = true;
    [SerializeField]private string name;
    [SerializeField]private float money;
    [SerializeField]private float lastOnline;
    [SerializeField]private float compTime;

    [SerializeField]private List<BranchData> branches = new List<BranchData>();
    [SerializeField]private List<AlienData> unemployedAliens = new List<AlienData>();
    [SerializeField]private List<AlienData> employedAliens = new List<AlienData>();
    [SerializeField]private List<Product> products = new List<Product>();

    public CompanyData() {
        this.name = Company.GetName();
        this.money = Company.GetMoney();
        this.compTime = Company.GetCompTime();

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

        string dateUrl = "http://worldtimeapi.org/api/ip";
        UnityEvent<string> LoadTimeCompEvent = new UnityEvent<string>();
        LoadTimeCompEvent.AddListener(LoadLastOnline);

        if (DataManager.instance != null) {
            DataManager.instance.Load(dateUrl, LoadTimeCompEvent);
        }

        this.products = Company.GetProducts();
    }

    private void LoadLastOnline(string dataAsJson) {
        TimeData timeData = new TimeData(dataAsJson);
        this.lastOnline = timeData.GetCounter();
        isLoading = false;
    }

    #region Getters

        public bool GetIsLoading() {
            return isLoading;
        }

        public string GetName() {
            return name;
        }

        public float GetMoney() {
            return money;
        }

        public float GetLastOnline() {
            return lastOnline;
        }

        public float GetCompTime() {
            return compTime;
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