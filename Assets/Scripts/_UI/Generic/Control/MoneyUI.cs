using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour {
    private TextMeshProUGUI moneyText;

    private void Start() {
        moneyText = GetComponent<TextMeshProUGUI>();
        TimeManager.instance.UpdateUI.AddListener(UpdateText);

        UpdateText();
    }

    private void UpdateText() {
        moneyText.text = Company.GetMoney().ToString("C2");
    }
}
