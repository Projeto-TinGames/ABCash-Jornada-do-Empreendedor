using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCreation : MonoBehaviour {
    public static GalaxyDisplay galaxyDisplay;
    public static Product product;

    public void Sector() {
        SceneController.instance.Load("sc_product");
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

            SceneController.instance.Load("sc_branch");
        }
    }

    public void Exit() {
        SceneController.instance.Load("sc_universe");
    }

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
