using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseDisplay : MonoBehaviour {
    public static UniverseDisplay instance;
    public static bool isSelectingGalaxy;

    [SerializeField]private GameObject navMenu;
    [SerializeField]private GameObject galaxy;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        transform.SetAsFirstSibling();
        
        if (Universe.GetGalaxies().Count == 0) {
            Universe.Generate();
        }
        LoadMap();

        if (!isSelectingGalaxy) {
            navMenu.SetActive(true);
        }
        isSelectingGalaxy = false;
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
    }

    public void AddGalaxy(Galaxy newGalaxy) {
        GameObject newDisplay = Instantiate(galaxy);
        newDisplay.transform.SetParent(transform);
        newDisplay.transform.localPosition = newGalaxy.GetPosition();
        newDisplay.transform.localScale = Vector3.one;
        
        GalaxyDisplay galaxyDisplay = newDisplay.GetComponent<GalaxyDisplay>();
        galaxyDisplay.SetGalaxy(newGalaxy);
        galaxyDisplay.LoadButton();
    }

    #region Getters

        public static bool GetIsSelectingGalaxy() {
            return isSelectingGalaxy;
        }

    #endregion

    #region Setters

        public static void SetIsSelectingGalaxy(bool value) {
            isSelectingGalaxy = value;
        }

    #endregion
}