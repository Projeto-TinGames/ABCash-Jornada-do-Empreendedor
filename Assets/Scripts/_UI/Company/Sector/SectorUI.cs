using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectorUI : MonoBehaviour {
    private const int changeProductCost = 200;

    private static bool isEditing;
    private static bool isCreating;
    private static bool changedProduct;
    private static int tab;
    private static string closeScene;
    private static Sector sector;

    [SerializeField]private GameObject productsUI;
    [SerializeField]private TextMeshProUGUI productsText;

    [SerializeField]private GameObject employeesUI;
    [SerializeField]private TextMeshProUGUI employeesText;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.setSector.AddListener(SetSector);
        EventHandlerUI.setProduct.AddListener(SetProduct);
        EventHandlerUI.selectGalaxy.AddListener(SetGalaxy);
    }

    private void Start() {
        isEditing = true;

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
        if (isCreating || !changedProduct || (changedProduct && Company.Pay(changeProductCost))) {
            isEditing = false;
            isCreating = false;
            tab = 0;

            sector.SetProductionRate();
            sector.SetProductionTimeCounter(0f);
            EventHandlerUI.setSector.Invoke(new Sector(new SectorData(sector)));
            //SectorAlienUI.ResetAliens();

            SceneController.instance.Load(closeScene);
        }
    }

    #region Getters

        public static bool GetIsEditing() {
            return isEditing;
        }

        public static Sector GetSector() {
            return sector;
        }

    #endregion

    #region Setters

        public static void SetSector(Sector value) {
            if (value != null) {
                EventHandlerUI.setProduct.Invoke(value.GetProduct());
                EventHandlerUI.selectGalaxy.Invoke(value.GetGalaxy());
                sector = value;
            }
        }

        public static void SetProduct(Product product) {
            if (sector != null) {
                if (product.GetId() != sector.GetProduct().GetId()) {
                    changedProduct = true;
                }
                else {
                    changedProduct = false;
                }
                sector.SetProduct(product);
            }
        }

        public static void SetGalaxy(Galaxy galaxy) {
            if (sector != null) {
                sector.SetGalaxy(galaxy);
            }
        }

        public static void SetCloseScene(string value) {
            closeScene = value;
        }

        public static void SetIsCreating(bool value) {
            isCreating = value;
        }

    #endregion
}