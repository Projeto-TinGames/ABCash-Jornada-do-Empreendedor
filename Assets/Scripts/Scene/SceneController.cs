using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController instance;
    private string scene;
    private Stack<string> sceneStack = new Stack<string>();

    //[SerializeField]private Animator crossfade;
    //private float transitionTime = .2f;

    private void Awake() {
        if (instance == null) {
            instance = this;
            scene = string.Copy(SceneManager.GetActiveScene().name);

            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Load(string scene) {
        this.sceneStack.Push(string.Copy(this.scene));
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
        scene = sceneStack.Peek();
        SceneManager.LoadScene(sceneStack.Pop());
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