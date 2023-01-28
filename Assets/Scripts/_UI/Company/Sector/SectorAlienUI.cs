using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SectorAlienUI : AlienUI {
    new private static int alienId; 

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.selectAlien.AddListener(SelectAlien);
        EventHandlerUI.selectGalaxy.AddListener(SetGalaxy);
    }

    protected override void Start() {
        EventHandlerUI.setSectorAlien.AddListener(UpdateInfo);
        aliens = new List<Alien>(SectorUI.GetSector().GetAliens());
        base.Start();
    }

    protected override void Update() {
        if (alienId < displayList.Count) {
            displayList[alienId].Select();
        }
    }

    protected override void UpdateList() {
        displayList.Clear();
        base.UpdateList();

        foreach (Transform child in alienList) {
            child.SetAsFirstSibling();
        }

        if (alienId < displayList.Count) {
            displayList[alienId].Click();
        }
    }

    protected override void UpdateInfo(AlienDisplay alienDisplay) {
        alienId = alienDisplay.GetId();
        alien = alienDisplay.GetAlien();

        alienInfo.gameObject.SetActive(false);
        selectButton.gameObject.SetActive(false);

        if (alien != null) {
            alienInfo.gameObject.SetActive(true);
        }
        else {
            selectButton.gameObject.SetActive(true);
            return;
        }

        base.UpdateInfo(alienDisplay);
    }

    public void Change() {
        if (aliens[alienId] != null) {
            Company.AddAlien(aliens[alienId]);
        }
        SceneController.instance.Load("sc_employees_select");
    }

    private static void SelectAlien(Alien alien) {
        Company.EmployAlien(alien);
        SectorUI.GetSector().SetAliens(alienId, alien);
    }

    /*public static void ResetAliens() {
        alienId = 0;
    }*/

}