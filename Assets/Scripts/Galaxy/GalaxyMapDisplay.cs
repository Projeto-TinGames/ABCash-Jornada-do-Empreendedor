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
        float randomOffsetX = Random.Range(250, 500);
        float randomOffsetY = Random.Range(250, 500);
        float newGalaxyPositionX = transform.position.x + 750*newGalaxy.GetPositionX() + randomOffsetX*newGalaxy.GetPositionY();
        float newGalaxyPositionY = transform.position.y + 750*newGalaxy.GetPositionY() + randomOffsetY*newGalaxy.GetPositionX();

        Vector3 newGalaxyPosition = new Vector3(newGalaxyPositionX, newGalaxyPositionY, 0f);
        GameObject newDisplay = Instantiate(galaxy, newGalaxyPosition, Quaternion.identity, gameObject.transform);

        GalaxyDisplay galaxyDisplay = newDisplay.GetComponent<GalaxyDisplay>();
        galaxyDisplay.SetGalaxy(newGalaxy);
    }
}