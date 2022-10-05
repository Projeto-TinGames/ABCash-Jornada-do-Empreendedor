using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public CompanyData company;
    public GalaxyMapData galaxyMap;
    public string scene;
    //public int timePlayed;

    public SaveData() {
        this.company = new CompanyData();
        this.galaxyMap = new GalaxyMapData();
        this.scene = SceneController.instance.currentScene;
    }
}
