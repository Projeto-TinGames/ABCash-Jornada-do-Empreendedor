using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour {
    public static DataManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void LoadJSON(string filePath, UnityEvent<string> FinishLoadEvent) {
        #if UNITY_EDITOR
            string dataAsJson = File.ReadAllText(filePath);
            FinishLoadEvent.Invoke(dataAsJson);
        #endif

        #if UNITY_WEBGL && !UNITY_EDITOR
            StartCoroutine(WebGetRequest(filePath, FinishLoadEvent));
        #endif
    }

    private IEnumerator WebGetRequest(string filePath, UnityEvent<string> FinishLoadEvent) {
        UnityWebRequest webRequest = UnityWebRequest.Get(filePath);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ProtocolError) {
            Debug.LogError(webRequest.error);
        }
        else {
            string dataAsJson = webRequest.downloadHandler.text;
            FinishLoadEvent.Invoke(dataAsJson);
        }
    }
}
