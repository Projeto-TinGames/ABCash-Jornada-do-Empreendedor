using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Galaxy {
    private string[] possibleNames = {"a", "b", "c", "d", "e"};

    public string name;
    public int id;
    public int x;
    public int y;
    public bool hasBranch;
    public Vector3 position;
    public Market market;

    public Galaxy(int id, int x, int y) {
        this.id = id;
        this.x = x;
        this.y = y;

        this.name = possibleNames[Random.Range(0,possibleNames.Length)];
        this.market = new Market();
    }

    public Galaxy(GalaxyData data) {
        this.name = data.name;
        this.id = data.id;
        this.x = data.x;
        this.y = data.y;
        this.hasBranch = data.hasBranch;
        this.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        market = new Market(data.market);
    }
}