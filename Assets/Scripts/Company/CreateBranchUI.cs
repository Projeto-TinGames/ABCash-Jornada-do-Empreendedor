using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateBranchUI : MonoBehaviour {
    public static CreateBranchUI instance;

    private GalaxyDisplay currentDisplay;
    private Galaxy currentGalaxy;

    [SerializeField]private GameObject panel;
    [SerializeField]private TextMeshProUGUI galaxyName;
    [SerializeField]private TMP_Dropdown products;
    [SerializeField]private TextMeshProUGUI productValue;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        products.onValueChanged.AddListener(delegate {ChangeProductValue(products);});
    }

    public void OpenPanel(GalaxyDisplay display) {
        currentDisplay = display;
        currentGalaxy = display.GetGalaxy();

        galaxyName.text = $"Galáxia \n{currentGalaxy.GetPositionX()},{currentGalaxy.GetPositionY()}";
        products.AddOptions(currentGalaxy.GetMarket().GetProducts());

        panel.SetActive(true);
        ChangeProductValue(products);
    }

    public void ClosePanel() {
        panel.SetActive(false);
    }

    public void ChangeProductValue(TMP_Dropdown dropdown) {
        float percentage = currentGalaxy.GetMarket().GetValue(dropdown.value) * 100;

        if (percentage > 0) {
            productValue.color = Color.green;
        }
        else if (percentage < 0) {
            productValue.color = Color.red;
        }
        else {
            productValue.color = Color.yellow;
        }

        productValue.text = percentage.ToString() + "%";
    }

    public void CreateBranch() {
        Branch branch = new Branch(currentGalaxy.GetId(), currentGalaxy.GetMarket());
        branch.Test();
        Company.instance.AddBranch(branch);

        currentDisplay.CreateBranch();
        GalaxyMap.instance.GenerateMap(currentGalaxy);

        currentDisplay = null;
        currentGalaxy = null;
        
        ClosePanel();
    }

}