using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesManager : MonoBehaviour {
    public static EmployeesManager instance;

    private int currentAlienIndex;
    private Sector currentSector;
    private List<Alien> currentEmployees;

    [SerializeField]private AlienDisplay employeesDisplay;
    [SerializeField]private GameObject addButton;
    [SerializeField]private GameObject removeButton;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void OpenAdd(Sector sector) {
        currentAlienIndex = 0;
        currentSector = sector;
        currentEmployees = Company.instance.GetEmployees();

        if (currentEmployees.Count > 0) {
            addButton.SetActive(true);
            removeButton.SetActive(false);
            employeesDisplay.gameObject.SetActive(true);
            employeesDisplay.RefreshDisplay(currentEmployees[0].stats);
        }
    }

    public void OpenRemove(Sector sector) {
        currentAlienIndex = 0;
        currentSector = sector;
        currentEmployees = sector.GetEmployees();

        if (currentEmployees.Count > 0) {
            addButton.SetActive(false);
            removeButton.SetActive(true);
            employeesDisplay.gameObject.SetActive(true);
            employeesDisplay.RefreshDisplay(currentEmployees[0].stats);
        }
    }

    public void ShowNextAlien() {
        if (currentAlienIndex < currentEmployees.Count - 1) {
            currentAlienIndex++;
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex].stats);
        }
    }

    public void ShowPreviousAlien() {
        if (currentAlienIndex > 0) {
            currentAlienIndex--;
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex].stats);
        }
    }

    public void AddAlien() {
        currentSector.AddEmployee(currentEmployees[currentAlienIndex]);
        Company.instance.RemoveEmployee(currentEmployees[currentAlienIndex]);

        currentEmployees = Company.instance.GetEmployees();

        if (currentAlienIndex > 0) {
            currentAlienIndex--;
        }

        if (currentEmployees.Count <= 0) {
            employeesDisplay.gameObject.SetActive(false);
        }
        else {
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex].stats);
        }
    }

    public void RemoveAlien() {
        Company.instance.AddEmployee(currentEmployees[currentAlienIndex]);
        currentSector.RemoveEmployee(currentEmployees[currentAlienIndex]);

        currentEmployees = currentSector.GetEmployees();

        if (currentAlienIndex > 0) {
            currentAlienIndex--;
        }

        if (currentEmployees.Count <= 0) {
            employeesDisplay.gameObject.SetActive(false);
        }
        else {
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex].stats);
        }
    }

    public void CloseSector() {
        employeesDisplay.gameObject.SetActive(false);
    }
}
