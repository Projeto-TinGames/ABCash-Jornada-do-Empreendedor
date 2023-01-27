using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalaryUI : MonoBehaviour {
    [SerializeField]private Transform benefitList;

    [SerializeField]private TextMeshProUGUI benefitPrefab;
    [SerializeField]private TextMeshProUGUI finalSalary;

    private void Start() {
        gameObject.SetActive(false);
    }

    private void OnEnable() {
        Salary salary = AlienUI.GetAlien().GetSalary();

        foreach (Transform child in benefitList) {
            Destroy(child.gameObject);
        }

        foreach (Benefit benefit in salary.GetBenefits()) {
            TextMeshProUGUI benefitText = Instantiate(benefitPrefab);
            benefitText.transform.SetParent(benefitList);
            benefitText.transform.localScale = Vector3.one;

            benefitText.text = $"+ {benefit.GetName()}: {benefit.GetValue().ToString("C2")}";
        }

        finalSalary.text = $"Salário Final: {salary.GetFinal().ToString("C2")}";
    }
}
