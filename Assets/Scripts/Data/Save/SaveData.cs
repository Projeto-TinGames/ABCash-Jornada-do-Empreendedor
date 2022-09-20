using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public CompanyData company;
    public GalaxyMapData galaxyMap;
    public string scene;

    public SaveData() {
        this.company = new CompanyData(Company.instance);
        this.galaxyMap = new GalaxyMapData(GalaxyMap.instance);
        this.scene = SceneController.instance.currentScene;
    }
}
