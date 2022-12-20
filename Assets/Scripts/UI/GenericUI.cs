using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericUI : MonoBehaviour {
    [SerializeField]private GameObject navMenu;
    [SerializeField]private bool enableNav;

    private void Awake() {
        navMenu.SetActive(enableNav);
    }
}
