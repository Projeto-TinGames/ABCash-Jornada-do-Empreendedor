using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalaxyDisplay : ClickableDisplayUI {
    private Galaxy galaxy;
    private bool select = false;
    private bool enableInfo = false;

    [SerializeField]private GameObject info;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private Button createButton;
    [SerializeField]private Button enterButton;
    [SerializeField]private Button selectButton;

    protected override void Start() {
        base.Start();
        enableInfo = true;
    }

    private void LoadUI() {
        galaxyName.text = galaxy.GetName();
        LoadButton();
    }

    protected virtual void LoadButton() {
        ChangeColor();

        if (select) {
            selectButton.gameObject.SetActive(true);
        }
        else {
            if (Company.GetBranches(galaxy.GetId()) != null) {
                enterButton.gameObject.SetActive(true);
            }
            else {
                createButton.gameObject.SetActive(true);
            }
        }
    }

    private void ChangeColor() {
        if (Company.GetBranches(galaxy.GetId()) != null) {
            GetComponent<Image>().color = Color.green;
        }
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

    public virtual void SelectGalaxy() {
        EventHandlerUI.setGalaxy.Invoke(galaxy);
        SceneController.instance.LoadPreviousScene();
    }

    public void Enter() {
        EventHandlerUI.setGalaxy.Invoke(galaxy);
        SceneController.instance.Load("sc_branch");
    }

    public void Create() {
        EventHandlerUI.setGalaxy.Invoke(galaxy);
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public bool GetSelect() {
            return select;
        }

        public Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public void SetSelect(bool value) {
            select = value;
        }

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
            LoadUI();
        }

    #endregion
}
