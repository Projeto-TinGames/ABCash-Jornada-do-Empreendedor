using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Company : MonoBehaviour {
    public static Company instance;

    private new string name;
    private float revenue;

    private Branch branch;
    private Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
    private List<Alien> employees = new List<Alien>();

    private void Awake() {
        if (instance == null) {
            transform.parent = null;
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }

    #region Get Functions

        public string GetName() {
            return name;
        }

        public float GetRevenue() {
            return revenue;
        }

        public Branch GetBranch() {
            return branch;
        }

        public List<Alien> GetEmployees() {
            return employees;
        }

    #endregion

    #region Set Functions

        public void SetBranch(int id) {
            branch = branches[id];
        }

    #endregion

    #region Add Functions

        public void AddBranch(Branch branch) {
            branches.Add(branch.GetId(), branch);
        }

        public void AddRevenue(float value) {
            revenue += value;
            revenue = Mathf.Round(revenue * 100f)/100f;
            Debug.Log(revenue);
        }

        public void AddEmployee(Alien alien) {
            employees.Add(alien);
            Debug.Log(employees[employees.Count-1].GetType() + " Accepted");
        }

    #endregion

    #region Remove Functions
        
        public void RemoveEmployee(Alien alien) {
            employees.Remove(alien);
        }

    #endregion
}
