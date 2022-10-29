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
        currentEmployees = Company.GetAliens();

        if (currentEmployees.Count > 0) {
            addButton.SetActive(true);
            removeButton.SetActive(false);
            employeesDisplay.gameObject.SetActive(true);
            employeesDisplay.RefreshDisplay(currentEmployees[0]);
        }
    }

    public void OpenRemove(Sector sector) {
        currentAlienIndex = 0;
        currentSector = sector;
        currentEmployees = sector.GetAliens();

        if (currentEmployees.Count > 0) {
            addButton.SetActive(false);
            removeButton.SetActive(true);
            employeesDisplay.gameObject.SetActive(true);
            employeesDisplay.RefreshDisplay(currentEmployees[0]);
        }
    }

    public void ShowNextAlien() {
        if (currentAlienIndex < currentEmployees.Count - 1) {
            currentAlienIndex++;
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex]);
        }
    }

    public void ShowPreviousAlien() {
        if (currentAlienIndex > 0) {
            currentAlienIndex--;
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex]);
        }
    }

    public void AddAlien() {
        currentSector.AddAlien(currentEmployees[currentAlienIndex]);
        Company.RemoveAlien(currentEmployees[currentAlienIndex]);

        currentEmployees = Company.GetAliens();

        if (currentAlienIndex > 0) {
            currentAlienIndex--;
        }

        if (currentEmployees.Count <= 0) {
            employeesDisplay.gameObject.SetActive(false);
        }
        else {
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex]);
        }
    }

    public void RemoveAlien() {
        Company.AddAlien(currentEmployees[currentAlienIndex]);
        currentSector.RemoveAlien(currentEmployees[currentAlienIndex]);

        currentEmployees = currentSector.GetAliens();

        if (currentAlienIndex > 0) {
            currentAlienIndex--;
        }

        if (currentEmployees.Count <= 0) {
            employeesDisplay.gameObject.SetActive(false);
        }
        else {
            employeesDisplay.RefreshDisplay(currentEmployees[currentAlienIndex]);
        }
    }

    public void CloseSector() {
        employeesDisplay.gameObject.SetActive(false);
    }
}
