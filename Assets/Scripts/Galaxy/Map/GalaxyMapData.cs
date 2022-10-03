using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxyMapData {
    public List<GalaxyData> galaxies = new List<GalaxyData>();

    public GalaxyMapData(GalaxyMap map) {
        foreach (Galaxy galaxy in map.galaxies) {
            galaxies.Add(new GalaxyData(galaxy));
        }
    }
}
