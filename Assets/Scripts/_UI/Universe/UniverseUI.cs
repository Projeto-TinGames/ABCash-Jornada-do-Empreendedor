using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseUI : MonoBehaviour {
    [SerializeField]private bool select;
    [SerializeField]private GameObject galaxy;

    private int clickId;
    private static int galaxyId;

    private List<GalaxyDisplay> displayList = new List<GalaxyDisplay>();

    private void Awake() {
        EventHandlerUI.clickGalaxyDisplay.AddListener(ClickGalaxy);
        EventHandlerUI.setGalaxy.AddListener(SetGalaxy);
    }

    private void Start() {
        clickId = galaxyId;

        gameObject.AddComponent<FirstSiblingUI>();
        
        if (Universe.GetGalaxies().Count == 0) {
            Universe.Generate();
        }

        LoadMap();
    }

    private void Update() {
        displayList[clickId].Select();
    }

    private void FixedUpdate() {
        // Implementar limite de movimento com base em uma largura e altura da classe Universe
        float x = -Input.GetAxis("Horizontal")*10;
        float y = -Input.GetAxis("Vertical")*10;
        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, 0);
    }

    private void LoadMap() {
        foreach (Galaxy galaxy in Universe.GetGalaxies()) {
            AddGalaxy(galaxy);
        }

        transform.localPosition = -Universe.GetGalaxies(galaxyId).GetPosition();
    }

    private void AddGalaxy(Galaxy newGalaxy) {
        GameObject newDisplay = Instantiate(galaxy);
        newDisplay.transform.SetParent(transform);
        newDisplay.transform.localPosition = newGalaxy.GetPosition();
        newDisplay.transform.localScale = Vector3.one;
        
        GalaxyDisplay galaxyDisplay = newDisplay.GetComponentInChildren<GalaxyDisplay>();

        if (select) {
            galaxyDisplay.SetSelect(true);
        }

        galaxyDisplay.SetGalaxy(newGalaxy);

        displayList.Add(galaxyDisplay);
    }

    #region Setters

        private void ClickGalaxy(Galaxy galaxy) {
            displayList[clickId].Deselect();
            clickId = galaxy.GetId();
            transform.localPosition = -Universe.GetGalaxies(clickId).GetPosition();
        }

        private void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

    #endregion
}