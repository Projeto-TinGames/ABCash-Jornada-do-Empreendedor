using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxyMapData {
    [SerializeField]private List<GalaxyData> galaxies = new List<GalaxyData>();

    public GalaxyMapData() {
        foreach (Galaxy galaxy in GalaxyMap.GetGalaxies()) {
            galaxies.Add(new GalaxyData(galaxy));
        }
    }

    #region Getters

        public List<GalaxyData> GetGalaxies() {
            return galaxies;
        }

        public GalaxyData GetGalaxies(int index) {
            return galaxies[index];
        }

    #endregion
}
