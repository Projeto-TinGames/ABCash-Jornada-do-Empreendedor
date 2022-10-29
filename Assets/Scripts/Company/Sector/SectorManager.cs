using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorManager : ProductDisplay {
    public static SectorManager instance;

    private Branch branch;
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
        branch = Company.GetCurrentBranch();
        SetMarket(branch.GetMarket());

        for (int i = 0; i < branch.GetSectors().Count + 1; i++) {
            GameObject newInstance = Instantiate(sectorDisplay);
            newInstance.transform.SetParent(sectorsUI.transform);
            newInstance.transform.localScale = Vector3.one;

            SectorDisplay display = newInstance.GetComponent<SectorDisplay>();

            if (i < branch.GetSectors().Count) {
                display.SetSector(branch.GetSectors(i));
            }
            display.UpdateStatus();
        }
    }

    public void OpenAdd(SectorDisplay display) {
        currentDisplay = display;

        base.OpenPanel();
    }

    public void CreateSector() {
        Sector newSector = new Sector(GetMarket(), GetMarket().GetProducts(GetDropdown().value));
        branch.AddSector(newSector);
        
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