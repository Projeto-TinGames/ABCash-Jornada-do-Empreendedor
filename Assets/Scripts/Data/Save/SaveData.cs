using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    [SerializeField]private CompanyData company;
    [SerializeField]private GalaxyMapData galaxyMap;
    [SerializeField]private string scene;
    //[SerializeField]private int timePlayed;

    public SaveData() {
        this.company = new CompanyData();
        this.galaxyMap = new GalaxyMapData();
        this.scene = SceneController.instance.currentScene;
    }

    #region Getters

        public CompanyData GetCompany() {
            return company;
        }

        public GalaxyMapData GetGalaxyMap() {
            return galaxyMap;
        }

        public string GetScene() {
            return scene;
        }

    #endregion

    #region Setters

        public void SetCompany(CompanyData value) {
            company = value;
        }

        public void SetGalaxyMap(GalaxyMapData value) {
            galaxyMap = value;
        }

        public void SetScene(string value) {
            scene = value;
        }

    #endregion
}
