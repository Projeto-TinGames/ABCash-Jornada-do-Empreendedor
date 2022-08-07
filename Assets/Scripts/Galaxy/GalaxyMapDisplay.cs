using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyMapDisplay : MonoBehaviour {
    public static GalaxyMapDisplay instance;
    private GalaxyMap galaxyMap;

    public GameObject galaxy;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        galaxyMap = GalaxyMap.instance;
    }

    private void GenerateGalaxies(int id, GalaxyDisplay galaxyDisplay) {
        Vector3 galaxyPosition = galaxyDisplay.transform.position;

        if (galaxyDisplay.GetDirection() != Direction.Up) {
            galaxyMap.AddGalaxy();
            Vector3 newPosition = galaxyPosition;
            newPosition.y += 200;
            GenerateGalaxy(id, newPosition, Direction.Down);
            id += 1;
        }

        if (galaxyDisplay.GetDirection() != Direction.Down) {
            galaxyMap.AddGalaxy();
            Vector3 newPosition = galaxyPosition;
            newPosition.y -= 200;
            GenerateGalaxy(id, newPosition, Direction.Up);
            id += 1;
        }

        if (galaxyDisplay.GetDirection() != Direction.Right) {
            galaxyMap.AddGalaxy();
            Vector3 newPosition = galaxyPosition;
            newPosition.x += 200;
            GenerateGalaxy(id, newPosition, Direction.Left);
            id += 1;
        }

        if (galaxyDisplay.GetDirection() != Direction.Left) {
            galaxyMap.AddGalaxy();
            Vector3 newPosition = galaxyPosition;
            newPosition.x -= 200;
            GenerateGalaxy(id, newPosition, Direction.Right);
        }
    }

    private void GenerateGalaxy(int i, Vector3 position, Direction direction) {
        GameObject newGalaxy = Instantiate(galaxy, position, Quaternion.identity, gameObject.transform);
        GalaxyDisplay galaxyDisplay = newGalaxy.GetComponent<GalaxyDisplay>();
        galaxyDisplay.SetGalaxy(galaxyMap.GetGalaxy(i));
        galaxyDisplay.SetDirection(direction);
    }

    public void GenerateMap(GalaxyDisplay galaxyDisplay) {
        int galaxiesLength = galaxyMap.GetGalaxies().Count;
        Debug.Log(galaxiesLength);

        if (galaxyDisplay == null) {
            GenerateGalaxy(galaxiesLength-1, transform.position, Direction.Center);
        }
        else {
            GenerateGalaxies(galaxiesLength, galaxyDisplay);
        }
    }
}