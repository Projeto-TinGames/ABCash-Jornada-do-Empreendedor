using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public string scene;
    public CompanyData company;
    public GalaxyMapData galaxyMap;

    public SaveData() {
        this.scene = SceneController.instance.currentScene;
        this.company = new CompanyData(Company.instance);
        this.galaxyMap = new GalaxyMapData(GalaxyMap.instance);
    }
}
