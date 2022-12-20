using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Company {
    private static int id;
    private static string name;
    private static float money = 10000f;

    private static int currentBranchId = -1;
    private static Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
    private static List<Alien> aliens = new List<Alien>();
    private static List<Product> products = new List<Product>();

    public static void Update() {
        foreach (KeyValuePair<int, Branch> branch in Company.GetBranches()) {
            branch.Value.Update();
        }
    }

    public static void Load(CompanyData companyData) {
        branches.Clear();
        aliens.Clear();

        name = companyData.GetName();
        money = companyData.GetMoney();

        currentBranchId = companyData.GetCurrentBranchId();

        foreach (BranchData branchData in companyData.GetBranches()) {
            Branch branch = new Branch(branchData);
            branches.Add(branch.GetId(), branch);
        }

        foreach (AlienData alienData in companyData.GetAliens()) {
            AlienGenerator alienGenerator = new AlienGenerator();
            Alien employee = alienGenerator.LoadAlien(alienData);
            employee.Work();
            aliens.Add(employee);
        }

        products = companyData.GetProducts();
    }

    public static bool Pay(float value) {
        if (money >= value) {
            RemoveMoney(value);
            return true;
        }
        
        return false;
    }

    #region Add

        public static void AddMoney(float value) {
            money = (float)Math.Round(money + value, 2);
        }

        public static void AddAlien(Alien alien) {
            aliens.Insert(0, alien);
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

        public static void RemoveAlien(Alien alien) {
            aliens.Remove(alien);
        }

        public static void RemoveAlien(int index) {
            aliens.RemoveAt(index);
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

        public static int GetCurrentBranchId() {
            return currentBranchId;
        }

        public static List<Alien> GetAliens() {
            return aliens;
        }

        public static Alien GetAliens(int index) {
            return aliens[index];
        }

        public static Dictionary<int, Branch> GetBranches() {
            return branches;
        }
        
        public static Branch GetBranches(int index) {
            return branches[index];
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

        public static void SetCurrentBranchId(int value) {
            currentBranchId = value;
        }

    #endregion
}