using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorEmployees : MonoBehaviour {
    private static int currentEmployeeId;

    private List<SectorEmployeeDisplay> alienDisplayList = new List<SectorEmployeeDisplay>();
    [SerializeField]private SectorEmployeeDisplay sectorEmployeeDisplay;

    [SerializeField]private Transform chief;
    [SerializeField]private Transform employeesList;

    private void Start() {
        Sector sector = Company.GetCurrentBranch().GetCurrentSector();

        for (int i = 0; i < 5; i++) {
            SectorEmployeeDisplay display = Instantiate(sectorEmployeeDisplay);

            if (i < sector.GetAliens().Count) {
                Alien alien = sector.GetAliens(i);
                if (alien != null) {
                    display.SetAlien(alien);
                }
            }
            
            display.SetId(i);
            
            display.transform.SetParent(employeesList);
            display.transform.localScale = Vector3.one;

            alienDisplayList.Add(display);
        }

        alienDisplayList[0].transform.SetParent(chief);
        alienDisplayList[0].Select();
    }

    #region Getters

        public static int GetCurrentEmployee() {
            return currentEmployeeId;
        }

    #endregion

    #region Setters

        public static void SetCurrentEmployee(int value) {
            currentEmployeeId = value;
        }

    #endregion
}
