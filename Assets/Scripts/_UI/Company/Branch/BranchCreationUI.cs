using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCreationUI : MonoBehaviour {
    private static int productId;
    private static int galaxyId;
    private static Sector sector;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.setProduct.AddListener(SetProduct);
        EventHandlerUI.setGalaxy.AddListener(SetGalaxy);
        EventHandlerUI.setSector.AddListener(SetSector);
    }

    private void Awake() {
        gameObject.AddComponent<FirstSiblingUI>();
    }

    public void Select() {
        SceneController.instance.Load("sc_sector");
    }

    public void Create() {
        NavUI.SetBranchScene("sc_branch");
        SceneController.instance.Load("sc_branch");
    }

    #region Setters

        private static void SetProduct(Product product) {
            productId = product.GetId();
        }

        private static void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

        private static void SetSector(Sector value) {
            sector = value;
        }

    #endregion
}
