using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BranchCreationUI : MonoBehaviour {
    private static int galaxyId;
    private static Sector sector;

    [SerializeField]private TextMeshProUGUI sectorName;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.setGalaxy.AddListener(SetGalaxy);
        EventHandlerUI.setSector.AddListener(SetSector);
    }

    private void Awake() {
        gameObject.AddComponent<FirstSiblingUI>();
    }

    private void Start() {
        if (sector == null) {
            sectorName.text = "Crie o primeiro setor...";
        }
        else {
            sectorName.text = sector.GetProduct().GetName();
        }
    }

    public void Select() {
        SectorUI.SetIsCreating(true);
        
        if (sector != null) {
            EventHandlerUI.setSector.Invoke(sector);
        }
        else {
            Product product = Company.GetProducts(0);
            Galaxy galaxy = Universe.GetGalaxies(galaxyId);
            EventHandlerUI.setSector.Invoke(new Sector(product,galaxy));
        }

        SectorUI.SetCloseScene("sc_branch_creation");
        SceneController.instance.Load("sc_sector");
    }

    public void Create() {
        Galaxy galaxy = Universe.GetGalaxies(galaxyId);
        Branch branch = new Branch(galaxy.GetId(), galaxy.GetName());
        branch.AddSector(sector);
        Company.AddBranch(new Branch(new BranchData(branch)));
        sector = null;

        Universe.Generate(Universe.GetGalaxies(branch.GetId()));

        EventHandlerUI.setBranch.Invoke(Company.GetBranches(branch.GetId()));
        NavUI.SetBranchScene("sc_branch");
        SceneController.instance.Load("sc_branch");
    }

    public void Close() {
        if (sector != null) {
            foreach (Alien alien in sector.GetAliens()) {
                if (alien != null) {
                    Company.AddAlien(alien);
                }
            }
            EventHandlerUI.setSector.Invoke(null);
        }
        
        NavUI.SetBranchScene("sc_universe");
        SceneController.instance.Load("sc_universe");
    }

    #region Setters

        private static void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

        private static void SetSector(Sector value) {
            sector = value;
        }

    #endregion
}
