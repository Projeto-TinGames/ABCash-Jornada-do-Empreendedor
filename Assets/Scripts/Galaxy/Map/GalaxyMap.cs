using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GalaxyMap {
    public static List<Galaxy> galaxies = new List<Galaxy>();
    private static Dictionary<int,Dictionary<int,Galaxy>> galaxyMatrix = new Dictionary<int,Dictionary<int,Galaxy>>();

    public static void Load(GalaxyMapData mapData) {
        galaxies.Clear();
        galaxyMatrix.Clear();

        foreach (GalaxyData galaxyData in mapData.galaxies) {
            Galaxy galaxy = new Galaxy(galaxyData);
            galaxies.Add(galaxy);

            if (!galaxyMatrix.ContainsKey(galaxy.x)) {
                galaxyMatrix.Add(galaxy.x,new Dictionary<int, Galaxy>());
            }

            if (!galaxyMatrix[galaxy.x].ContainsKey(galaxy.y)) {
                galaxyMatrix[galaxy.x].Add(galaxy.y,galaxy);
            }
        }
    }

    public static void GenerateMap(Galaxy selectedGalaxy) {
        if (selectedGalaxy == null) {
            GenerateGalaxy(0,0);
        }
        else {
            GenerateAdjacentGalaxies(selectedGalaxy);
        }
    }

    private static void GenerateGalaxy(int x, int y) {
        if (!galaxyMatrix.ContainsKey(x)) {
            galaxyMatrix.Add(x,new Dictionary<int, Galaxy>());
        }

        if (!galaxyMatrix[x].ContainsKey(y)) {
            Galaxy newGalaxy = new Galaxy(galaxies.Count, x, y);

            float randomOffsetX = Random.Range(-500, 500);
            float randomOffsetY = Random.Range(-500, 500);

            if (galaxies.Count == 0) {
                randomOffsetX = randomOffsetY = 0;
            }

            float newGalaxyPositionX = newGalaxy.x*1500 + randomOffsetX;
            float newGalaxyPositionY = newGalaxy.y*1500 + randomOffsetY;

            newGalaxy.position = new Vector3(newGalaxyPositionX, newGalaxyPositionY, 0f);

            galaxies.Add(newGalaxy);
            galaxyMatrix[x].Add(y,newGalaxy);

            if (GalaxyMapDisplay.instance != null) {
                GalaxyMapDisplay.instance.AddGalaxy(newGalaxy);
            }
        }
    }

    private static void GenerateAdjacentGalaxies(Galaxy selectedGalaxy) {
        int x = selectedGalaxy.x;
        int y = selectedGalaxy.y;

        GenerateGalaxy(x+1,y); //Galáxia para direita
        GenerateGalaxy(x-1,y); //Galáxia para esquerda
        GenerateGalaxy(x,y+1); //Galáxia para cima
        GenerateGalaxy(x,y-1); //Galáxia para baixo
    }

}