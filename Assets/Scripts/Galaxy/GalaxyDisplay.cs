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
        
        galaxyName.text = $"Galáxia \n{galaxy.x},{galaxy.y}";
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
        if (galaxy.hasBranch) {
            Company.currentBranch = Company.branches[galaxy.id];
            SceneController.instance.Load("sc_branch");
        }
        else {
            CreateBranchManager.instance.LoadDisplay(this);
        }
    }

    public void CreateBranch() {
        galaxy.hasBranch = true;
        ChangeColors();
    }

    #region Get Functions

        public Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Set Functions

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
            
            if (galaxy.hasBranch) {
                ChangeColors();
            }
        }

    #endregion
}
