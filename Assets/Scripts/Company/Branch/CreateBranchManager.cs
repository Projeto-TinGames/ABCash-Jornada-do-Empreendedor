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
        market = currentGalaxy.GetMarket();

        OpenPanel();
    }

    public override void OpenPanel() {
        galaxyName.text = $"Galáxia \n{currentGalaxy.GetPositionX()},{currentGalaxy.GetPositionY()}";

        base.OpenPanel();
    }

    public void CreateBranch() {
        Market market = currentGalaxy.GetMarket();

        Branch branch = new Branch(currentGalaxy.GetId(), currentGalaxy.GetMarket());
        Sector firstSector = new Sector(market, market.GetProduct(products.value));
        branch.AddSector(firstSector);
        Company.instance.AddBranch(branch);

        currentDisplay.CreateBranch();
        GalaxyMap.instance.GenerateMap(currentGalaxy);

        currentDisplay = null;
        currentGalaxy = null;
        
        ClosePanel();
    }

}