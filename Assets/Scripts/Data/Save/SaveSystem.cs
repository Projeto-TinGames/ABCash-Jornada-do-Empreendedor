using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour {
    private string filePath;
    private UnityEvent<string> FinishLoadEvent = new UnityEvent<string>();

    private void Start() {
        filePath = Application.persistentDataPath + "/save.json";
        FinishLoadEvent.AddListener(Load);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            DataManager.instance.Load(filePath, FinishLoadEvent);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            SaveData saveData = new SaveData();
            string dataAsJson = JsonUtility.ToJson(saveData,true);
            DataManager.instance.Save(filePath, dataAsJson);
        }
    }

    private void Load(string dataAsJson) {
        SaveData saveData = JsonUtility.FromJson<SaveData>(dataAsJson);

        GalaxyMap.instance.Load(saveData.galaxyMap);
        Company.instance.Load(saveData.company);
        //SceneController.instance.Load(saveData.scene);
        SceneController.instance.Load("sc_galaxyMap");
    }
}
