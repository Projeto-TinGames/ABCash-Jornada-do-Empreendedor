using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SaveDisplay : MonoBehaviour {
    [SerializeField]private int saveID;
    private SaveData saveData;

    private string dataAsJson;
    private string filePath;
    private UnityEvent<string> FinishLoadEvent = new UnityEvent<string>();

    [SerializeField]private GameObject newGameText;
    [SerializeField]private GameObject dataUI;
    [SerializeField]private Button deleteButton;
    [SerializeField]private TextMeshProUGUI companyName;
    [SerializeField]private TextMeshProUGUI moneyText;
    [SerializeField]private TextMeshProUGUI timeText;

    private void Awake() {
        filePath = Application.persistentDataPath + "/save" + saveID + ".json";
    }

    private void Start() {
        FinishLoadEvent.AddListener(FinishLoad);
        DataManager.instance.Load(filePath, FinishLoadEvent);
    }

    private void Update() {
        if (!Company.GetIsLoading() && saveData != null) {
            SceneController.instance.Load(saveData.GetScene());
        }
    }

    public void StartGame() {
        Company.SetId(saveID);

        if (dataAsJson != string.Empty) {
            saveData = JsonUtility.FromJson<SaveData>(dataAsJson);

            Universe.Load(saveData.GetGalaxyMap());
            Company.Load(saveData.GetCompany());
        }
        else {
            SceneController.instance.Load("sc_company_creation");
        }
    }

    public void DeleteFile() {
        DataManager.instance.Save(filePath, string.Empty);
        FinishLoad(string.Empty);
    }

    private void FinishLoad(string data) {
        dataAsJson = data;

        if (dataAsJson != string.Empty) {
            SaveData saveData = JsonUtility.FromJson<SaveData>(dataAsJson);

            newGameText.SetActive(false);
            dataUI.SetActive(true);
            deleteButton.gameObject.SetActive(true);
            companyName.text = saveData.GetCompany().GetName();
            moneyText.text = saveData.GetCompany().GetMoney().ToString("C2");
            timeText.text = "";
        }
        else {
            newGameText.SetActive(true);
            deleteButton.gameObject.SetActive(false);
            dataUI.SetActive(false);
        }
    }
    
}
