using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Company {
    private static int id;
    private static string name;
    private static float money;

    private static Branch currentBranch;
    private static Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
    private static List<Alien> aliens = new List<Alien>();

    public static void Update() {
        foreach (KeyValuePair<int, Branch> branch in Company.GetBranches()) {
            foreach (Sector sector in branch.Value.GetSectors()) {
                sector.Produce();
            }
        }
    }

    public static void Load(CompanyData companyData) {
        branches.Clear();
        aliens.Clear();

        name = companyData.GetName();
        money = companyData.GetMoney();

        currentBranch = new Branch(companyData.GetCurrentBranch());

        foreach (BranchData branchData in companyData.GetBranches()) {
            Branch branch = new Branch(branchData);
            branches.Add(branch.GetId(), branch);
        }

        AlienGenerator alienGenerator = new AlienGenerator();
        
        foreach (AlienData alienData in companyData.GetAliens()) {
            Alien employee = alienGenerator.LoadAlien(alienData);
            employee.Work();
            aliens.Add(employee);
        }
    }

    #region Add

        public static void AddMoney(float value) {
            money = (float)Math.Round(money + value, 2);
        }

        public static void AddAlien(Alien alien) {
            aliens.Add(alien);
        }

        public static void AddBranch(int key, Branch branch) {
            branches.Add(key, branch);
        }

    #endregion

    #region Remove

        public static void RemoveMoney(float value) {
            money = (float)Math.Round(money - value, 2);
        }

        public static void RemoveAlien(Alien alien) {
            aliens.Remove(alien);
        }

        public static void RemoveAlien(int alien) {
            aliens.RemoveAt(alien);
        }

        public static void RemoveBranch(int index) {
            branches.Remove(index);
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

        public static Branch GetCurrentBranch() {
            return currentBranch;
        }

        public static Dictionary<int, Branch> GetBranches() {
            return branches;
        }
        
        public static Branch GetBranches(int index) {
            return branches[index];
        }

        public static List<Alien> GetAliens() {
            return aliens;
        }

        public static Alien GetAliens(int index) {
            return aliens[index];
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

        public static void SetCurrentBranch(Branch value) {
            currentBranch = value;
        }

    #endregion
}