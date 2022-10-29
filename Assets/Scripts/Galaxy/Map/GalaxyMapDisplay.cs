using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyMapDisplay : MonoBehaviour {
    public static GalaxyMapDisplay instance;
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
        if (GalaxyMap.GetGalaxies().Count == 0) {
            GalaxyMap.GenerateMap(null);
        }
        LoadMap();
    }

    private void FixedUpdate() {
        float x = -Input.GetAxis("Horizontal")*10;
        float y = -Input.GetAxis("Vertical")*10;
        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, 0);
    }

    private void LoadMap() {
        foreach (Galaxy galaxy in GalaxyMap.GetGalaxies()) {
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
    }

}