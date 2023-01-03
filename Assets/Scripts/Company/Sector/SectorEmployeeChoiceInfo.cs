using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorEmployeeChoiceInfo : AlienInfo {
    [SerializeField]private GameObject selectButton;

    protected override void RefreshInfo(AlienDisplay display) {
        base.RefreshInfo(display);

        selectButton.SetActive(false);
        if (!contractButton.activeSelf) {
            selectButton.SetActive(true);
        }
    }

    public void Select() {
        //SectorEmployees.
        SceneController.instance.Load("sc_branch_employees");
    }
}
