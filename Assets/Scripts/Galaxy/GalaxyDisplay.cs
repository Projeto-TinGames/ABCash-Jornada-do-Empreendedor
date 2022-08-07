using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyDisplay : MonoBehaviour {
    private Company company;
    private Galaxy galaxy;
    private Direction direction;
    private bool branchFounded;

    private void Start() {
        company = Company.instance;
    }

    public void Select() {
        if (!branchFounded) {
            branchFounded = true;

            Branch branch = new Branch(galaxy.GetId(), galaxy.GetStats().GetMarket());
            branch.Test();
            company.AddBranch(branch);

            GalaxyMapDisplay.instance.GenerateMap(this);
        }
        else {
            company.SetBranch(galaxy.GetId());
            SceneController.instance.Load("sc_branch");
        }
    }

    #region Get Functions

        public Direction GetDirection() {
            return direction;
        }

    #endregion

    #region Set Functions

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
        }

        public void SetDirection(Direction direction) {
            this.direction = direction;
        }

    #endregion
}
