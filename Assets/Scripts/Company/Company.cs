using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Company : MonoBehaviour {
    public static Company instance;

    [HideInInspector]public new string name;
    [HideInInspector]public float revenue;

    [HideInInspector]public Branch currentBranch;
    [HideInInspector]public Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
    [HideInInspector]public List<Alien> employees = new List<Alien>();

    private void Awake() {
        if (instance == null) {
            transform.parent = null;
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Load(CompanyData companyData) {
        this.branches.Clear();
        this.employees.Clear();

        this.name = companyData.name;
        this.revenue = companyData.revenue;

        this.currentBranch = new Branch(companyData.currentBranch);

        foreach (BranchData branchData in companyData.branches) {
            Branch branch = new Branch(branchData);
            branches.Add(branch.id, branch);
        }

        AlienGenerator alienGenerator = new AlienGenerator();
        foreach (AlienData alienData in companyData.employees) {
            Alien employee = alienGenerator.LoadAlien(alienData);
            employee.Work();
            this.employees.Add(employee);
        }
    }
}