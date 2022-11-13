using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UniverseData {
    [SerializeField]private List<GalaxyData> galaxies = new List<GalaxyData>();

    public UniverseData() {
        foreach (Galaxy galaxy in Universe.GetGalaxies()) {
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
