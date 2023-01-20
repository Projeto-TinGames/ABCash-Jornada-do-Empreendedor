using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCreationUI : MonoBehaviour {
    private static Sector sector;

    private void Awake() {
        gameObject.AddComponent<FirstSiblingUI>();
        
        EventHandlerUI.setSector.AddListener(SetSector);
    }

    public void Select() {
        SceneController.instance.Load("sc_sector");
    }

    public void Create() {
        NavUI.SetBranchScene("sc_branch");
        SceneController.instance.Load("sc_branch");
    }

    #region Setters

        private void SetSector(Sector newSector) {
            sector = newSector;
        }

    #endregion
}
