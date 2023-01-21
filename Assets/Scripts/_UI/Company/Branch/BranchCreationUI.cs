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
        SceneController.instance.Load("sc_sector");
    }

    public void Create() {
        Galaxy galaxy = Universe.GetGalaxies(galaxyId);

        Branch branch = new Branch(galaxy.GetId(), galaxy.GetName());
        branch.AddSector(sector);

        Company.AddBranch(branch);

        sector = null;

        NavUI.SetBranchScene("sc_branch");
        SceneController.instance.Load("sc_branch");
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
