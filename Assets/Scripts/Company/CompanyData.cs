using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompanyData {
    public string name;
    public float revenue;
    public BranchData currentBranch;
    public List<BranchData> branches = new List<BranchData>();
    public List<AlienData> employees = new List<AlienData>();

    public CompanyData() {
        this.name = Company.name;
        this.revenue = Company.revenue;

        foreach (KeyValuePair<int, Branch> entry in Company.branches) {
            BranchData branch = new BranchData(entry.Value);
            this.branches.Add(branch);
        }

        if (Company.currentBranch != null) {
            this.currentBranch = this.branches[Company.currentBranch.id];
        }

        foreach (Alien employee in Company.employees) {
            this.employees.Add(new AlienData(employee));
        }
    }
}