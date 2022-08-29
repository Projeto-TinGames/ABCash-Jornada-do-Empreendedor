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

    private void FixedUpdate() {
        float x = -Input.GetAxis("Horizontal")*10;
        float y = -Input.GetAxis("Vertical")*10;
        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, 0);
    }

    public void AddGalaxy(Galaxy newGalaxy) {
        GameObject newDisplay = Instantiate(galaxy, newGalaxy.position, Quaternion.identity, gameObject.transform);
        GalaxyDisplay galaxyDisplay = newDisplay.GetComponent<GalaxyDisplay>();
        galaxyDisplay.SetGalaxy(newGalaxy);
    }
}