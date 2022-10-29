using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SaveSlot : MonoBehaviour {
    [SerializeField]private int saveID;

    private string dataAsJson;
    private string filePath;
    private UnityEvent<string> FinishLoadEvent = new UnityEvent<string>();

    [SerializeField]private GameObject newGameText;
    [SerializeField]private GameObject dataUI;
    [SerializeField]private Button deleteButton;
    [SerializeField]private TextMeshProUGUI companyName;
    [SerializeField]private TextMeshProUGUI revenueText;
    [SerializeField]private TextMeshProUGUI timeText;

    public void StartGame() {
        Company.SetId(saveID);

        if (dataAsJson != string.Empty) {
            SaveData saveData = JsonUtility.FromJson<SaveData>(dataAsJson);

            GalaxyMap.Load(saveData.GetGalaxyMap());
            Company.Load(saveData.GetCompany());
            SceneController.instance.Load(saveData.GetScene());
        }
        else {
            SceneController.instance.Load("sc_companyCreation");
        }
    }

    public void DeleteFile() {
        DataManager.instance.Save(filePath, string.Empty);
        FinishLoad(string.Empty);
    }

    private void Awake() {
        filePath = Application.persistentDataPath + "/save" + saveID + ".json";
    }

    private void Start() {
        FinishLoadEvent.AddListener(FinishLoad);
        DataManager.instance.Load(filePath, FinishLoadEvent);
    }

    private void FinishLoad(string data) {
        dataAsJson = data;

        if (dataAsJson != string.Empty) {
            SaveData saveData = JsonUtility.FromJson<SaveData>(dataAsJson);

            newGameText.SetActive(false);
            dataUI.SetActive(true);
            deleteButton.gameObject.SetActive(true);
            companyName.text = saveData.GetCompany().GetName();
            revenueText.text = saveData.GetCompany().GetRevenue().ToString("C2");
            timeText.text = "";
        }
        else {
            newGameText.SetActive(true);
            deleteButton.gameObject.SetActive(false);
            dataUI.SetActive(false);
        }
    }
    
}
