using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Universe {
    private static List<Galaxy> galaxies = new List<Galaxy>();
    private static Dictionary<int,Dictionary<int,Galaxy>> galaxyMatrix = new Dictionary<int,Dictionary<int,Galaxy>>();

    private static int marketUpdateCounter;

    public static void Update() {
        if (marketUpdateCounter <= 0) {
            marketUpdateCounter = new TimeConverter(0, 0, 1, 0).GetCounter();
        }
        marketUpdateCounter--;

        foreach (Galaxy galaxy in galaxies) {
            galaxy.Update();
        }
    }

    public static void Reset() {
        galaxies.Clear();
        galaxyMatrix.Clear();
    }

    public static void Load(UniverseData universeData) {
        Reset();

        foreach (GalaxyData galaxyData in universeData.GetGalaxies()) {
            Galaxy galaxy = new Galaxy(galaxyData);
            galaxies.Add(galaxy);

            if (!galaxyMatrix.ContainsKey(galaxy.GetX())) {
                galaxyMatrix.Add(galaxy.GetX(),new Dictionary<int, Galaxy>());
            }

            if (!galaxyMatrix[galaxy.GetX()].ContainsKey(galaxy.GetY())) {
                galaxyMatrix[galaxy.GetX()].Add(galaxy.GetY(),galaxy);
            }
        }
    }

    #region Generate Methods

        public static void Generate() {
            GenerateGalaxy(0,0);
        }
        
        public static void Generate(Galaxy selectedGalaxy) {
            GenerateAdjacentGalaxies(selectedGalaxy);
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

                float newGalaxyPositionX = newGalaxy.GetX()*1500 + randomOffsetX;
                float newGalaxyPositionY = newGalaxy.GetY()*1500 + randomOffsetY;

                newGalaxy.SetPosition(new Vector3(newGalaxyPositionX, newGalaxyPositionY, 0f));

                galaxies.Add(newGalaxy);
                galaxyMatrix[x].Add(y,newGalaxy);
            }
        }

        private static void GenerateAdjacentGalaxies(Galaxy selectedGalaxy) {
            int x = selectedGalaxy.GetX();
            int y = selectedGalaxy.GetY();

            GenerateGalaxy(x+1,y); //Galáxia para direita
            GenerateGalaxy(x-1,y); //Galáxia para esquerda
            GenerateGalaxy(x,y+1); //Galáxia para cima
            GenerateGalaxy(x,y-1); //Galáxia para baixo
        }

    #endregion

    #region Getters

        public static int GetMarketUpdateCounter() {
            return marketUpdateCounter;
        }

        public static List<Galaxy> GetGalaxies() {
            return galaxies;
        }

        public static Galaxy GetGalaxies(int index) {
            return galaxies[index];
        }

    #endregion

}