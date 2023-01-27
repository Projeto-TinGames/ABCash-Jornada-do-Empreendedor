using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Company {
    private static int id;
    private static string name;
    private static float money = 10000f;
    private static float salaryPaymentCounter = new TimeConverter(1, 0, 0, 0).GetCounter();

    private static Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
    private static List<Alien> unemployedAliens = new List<Alien>();
    private static List<Alien> employedAliens = new List<Alien>();
    private static List<Product> products = new List<Product>();

    public static void Update() {
        if (salaryPaymentCounter <= 0) {
            salaryPaymentCounter = new TimeConverter(1, 0, 0, 0).GetCounter();
            PaySalaries();
        }
        salaryPaymentCounter--;

        foreach (KeyValuePair<int, Branch> branch in Company.GetBranches()) {
            branch.Value.Update();
        }

    }

    public static void Reset() {
        branches.Clear();
        unemployedAliens.Clear();
    }

    public static void Load(CompanyData companyData) {
        Reset();

        name = companyData.GetName();
        money = companyData.GetMoney();

        foreach (BranchData branchData in companyData.GetBranches()) {
            Branch branch = new Branch(branchData);
            branches.Add(branch.GetId(), branch);
        }

        foreach (AlienData alienData in companyData.GetUnemployedAliens()) {
            AlienGenerator alienGenerator = new AlienGenerator();
            Alien employee = alienGenerator.LoadAlien(alienData);
            unemployedAliens.Add(employee);
        }

        foreach (AlienData alienData in companyData.GetEmployedAliens()) {
            AlienGenerator alienGenerator = new AlienGenerator();
            Alien employee = alienGenerator.LoadAlien(alienData);
            employedAliens.Add(employee);
        }

        products = companyData.GetProducts();
    }

    public static bool Pay(float value) {
        RemoveMoney(value);

        if (money >= value) {
            return true;
        }
        
        return false;
    }

    public static void PaySalaries() {
        /*foreach (Alien alien in unemployedAliens) {
            RemoveMoney(alien.GetBaseSalary());
        }

        foreach (Alien alien in employedAliens) {
            RemoveMoney(alien.GetFinalSalary());
        }

        Debug.Log(money);*/
    }

    #region Add

        public static void AddMoney(float value) {
            money = (float)Math.Round(money + value, 2);
            Debug.Log(money);
        }

        public static void AddAlien(Alien alien) {
            employedAliens.Remove(alien);
            unemployedAliens.Add(alien);
            alien.SetWorkGalaxyId(alien.GetGalaxyId());
            //aliens.Insert(0, alien);
        }

        public static void AddBranch(Branch branch) {
            branches.Add(branch.GetId(), branch);
        }

        public static void AddProduct(Product product) {
            products.Add(product);
        }

    #endregion

    #region Remove

        public static void RemoveMoney(float value) {
            money = (float)Math.Round(money - value, 2);
        }

        public static void EmployAlien(Alien alien) {
            unemployedAliens.Remove(alien);
            employedAliens.Add(alien);
        }

        public static void EmployAlien(int index) {
            employedAliens.Add(unemployedAliens[index]);
            unemployedAliens.RemoveAt(index);
        }

        public static void RemoveBranch(Branch branch) {
            branches.Remove(branch.GetId());
        }

        public static void RemoveBranch(int index) {
            branches.Remove(index);
        }

        public static void RemoveProduct(Product product) {
            products.Remove(product);
        }

        public static void RemoveProduct(int index) {
            products.RemoveAt(index);
        }

    #endregion

    #region Getters

        public static int GetId() {
            return id;
        }

        public static string GetName() {
            return name;
        }

        public static float GetMoney() {
            return money;
        }

        public static List<Alien> GetUnemployedAliens() {
            return unemployedAliens;
        }

        public static Alien GetUnemployedAliens(int index) {
            return unemployedAliens[index];
        }

        public static List<Alien> GetEmployedAliens() {
            return employedAliens;
        }

        public static Alien GetEmployedAliens(int index) {
            return employedAliens[index];
        }

        public static Dictionary<int, Branch> GetBranches() {
            return branches;
        }
        
        public static Branch GetBranches(int index) {
            if (branches.ContainsKey(index)) {
                return branches[index];
            }

            return null;
        }

        public static List<Product> GetProducts() {
            return products;
        }
        
        public static Product GetProducts(int index) {
            return products[index];
        }

    #endregion

    #region Setters

        public static void SetId(int value) {
            id = value;
        }

        public static void SetName(string value) {
            name = value;
        }

        public static void SetMoney(float value) {
            money = value;
        }

    #endregion
}