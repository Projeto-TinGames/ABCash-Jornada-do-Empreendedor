using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxyMapData {
    public List<GalaxyData> galaxies = new List<GalaxyData>();

    public GalaxyMapData() {
        foreach (Galaxy galaxy in GalaxyMap.galaxies) {
            galaxies.Add(new GalaxyData(galaxy));
        }
    }
}
