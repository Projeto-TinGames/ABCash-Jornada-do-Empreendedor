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
    [SerializeField]private Button editButton;
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

        if (select) {
            selectButton.gameObject.SetActive(true);
            ChangeColor(Color.green);
        }
        else {
            if (!galaxy.GetHasBranch()) {
                createButton.gameObject.SetActive(true);
                ChangeColor(Color.red);
            }
            else {
                if (Company.GetBranches(galaxy.GetId()) == null) {
                    editButton.gameObject.SetActive(true);
                    ChangeColor(Color.yellow);
                }
                else {
                    enterButton.gameObject.SetActive(true);
                    ChangeColor(Color.green);
                }
            }
        }
    }

    private void ChangeColor(Color color) {
        GetComponent<Image>().color = color;
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
        EventHandlerUI.selectGalaxy.Invoke(galaxy);
        SceneController.instance.LoadPreviousScene();
    }

    public void Enter() {
        EventHandlerUI.setGalaxy.Invoke(galaxy);
        EventHandlerUI.setBranch.Invoke(Company.GetBranches(galaxy.GetId()));

        NavUI.SetBranchScene("sc_branch");
        SceneController.instance.Load("sc_branch");
    }

    public void Create() {
        if (Company.Pay(galaxy.GetBranchPrice()) || galaxy.GetHasBranch()) {
            galaxy.SetHasBranch(true);
            Edit();
        }
    }

    public void Edit() {
        EventHandlerUI.setGalaxy.Invoke(galaxy);

        NavUI.SetBranchScene("sc_branch_creation");
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
