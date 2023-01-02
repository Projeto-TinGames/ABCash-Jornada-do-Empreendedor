using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SectorUI : MonoBehaviour {
    [System.NonSerialized]public static UnityEvent<Sector> chooseSectorEvent = new UnityEvent<Sector>();

    [SerializeField]private TextMeshProUGUI branchTitle;
    [SerializeField]private Transform sectorContainer;
    [SerializeField]private GameObject sectorMenu;
    [SerializeField]private SectorDisplay sectorDisplay;
    [SerializeField]private GameObject addDisplay;

    private Branch currentBranch;
    private List<SectorDisplay> sectorDisplayList = new List<SectorDisplay>();

    private void Awake() {
        chooseSectorEvent.AddListener(OpenMenu);
    }

    private void Start() {
        currentBranch = Company.GetCurrentBranch();
        branchTitle.text = $"Setores da Filial {currentBranch.GetName()}";

        foreach (Sector sector in currentBranch.GetSectors()) {
            SectorDisplay display = Instantiate(sectorDisplay);

            display.SetSector(sector);

            display.transform.SetParent(sectorContainer);
            display.transform.localScale = Vector3.one;

            sectorDisplayList.Add(display);
        }

        if (sectorDisplayList.Count == 6) {
            addDisplay.SetActive(false);
        }
        else {
            addDisplay.transform.SetAsLastSibling();
        }
    }

    public void OpenMenu(Sector sector) {
        currentBranch.SetCurrentSector(sector);
        sectorMenu.SetActive(true);
    }

    public void RemoveSector() {
        currentBranch.RemoveSector();
        SceneController.instance.Load("sc_branch");
    }

    public void CloseMenu() {
        currentBranch.SetCurrentSector(null);
        sectorMenu.SetActive(false);
    }

    public void CloseBranch() {
        currentBranch.SetCurrentSector(null);
        Company.SetCurrentBranchId(-1);
        SceneController.instance.Load("sc_universe");
    }
}