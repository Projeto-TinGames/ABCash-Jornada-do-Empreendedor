using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Company {
    [HideInInspector]public static int id;
    [HideInInspector]public static string name;
    [HideInInspector]public static float revenue;

    [HideInInspector]public static Branch currentBranch;
    [HideInInspector]public static Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
    [HideInInspector]public static List<Alien> employees = new List<Alien>();

    public static void Load(CompanyData companyData) {
        branches.Clear();
        employees.Clear();

        name = companyData.name;
        revenue = companyData.revenue;

        currentBranch = new Branch(companyData.currentBranch);

        foreach (BranchData branchData in companyData.branches) {
            Branch branch = new Branch(branchData);
            branches.Add(branch.id, branch);
        }

        AlienGenerator alienGenerator = new AlienGenerator();
        foreach (AlienData alienData in companyData.employees) {
            Alien employee = alienGenerator.LoadAlien(alienData);
            employee.Work();
            employees.Add(employee);
        }
    }
}