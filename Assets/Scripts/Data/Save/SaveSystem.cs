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
            Debug.Log(saveData.company.branches.Count);
            string dataAsJson = JsonUtility.ToJson(saveData,true);
            DataManager.instance.Save(filePath, dataAsJson);
        }
    }

    private void Load(string dataAsJson) {
        Debug.Log(dataAsJson);
    }
}
