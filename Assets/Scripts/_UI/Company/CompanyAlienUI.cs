using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompanyAlienUI : AlienUI {
    [SerializeField]private TextMeshProUGUI galaxyName;

    [SerializeField]private AlienDisplay contractDisplay; 
    [SerializeField]private GameObject contractButton;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.selectGalaxy.AddListener(SetGalaxy);
    }

    protected override void Start() {
        EventHandlerUI.setAlien.AddListener(UpdateInfo);
        aliens = Company.GetUnemployedAliens();

        if (galaxyName != null) {
            galaxyName.text = Universe.GetGalaxies(galaxyId).GetName();
        }
        base.Start();
    }

    protected override void UpdateList() {
        displayList.Clear();
        displayList.Add(contractDisplay);
        base.UpdateList();

        if (alienId < displayList.Count) {
            displayList[alienId].Click();
        }
    }

    protected override void UpdateInfo(AlienDisplay alienDisplay) {
        alienId = alienDisplay.GetId();
        alien = alienDisplay.GetAlien();

        contractButton.SetActive(false);

        if (selectButton != null) {
            selectButton.SetActive(false);
        }

        if (alien == null) {
            contractButton.SetActive(true);
            AlienGenerator generator = new AlienGenerator();
            alien = generator.GetRandomAlien();
        }
        else {
            if (selectButton != null) {
                selectButton.SetActive(true);
            }
        }

        base.UpdateInfo(alienDisplay);
    }

    public void Contract() {
        Company.AddAlien(alien);
        UpdateList();

        //displayList[alienId].Click();
    }

    public void Select() {
        EventHandlerUI.selectAlien.Invoke(alien);
        alienId--;

        Close();
    }

    public void Close() {
        SceneController.instance.LoadPreviousScene();
    }

    public void SelectGalaxy() {
        SceneController.instance.Load("sc_universe_select");
    }
}