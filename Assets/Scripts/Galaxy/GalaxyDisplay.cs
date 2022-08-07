using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GalaxyDisplay : MonoBehaviour {
    private Company company;
    private Galaxy galaxy;
    private bool hasBranch;

    [SerializeField]private TextMeshProUGUI galaxyName;

    private void Start() {
        company = Company.instance;
        galaxyName.text = $"Galáxia \n{galaxy.GetPositionX()},{galaxy.GetPositionY()}";
    }

    public void Select() {
        if (hasBranch) {
            company.SetBranch(galaxy.GetId());
            SceneController.instance.Load("sc_branch");
        }
        else {
            hasBranch = true;

            Branch branch = new Branch(galaxy.GetId(), galaxy.GetMarket());
            branch.Test();
            company.AddBranch(branch);

            GalaxyMap.instance.GenerateMap(this.GetGalaxy());
        }
    }

    #region Get Functions

        public Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Set Functions

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
        }

    #endregion
}
