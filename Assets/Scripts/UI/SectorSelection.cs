using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorSelection : MonoBehaviour {

    public GameObject descriptionWindow;

    public void EnterSector() {
        descriptionWindow.SetActive(true);
    }

    public void ExitSector() {
        descriptionWindow.SetActive(false);
    }

    public void ClickSector() {
        Debug.Log("Enter Sector");
    }

}
