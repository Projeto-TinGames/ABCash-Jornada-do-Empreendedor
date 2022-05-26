using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorManager : MonoBehaviour {
    private Company company;
    private Sector sector;

    private List<Alien> employees = new List<Alien>();
    private int currentAlien;

    [SerializeField]private AlienDisplay employeesDisplay;
    [SerializeField]private GameObject addButton;
    [SerializeField]private GameObject removeButton;

    private void Start() {
        company = Company.instance;
    }

    public void OpenSectorAdd(Sector openSector) {
        sector = openSector;
        currentAlien = 0;
        employees = company.GetEmployees();

        if (employees.Count > 0) {
            addButton.SetActive(true);
            removeButton.SetActive(false);
            employeesDisplay.gameObject.SetActive(true);
            employeesDisplay.RefreshDisplay(employees[0].stats);
        }
    }

    public void OpenSectorRemove(Sector openSector) {
        sector = openSector;
        currentAlien = 0;
        employees = sector.GetEmployees();

        if (employees.Count > 0) {
            addButton.SetActive(false);
            removeButton.SetActive(true);
            employeesDisplay.gameObject.SetActive(true);
            employeesDisplay.RefreshDisplay(employees[0].stats);
        }
    }

    public void ShowNextAlien() {
        if (currentAlien < employees.Count - 1) {
            currentAlien++;
            employeesDisplay.RefreshDisplay(employees[currentAlien].stats);
        }
    }

    public void ShowPreviousAlien() {
        if (currentAlien > 0) {
            currentAlien--;
            employeesDisplay.RefreshDisplay(employees[currentAlien].stats);
        }
    }

    public void AddAlien() {
        sector.AddEmployee(employees[currentAlien]);
        company.RemoveEmployee(employees[currentAlien]);

        employees = company.GetEmployees();

        if (currentAlien > 0) {
            currentAlien--;
        }

        if (employees.Count <= 0) {
            employeesDisplay.gameObject.SetActive(false);
        }
        else {
            employeesDisplay.RefreshDisplay(employees[currentAlien].stats);
        }
    }

    public void RemoveAlien() {
        company.AddEmployee(employees[currentAlien]);
        sector.RemoveEmployee(employees[currentAlien]);

        employees = sector.GetEmployees();

        if (currentAlien > 0) {
            currentAlien--;
        }

        if (employees.Count <= 0) {
            employeesDisplay.gameObject.SetActive(false);
        }
        else {
            employeesDisplay.RefreshDisplay(employees[currentAlien].stats);
        }
    }

    public void CloseSector() {
        employeesDisplay.gameObject.SetActive(false);
    }
}
