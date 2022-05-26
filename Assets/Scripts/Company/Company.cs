using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Company : MonoBehaviour {
    public static Company instance;

    private new string name;
    private int revenue;
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

        public int GetRevenue() {
            return revenue;
        }

        public List<Alien> GetEmployees() {
            return employees;
        }

    #endregion

    #region Set Functions

        public void AddRevenue(int value) {
            revenue += value;
            Debug.Log(revenue);
        }

        public void AddEmployee(Alien alien) {
            employees.Add(alien);
            Debug.Log(employees[employees.Count-1].GetType() + " Accepted");
        }

        public void RemoveEmployee(Alien alien) {
            employees.Remove(alien);
        }

    #endregion
}
