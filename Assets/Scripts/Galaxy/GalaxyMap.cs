using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {Center,Up,Down,Right,Left};

public class GalaxyMap : MonoBehaviour {
    public static GalaxyMap instance;
    private List<Galaxy> galaxies = new List<Galaxy>();

    /*DontDestroyOnLoad para as galáxias já geradas*/

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        AddGalaxy();
        GalaxyMapDisplay.instance.GenerateMap(null);
    }

    #region Get Functions

        public Galaxy GetGalaxy(int i) {
            return galaxies[i];
        }

        public List<Galaxy> GetGalaxies() {
            return galaxies;
        }

    #endregion

    #region Add Functions

        public void AddGalaxy() {
            galaxies.Add(new Galaxy(galaxies.Count));
        }

    #endregion
 
}