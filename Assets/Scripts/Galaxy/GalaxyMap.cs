using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyMap : MonoBehaviour {
    public static GalaxyMap instance;
    private List<Galaxy> galaxies = new List<Galaxy>();
    private Dictionary<int,Dictionary<int,Galaxy>> galaxyMatrix = new Dictionary<int,Dictionary<int,Galaxy>>();

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void GenerateMap(Galaxy selectedGalaxy) {
        if (selectedGalaxy == null) {
            GenerateGalaxy(0,0);
        }
        else {
            GenerateAdjacentGalaxies(selectedGalaxy);
        }
    }

    private void GenerateGalaxy(int x, int y) {
        if (!galaxyMatrix.ContainsKey(x)) {
            galaxyMatrix.Add(x,new Dictionary<int, Galaxy>());
        }

        if (!galaxyMatrix[x].ContainsKey(y)) {
            Galaxy newGalaxy = new Galaxy(galaxies.Count, x, y);
            galaxies.Add(newGalaxy);
            galaxyMatrix[x].Add(y,newGalaxy);

            GalaxyMapDisplay.instance.AddGalaxy(newGalaxy);
        }
    }

    private void GenerateAdjacentGalaxies(Galaxy selectedGalaxy) {
        int x = selectedGalaxy.GetPositionX();
        int y = selectedGalaxy.GetPositionY();

        GenerateGalaxy(x+1,y); //Galáxia para direita
        GenerateGalaxy(x-1,y); //Galáxia para esquerda
        GenerateGalaxy(x,y+1); //Galáxia para cima
        GenerateGalaxy(x,y-1); //Galáxia para baixo
    }

    #region Get Functions

        public List<Galaxy> GetGalaxies() {
            return galaxies;
        }

        public Galaxy GetGalaxy(int id) {
            return galaxies[id];
        }

    #endregion

}