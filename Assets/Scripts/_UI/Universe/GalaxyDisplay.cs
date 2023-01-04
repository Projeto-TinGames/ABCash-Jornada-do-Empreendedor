using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalaxyDisplay : ClickableDisplayUI {
    private Galaxy galaxy;

    [SerializeField]private GameObject infoElements;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private Button createButton;
    [SerializeField]private Button enterButton;

    protected override void Start() {
        base.Start();
        
        galaxyName.text = galaxy.GetName();
    }

    private void ChangeColor() {
        GetComponent<Image>().color = Color.green;
    }

    public virtual void LoadButton() {
        if (Company.GetBranches(galaxy.GetId()) != null) {
            ChangeColor();
            enterButton.gameObject.SetActive(true);
        }
        else {
            createButton.gameObject.SetActive(true);
        }
    }

    public override void Click() {
        infoElements.SetActive(true);
    }

    public void Deselect() {
        infoElements.SetActive(false);
    }

    public void Create() {
        SceneController.instance.Load("sc_branch_creation");
    }

    public void Enter() {
        //BranchUI.SetBranch(galaxy.GetId());
        SceneController.instance.Load("sc_branch");
    }

    #region Getters

        public Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
            
            if (Company.GetBranches(galaxy.GetId()) != null) {
                ChangeColor();
            }
        }

    #endregion
}
