using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxyData {
    public string name;
    public int id;
    public int x;
    public int y;
    public bool hasBranch;
    public float[] position;
    public MarketData market;

    public GalaxyData(Galaxy galaxy) {
        this.name = galaxy.name;
        this.id = galaxy.id;
        this.x = galaxy.x;
        this.y = galaxy.y;
        this.hasBranch = galaxy.hasBranch;
        this.position = new float[]{galaxy.position.x, galaxy.position.y, galaxy.position.z};
        this.market = new MarketData(galaxy.market);
    }
}
