using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField]private GameObject menu;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menu.SetActive(!menu.activeSelf);
        }        
    }

    public void Save() {
        menu.SetActive(false);
        string filePath = Application.persistentDataPath + "/save" + Company.GetId() + ".json";

        SaveData saveData = new SaveData();
        string dataAsJson = JsonUtility.ToJson(saveData,true);
        DataManager.instance.Save(filePath, dataAsJson);
    }

    public void Quit() {
        menu.SetActive(false);
        SceneController.instance.Load("sc_menu");
        //Application.Quit();
    }
}
