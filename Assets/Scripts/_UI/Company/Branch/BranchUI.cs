using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BranchUI : MonoBehaviour {
    private static bool adding;
    private static Branch branch;
    private List<SectorDisplay> sectorDisplayList = new List<SectorDisplay>();

    [SerializeField]private TextMeshProUGUI branchTitle;
    [SerializeField]private SectorDisplay sectorDisplay;
    [SerializeField]private GameObject addDisplay;
    [SerializeField]private Transform sectorContainer;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.setBranch.AddListener(SetBranch);
        EventHandlerUI.setSector.AddListener(SetSector);
    }

    private void Awake() {
        transform.SetAsFirstSibling();
    }

    private void Start() {
        if (branch == null) {
            if (Company.GetBranches().Count > 0) {
                branch = Company.GetBranches(0);
            }
            else {
                SceneController.instance.Load("sc_universe");
                return;
            }
        }

        LoadUI();
    }

    private void LoadUI() {
        branchTitle.text = $"Filial {branch.GetName()}";

        foreach (Sector sector in branch.GetSectors()) {
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

    public void AddSector() {
        adding = true;

        Product product = Company.GetProducts(0);
        Galaxy galaxy = Universe.GetGalaxies(branch.GetId());
        EventHandlerUI.setSector.Invoke(new Sector(product,galaxy));

        SectorUI.SetCloseScene("sc_branch");
        SceneController.instance.Load("sc_sector");
    }

    public void Close() {
        EventHandlerUI.setSector.Invoke(null);

        NavUI.SetBranchScene("sc_universe");
        SceneController.instance.Load("sc_universe");
    }

    #region Setters

        private static void SetBranch(Branch value) {
            branch = value;
        }

        private static void SetSector(Sector sector) {
            if (adding) {
                branch.AddSector(sector);
                adding = false;
            }
        }

    #endregion
}