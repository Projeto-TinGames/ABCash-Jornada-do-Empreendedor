using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyMapDisplay : MonoBehaviour {
    public static GalaxyMapDisplay instance;

    public GameObject galaxy;

    private void Awake() {

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void UpdateDisplay(Galaxy newGalaxy) {
        float newGalaxyPositionX = transform.position.x + 200*newGalaxy.GetPositionX();
        float newGalaxyPositionY = transform.position.y + 200*newGalaxy.GetPositionY();

        Vector3 newGalaxyPosition = new Vector3(newGalaxyPositionX, newGalaxyPositionY, 0f);
        GameObject newDisplay = Instantiate(galaxy, newGalaxyPosition, Quaternion.identity, gameObject.transform);

        GalaxyDisplay galaxyDisplay = newDisplay.GetComponent<GalaxyDisplay>();
        galaxyDisplay.SetGalaxy(newGalaxy);
    }
}