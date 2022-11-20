using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesUI : MonoBehaviour {
    [SerializeField]private GameObject navMenu;

    private void Start() {
        navMenu.SetActive(true);
    }
}