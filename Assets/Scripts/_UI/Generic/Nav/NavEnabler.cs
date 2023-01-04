using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavEnabler : MonoBehaviour {
    [SerializeField]private GameObject navMenu;

    private void Awake() {
        navMenu.SetActive(true);
    }
}
