using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductUI : MonoBehaviour {
    static private bool isSelectingGalaxy;
    static private Galaxy galaxy;

    [SerializeField]private GameObject navMenu;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private GameObject exitButton;
    
    private void Start() {
        transform.SetAsFirstSibling();

        if (isSelectingGalaxy) {
            isSelectingGalaxy = false;
        }
        else {
            galaxy = null;
        }

        if (BranchCreation.GetIsCreating()) {
            exitButton.SetActive(true);
            navMenu.SetActive(false);
        }
        else {
            exitButton.SetActive(false);
            navMenu.SetActive(true);
        }

        if (galaxy != null) {
            galaxyName.text = galaxy.GetName();
            navMenu.GetComponent<CompanyNavUI>().Toggle(false);
        }
    }

    public void SelectGalaxy() {
        isSelectingGalaxy = true;
        SceneController.instance.Load("sc_universe");
    }

    public void Exit() {
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public static bool GetIsSelectingGalaxy() {
            return isSelectingGalaxy;
        }

        public static Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public static void SetGalaxy(Galaxy value) {
            galaxy = value;
        }

    #endregion
}
