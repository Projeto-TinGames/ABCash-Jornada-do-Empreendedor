using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorDisplay : MonoBehaviour {
    
    private Sector sector;

    [SerializeField]private GameObject addSector;
    [SerializeField]private GameObject addEmployee;
    [SerializeField]private GameObject removeEmployee;

    public void UpdateStatus() {
        if (sector == null) {
            addSector.SetActive(true);
        }
        else {
            addSector.SetActive(false);
            addEmployee.SetActive(true);
            removeEmployee.SetActive(true);
        }
    }

    public void AddSector() {
        SectorManager.instance.OpenAdd(this);
    }

    public void AddEmployee() {
        EmployeesManager.instance.OpenAdd(sector);
    }

    public void RemoveEmployee() {
        EmployeesManager.instance.OpenRemove(sector);
    }

    #region Set Functions

        public void SetSector(Sector sector) {
            this.sector = sector;
        }

    #endregion
}
