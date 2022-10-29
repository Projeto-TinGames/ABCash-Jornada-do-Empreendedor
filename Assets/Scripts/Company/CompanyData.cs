using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompanyData {
    [SerializeField]private string name;
    [SerializeField]private float revenue;

    [SerializeField]private BranchData currentBranch;
    [SerializeField]private List<BranchData> branches = new List<BranchData>();
    [SerializeField]private List<AlienData> aliens = new List<AlienData>();

    public CompanyData() {
        this.name = Company.GetName();
        this.revenue = Company.GetRevenue();

        foreach (KeyValuePair<int, Branch> entry in Company.GetBranches()) {
            BranchData branch = new BranchData(entry.Value);
            this.branches.Add(branch);
        }

        if (Company.GetCurrentBranch() != null) {
            this.currentBranch = this.branches[Company.GetCurrentBranch().GetId()];
        }

        foreach (Alien alien in Company.GetAliens()) {
            this.aliens.Add(new AlienData(alien));
        }
    }

    #region Getters

        public string GetName() {
            return name;
        }

        public float GetRevenue() {
            return revenue;
        }

        public BranchData GetCurrentBranch() {
            return currentBranch;
        }

        public List<BranchData> GetBranches() {
            return branches;
        }

        public BranchData GetBranches(int index) {
            return branches[index];
        }

        public List<AlienData> GetAliens() {
            return aliens;
        }

        public AlienData GetAliens(int index) {
            return aliens[index];
        }

    #endregion
}