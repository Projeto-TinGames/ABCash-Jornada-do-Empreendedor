using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalaxyDisplay : MonoBehaviour {
    private Company company;

    private Button button;
    private Galaxy galaxy;
    private bool hasBranch;

    [SerializeField]private TextMeshProUGUI galaxyName;

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void Start() {
        button.interactable = false;
        button.interactable = true;
        
        galaxyName.text = $"Galáxia \n{galaxy.GetPositionX()},{galaxy.GetPositionY()}";
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
        if (hasBranch) {
            Company.instance.SetBranch(galaxy.GetId());
            SceneController.instance.Load("sc_branch");
        }
        else {
            CreateBranchUI.instance.OpenPanel(this);
        }
    }

    public void CreateBranch() {
        hasBranch = true;
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
        }

    #endregion
}
