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
        SetMarket(currentGalaxy.GetMarket());

        OpenPanel();
    }

    public override void OpenPanel() {
        galaxyName.text = $"Galáxia \n{currentGalaxy.GetX()},{currentGalaxy.GetY()}";

        base.OpenPanel();
    }

    public void CreateBranch() {
        Branch branch = new Branch(currentGalaxy.GetId(), currentGalaxy.GetMarket());
        Sector firstSector = new Sector(currentGalaxy.GetMarket(), GetMarket().GetProducts(GetDropdown().value));
        branch.AddSector(firstSector);
        Company.AddBranch(branch.GetId(), branch);

        currentDisplay.CreateBranch();
        Universe.Generate(currentGalaxy);

        currentDisplay = null;
        currentGalaxy = null;
        
        ClosePanel();
    }

}