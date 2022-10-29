using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyCreationMenu : MonoBehaviour {
    [SerializeField]private TMP_InputField nameField;

    public void CreateCompany() {
        Company.SetName(nameField.text);

        SceneController.instance.Load("sc_galaxyMap");
    }
}
