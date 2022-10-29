using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    private void Start() {
        ProductManager.Load();
    }

    public void Quit() {
        Application.Quit();
    }

}
