using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NavUI : MonoBehaviour {
    private static bool activateOnStart;
    private static string branchScene = "sc_universe";

    [SerializeField]private GameObject controlUI;
    [SerializeField]private GameObject navMenu;
    [SerializeField]private Button expandButton;
    [SerializeField]private TextMeshProUGUI expandButtonText;
    [SerializeField]private GameObject unfocusPanel;

    private void Start() {
        Toggle(false);

        if (activateOnStart) {
            Toggle(true);
            activateOnStart = false;
        }
    }

    public void Toggle() {
        Toggle(!navMenu.activeSelf);
    }

    public void Toggle(bool value) {
        navMenu.SetActive(value);
        unfocusPanel.SetActive(value);

        if (value) {
            expandButtonText.text = "<";
        }
        else {
            expandButtonText.text = ">";
        }
    }

    public void Branches() {
        activateOnStart = true;
        SceneController.instance.Load(branchScene);
    }

    public void Employees() {
        activateOnStart = true;
        SceneController.instance.Load("sc_employees");
    }

    public void Products() {
        activateOnStart = true;
        SceneController.instance.Load("sc_products");
    }

    #region Setters

        public static void SetBranchScene(string value) {
            branchScene = value;
        }

    #endregion
}
