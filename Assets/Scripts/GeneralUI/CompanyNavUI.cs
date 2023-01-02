using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompanyNavUI : MonoBehaviour {
    private static bool blockActive;

    [SerializeField]private GameObject navMenu;
    [SerializeField]private Button expandButton;
    [SerializeField]private TextMeshProUGUI expandButtonText;
    [SerializeField]private GameObject unfocusPanel;

    private void OnEnable() {
        Toggle(true);

        if (blockActive) {
            Toggle(false);
            blockActive = false;
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
        if (Company.GetCurrentBranchId() >= 0) {
            SceneController.instance.Load("sc_branch");
        }
        else {
            SceneController.instance.Load("sc_universe");
        }
    }

    public void Employees() {
        SceneController.instance.Load("sc_employees");
    }

    public void Products() {
        SceneController.instance.Load("sc_products");
    }

    #region Setters

        public static void SetBlockActive(bool value) {
            blockActive = value;
        }

    #endregion
}
