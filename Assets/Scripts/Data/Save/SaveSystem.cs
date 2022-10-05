using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour {
    private string filePath;
    private UnityEvent<string> FinishLoadEvent = new UnityEvent<string>();

    private void Start() {
        filePath = Application.persistentDataPath + "/save" + Company.id + ".json";
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            SaveData saveData = new SaveData();
            string dataAsJson = JsonUtility.ToJson(saveData,true);
            DataManager.instance.Save(filePath, dataAsJson);
        }
    }
}