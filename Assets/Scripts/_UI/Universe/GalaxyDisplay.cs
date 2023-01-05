using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalaxyDisplay : ClickableDisplayUI {
    private Galaxy galaxy;
    private bool enableInfo = false;

    [SerializeField]private GameObject info;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private Button createButton;
    [SerializeField]private Button enterButton;

    protected override void Start() {
        base.Start();
        enableInfo = true;
    }

    private void LoadUI() {
        galaxyName.text = galaxy.GetName();
        LoadButton();
    }

    protected virtual void LoadButton() {
        if (Company.GetBranches(galaxy.GetId()) != null) {
            ChangeColor();
            enterButton.gameObject.SetActive(true);
        }
        else {
            createButton.gameObject.SetActive(true);
        }
    }

    private void ChangeColor() {
        GetComponent<Image>().color = Color.green;
    }

    public override void Click() {
        EventHandlerUI.clickGalaxyDisplay.Invoke(galaxy);
    }

    public override void Select() {
        base.Select();

        if (enableInfo) {
            info.SetActive(true);
        }
    }

    public void Deselect() {
        info.SetActive(false);
    }

    public void Enter() {
        //BranchUI.SetBranch(galaxy.GetId());
        SceneController.instance.Load("sc_branch");
    }

    public void Create() {
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
            LoadUI();
        }

    #endregion
}
