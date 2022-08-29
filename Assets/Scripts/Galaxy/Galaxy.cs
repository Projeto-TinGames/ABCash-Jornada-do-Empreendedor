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
    public Vector3 position;
    public Market market;

    public Galaxy(int id, int x, int y) {
        this.id = id;
        this.x = x;
        this.y = y;

        this.name = possibleNames[Random.Range(0,possibleNames.Length)];
        this.market = new Market();
    }
}