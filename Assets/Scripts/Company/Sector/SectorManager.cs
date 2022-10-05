using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorManager : ProductDisplay {
    public static SectorManager instance;

    private SectorDisplay currentDisplay;

    [SerializeField]private GameObject sectorDisplay;
    [SerializeField]private GameObject sectorsUI;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Branch branch = Company.currentBranch;
        market = branch.market;

        for (int i = 0; i < branch.sectors.Count + 1; i++) {
            GameObject newInstance = Instantiate(sectorDisplay);
            newInstance.transform.SetParent(sectorsUI.transform);
            newInstance.transform.localScale = Vector3.one;

            SectorDisplay display = newInstance.GetComponent<SectorDisplay>();

            if (i < branch.sectors.Count) {
                display.SetSector(branch.sectors[i]);
            }
            display.UpdateStatus();
        }
    }

    public void OpenAdd(SectorDisplay display) {
        currentDisplay = display;

        base.OpenPanel();
    }

    public void CreateSector() {
        Sector newSector = new Sector(market, market.products[dropdown.value]);
        Company.currentBranch.sectors.Add(newSector);
        
        currentDisplay.SetSector(newSector);
        currentDisplay.UpdateStatus();
        currentDisplay = null;

        GameObject newInstance = Instantiate(sectorDisplay);
        newInstance.transform.SetParent(sectorsUI.transform);
        newInstance.transform.localScale = Vector3.one;
        SectorDisplay display = newInstance.GetComponent<SectorDisplay>();
        display.UpdateStatus();

        ClosePanel();
    }
}