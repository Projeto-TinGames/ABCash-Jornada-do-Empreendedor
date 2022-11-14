using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchNavMenu : MonoBehaviour {
    public void GoToSectors() {
        SceneController.instance.Load("sc_branch_sectors");
    }

    public void GoToContract() {
        SceneController.instance.Load("sc_branch_contract");
    }

    public void Quit() {
        Company.SetCurrentBranchId(-1);
        SceneController.instance.Load("sc_universe");
    }
}
