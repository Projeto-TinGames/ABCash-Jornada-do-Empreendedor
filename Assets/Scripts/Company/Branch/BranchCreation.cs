using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BranchCreation : MonoBehaviour {
    private static GalaxyDisplay galaxyDisplay;
    private static Product product;
    private static bool isCreating;

    [SerializeField]private TextMeshProUGUI sector;

    private void Start() {
        isCreating = true;
        if (product != null) {
            sector.text = product.GetName();
        }
    }

    public void Sector() {
        SceneController.instance.Load("sc_products");
    }

    public void Create() {
        if (product != null) {
            Galaxy galaxy = galaxyDisplay.GetGalaxy();

            Branch branch = new Branch(galaxy.GetId());
            Sector sector = new Sector(product, galaxyDisplay.GetGalaxy());

            branch.AddSector(sector);
            Company.AddBranch(branch);

            galaxyDisplay.Deselect();
            galaxyDisplay = null;
            product = null;

            isCreating = false;
            product = null;
            SceneController.instance.Load("sc_branch");
        }
    }

    public void Exit() {
        isCreating = false;
        product = null;
        SceneController.instance.Load("sc_universe");
    }

    #region Getters

        public static Product GetProduct() {
            return product;
        }

        public static bool GetIsCreating() {
            return isCreating;
        }

    #endregion

    #region Setters

        public static void SetGalaxyDisplay(GalaxyDisplay value) {
            if (galaxyDisplay != null) {
                galaxyDisplay.Deselect();
            }
            
            galaxyDisplay = value;
        }

        public static void SetProduct(Product value) {
            product = value;
        }

    #endregion
}
