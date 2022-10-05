using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyManager : MonoBehaviour {
    [SerializeField]private TextMeshProUGUI revenueText;

    private void FixedUpdate() {
        foreach (KeyValuePair<int, Branch> branch in Company.branches) {
            foreach (Sector sector in branch.Value.sectors) {
                sector.Produce();
            }
        }

        revenueText.text = Company.revenue.ToString("C2");
    }
}
