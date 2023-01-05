using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController instance;
    private string scene;
    private string previousScene;

    //[SerializeField]private Animator crossfade;
    //private float transitionTime = .2f;

    private void Awake() {
        if (instance == null) {
            instance = this;
            scene = string.Copy(SceneManager.GetActiveScene().name);
            previousScene = string.Copy(SceneManager.GetActiveScene().name);

            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Load(string scene) {
        this.previousScene = string.Copy(this.scene);
        this.scene = string.Copy(scene);
        SceneManager.LoadScene(scene);
        //StartCoroutine(LoadScene(scene));
    }

    /*private IEnumerator LoadScene(string scene) {
        crossfade.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(scene);
    }*/

    public void LoadPreviousScene() {
        Load(string.Copy(previousScene));
    }

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