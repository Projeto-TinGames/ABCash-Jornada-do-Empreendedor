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

    public CompanyData(Company company) {
        this.name = company.name;
        this.revenue = company.revenue;

        foreach (KeyValuePair<int, Branch> entry in company.branches) {
            BranchData branch = new BranchData(entry.Value);
            this.branches.Add(branch);
        }

        if (company.currentBranch != null) {
            this.currentBranch = this.branches[company.currentBranch.id];
        }

        foreach (Alien employee in company.employees) {
            this.employees.Add(new AlienData(employee));
        }
    }
}