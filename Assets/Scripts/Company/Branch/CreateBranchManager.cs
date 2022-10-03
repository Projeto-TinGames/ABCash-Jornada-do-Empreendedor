using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateBranchManager : ProductDisplay {
    public static CreateBranchManager instance;

    private GalaxyDisplay currentDisplay;
    private Galaxy currentGalaxy;

    [SerializeField]private TextMeshProUGUI galaxyName;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void LoadDisplay(GalaxyDisplay display) {
        currentDisplay = display;
        currentGalaxy = display.GetGalaxy();
        market = currentGalaxy.market;

        OpenPanel();
    }

    public override void OpenPanel() {
        galaxyName.text = $"Galáxia \n{currentGalaxy.x},{currentGalaxy.y}";

        base.OpenPanel();
    }

    public void CreateBranch() {
        Branch branch = new Branch(currentGalaxy.id, currentGalaxy.market);
        Sector firstSector = new Sector(currentGalaxy.market, market.products[dropdown.value]);
        branch.sectors.Add(firstSector);
        Company.instance.branches.Add(branch.id,branch);

        currentDisplay.CreateBranch();
        GalaxyMap.instance.GenerateMap(currentGalaxy);

        currentDisplay = null;
        currentGalaxy = null;
        
        ClosePanel();
    }

}