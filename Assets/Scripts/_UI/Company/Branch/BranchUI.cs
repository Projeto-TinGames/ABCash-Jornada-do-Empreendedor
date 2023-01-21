using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BranchUI : MonoBehaviour {
    private static Branch branch;

    [SerializeField]private TextMeshProUGUI branchTitle;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.setBranch.AddListener(SetBranch);
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

        branchTitle.text = $"Filial {branch.GetName()}";
    }

    public void Close() {
        NavUI.SetBranchScene("sc_universe");
        SceneController.instance.Load("sc_universe");
    }

    #region Setters

        private static void SetBranch(Branch value) {
            branch = value;
        }

    #endregion
}