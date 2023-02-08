using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour {
    SaveData saveData;
    [SerializeField]private GameObject menu;

    private string filePath = Application.streamingAssetsPath + "/save" + Company.GetId() + ".json";

    private void Start() {
        menu.transform.SetAsLastSibling();
    }

    private void Update() {
        if (saveData != null && !saveData.GetCompany().GetIsLoading()) {
            string dataAsJson = JsonUtility.ToJson(saveData,true);
            DataManager.instance.Save(filePath, dataAsJson);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menu.SetActive(!menu.activeSelf);
        }        
    }

    public void Save() {
        menu.SetActive(false);

        saveData = new SaveData();
    }

    public void Quit() {
        menu.SetActive(false);
        SceneController.instance.Load("sc_menu");
        //Application.Quit();
    }
}
