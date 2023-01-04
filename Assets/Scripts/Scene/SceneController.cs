using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController instance;
    private string scene = "sc_universe";

    //[SerializeField]private Animator crossfade;
    //private float transitionTime = .2f;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Load(string scene) {
        this.scene = scene;
        SceneManager.LoadScene(scene);
        //StartCoroutine(LoadScene(scene));
    }

    /*private IEnumerator LoadScene(string scene) {
        crossfade.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(scene);
    }*/

    #region Getters

        public string GetScene() {
            return scene;
        }

    #endregion

    #region Setters

        public void SetScene(string value) {
            scene = value;
        }

    #endregion
}