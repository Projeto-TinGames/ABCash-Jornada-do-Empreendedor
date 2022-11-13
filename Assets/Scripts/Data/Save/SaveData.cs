using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    [SerializeField]private CompanyData company;
    [SerializeField]private UniverseData universe;
    [SerializeField]private string scene;
    //[SerializeField]private int timePlayed;

    public SaveData() {
        this.company = new CompanyData();
        this.universe = new UniverseData();
        this.scene = SceneController.instance.currentScene;
    }

    #region Getters

        public CompanyData GetCompany() {
            return company;
        }

        public UniverseData GetGalaxyMap() {
            return universe;
        }

        public string GetScene() {
            return scene;
        }

    #endregion

    #region Setters

        public void SetCompany(CompanyData value) {
            company = value;
        }

        public void SetGalaxyMap(UniverseData value) {
            universe = value;
        }

        public void SetScene(string value) {
            scene = value;
        }

    #endregion
}
