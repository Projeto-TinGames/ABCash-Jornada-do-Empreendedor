using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalaxyDisplay : MonoBehaviour {
    private Button button;
    private Galaxy galaxy;

    [SerializeField]private TextMeshProUGUI galaxyName;

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void Start() {
        button.interactable = false;
        button.interactable = true;
        
        galaxyName.text = $"Galáxia \n{galaxy.GetX()},{galaxy.GetY()}";
    }

    private void ChangeColors() {
        ColorBlock colors = button.colors;
        colors.normalColor = new Color(0,1,0,1);
        colors.highlightedColor = new Color(0,0.78f,0,1);
        colors.pressedColor = new Color(0,0.45f,0,1);
        colors.selectedColor = new Color(0,0.78f,0,1);
        colors.disabledColor = new Color(0,0.2f,0,0.5f);

        button.colors = colors;
    }

    public void Select() {
        if (galaxy.GetHasBranch()) {
            Company.SetCurrentBranchId(galaxy.GetId());
            SceneController.instance.Load("sc_branch_sectors");
        }
        else {
            CreateBranchManager.instance.LoadDisplay(this);
        }
    }

    public void CreateBranch() {
        galaxy.SetHasBranch(true);
        ChangeColors();
    }

    #region Getters

        public Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
            
            if (galaxy.GetHasBranch()) {
                ChangeColors();
            }
        }

    #endregion
}
