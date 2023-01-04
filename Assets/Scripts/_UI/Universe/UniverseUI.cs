using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseUI : MonoBehaviour {
    [SerializeField]private GameObject galaxy;

    private void Start() {
        gameObject.AddComponent<FirstSiblingUI>();
        
        if (Universe.GetGalaxies().Count == 0) {
            Universe.Generate();
        }

        LoadMap();
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

    private void AddGalaxy(Galaxy newGalaxy) {
        GameObject newDisplay = Instantiate(galaxy);
        newDisplay.transform.SetParent(transform);
        newDisplay.transform.localPosition = newGalaxy.GetPosition();
        newDisplay.transform.localScale = Vector3.one;
        
        GalaxyDisplay galaxyDisplay = newDisplay.GetComponentInChildren<GalaxyDisplay>();
        galaxyDisplay.SetGalaxy(newGalaxy);
        galaxyDisplay.LoadButton();
    }
}