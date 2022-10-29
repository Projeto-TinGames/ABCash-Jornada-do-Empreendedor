using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyManager : MonoBehaviour {
    [SerializeField]private TextMeshProUGUI revenueText;

    private void FixedUpdate() {
        foreach (KeyValuePair<int, Branch> branch in Company.GetBranches()) {
            foreach (Sector sector in branch.Value.GetSectors()) {
                sector.Produce();
            }
        }

        revenueText.text = Company.GetRevenue().ToString("C2");
    }
}
