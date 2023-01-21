using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectorUI : MonoBehaviour {
    private static int tab;
    private static Sector sector = new Sector();
    [SerializeField]private GameObject productsUI;
    [SerializeField]private TextMeshProUGUI productsText;

    [SerializeField]private GameObject employeesUI;
    [SerializeField]private TextMeshProUGUI employeesText;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.setSector.AddListener(SetSector);
        EventHandlerUI.setProduct.AddListener(SetProduct);
        EventHandlerUI.setGalaxy.AddListener(SetGalaxy);
    }

    private void Start() {
        if (tab == 0) {
            EnableProducts();
        }       
        else {
            EnableEmployees();
        } 
    }

    public void EnableProducts() {
        tab = 0;
        productsUI.SetActive(true);
        productsText.color = Color.red;

        employeesUI.SetActive(false);
        employeesText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f);
    }

    public void EnableEmployees() {
        tab = 1;
        employeesUI.SetActive(true);
        employeesText.color = Color.red;

        productsUI.SetActive(false);
        productsText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f);
    }

    public void Finish() {
        EventHandlerUI.setSector.Invoke(sector);
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public static Sector GetSector() {
            return sector;
        }

    #endregion

    #region Setters

        public static void SetSector(Sector value) {
            sector = value;
        }

        public static void SetProduct(Product product) {
            sector.SetProduct(product);
        }

        public static void SetGalaxy(Galaxy galaxy) {
            sector.SetGalaxy(galaxy);
        }

    #endregion
}