using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour {
    private Company company;
    [SerializeField]private AlienDisplay employeesDisplay;

    private void Start() {
        company = Company.instance;
    }

    public void ShowEmployees() {
        List<Alien> employees = company.GetEmployees();

        if (employees.Count > 0) {
            employeesDisplay.gameObject.SetActive(true);
            employeesDisplay.RefreshDisplay(employees[0].stats);
        }
    }
}
