using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class DataManager : MonoBehaviour {
    public static DataManager instance;

    #if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void SyncDB();
    #endif

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        ProductManager.Start();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.L)) { //Premade load for testing
            Company.Reset();
            Universe.Reset();

            Universe.Generate();
            Universe.Generate(Universe.GetGalaxies(0));

            Branch branch = new Branch(0, "0,0");
            branch.AddSector(new Sector(ProductManager.GetProducts(0), Universe.GetGalaxies(0)));
            branch.GetSectors(0).AddEmployee(new Wadop());
            branch.GetSectors(0).SetChief(new Dodal());

            Company.AddAlien(new Repinch());
            Company.AddBranch(branch);

            SceneController.instance.Load("sc_universe");
        }
    }
    
    public void Load(string filePath, UnityEvent<string> FinishLoadEvent) {
        string dataAsJson;

        #if UNITY_EDITOR
            if (File.Exists(filePath)) {
                dataAsJson = File.ReadAllText(filePath);
                FinishLoadEvent.Invoke(dataAsJson);
            }
            else {
                FinishLoadEvent.Invoke(string.Empty);
            }
        #endif

        #if UNITY_WEBGL && !UNITY_EDITOR
            if (File.Exists(filePath)) {
                dataAsJson = File.ReadAllText(filePath);
                FinishLoadEvent.Invoke(dataAsJson);
            }
            else {
                StartCoroutine(WebGetRequest(filePath, FinishLoadEvent));
            }
        #endif
    }

    public void Save(string filePath, string dataAsJson) {
        File.WriteAllText(filePath, dataAsJson);

        #if UNITY_WEBGL && !UNITY_EDITOR
            SyncDB();
        #endif
    }

    private IEnumerator WebGetRequest(string filePath, UnityEvent<string> FinishLoadEvent) {
        UnityWebRequest webRequest = UnityWebRequest.Get(filePath);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ProtocolError) {
            Debug.LogError(webRequest.error);
            FinishLoadEvent.Invoke(string.Empty);
        }
        else {
            string dataAsJson = webRequest.downloadHandler.text;
            FinishLoadEvent.Invoke(dataAsJson);
        }
    }

    /*private IEnumerator WebPostRequest(string filePath, UnityEvent<string> FinishLoadEvent) {
        UnityWebRequest webRequest = UnityWebRequest.Get(filePath);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ProtocolError) {
            Debug.LogError(webRequest.error);
        }
        else {
            string dataAsJson = webRequest.downloadHandler.text;
            FinishLoadEvent.Invoke(dataAsJson);
        }
    }*/
}
