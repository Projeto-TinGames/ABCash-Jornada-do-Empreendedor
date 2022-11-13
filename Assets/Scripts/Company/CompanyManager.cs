using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyManager : MonoBehaviour {
    [SerializeField]private TextMeshProUGUI moneyText;

    private void Start() {
        InvokeRepeating("UpdateCompany", 1f, 1f);
    }

    private void UpdateCompany() {
        foreach (KeyValuePair<int, Branch> branch in Company.GetBranches()) {
            foreach (Sector sector in branch.Value.GetSectors()) {
                sector.Produce();
            }
        }

        moneyText.text = Company.GetMoney().ToString("C2");
    }
}
