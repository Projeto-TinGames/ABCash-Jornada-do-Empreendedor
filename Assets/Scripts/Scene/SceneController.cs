using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController instance;

    [SerializeField]private Animator crossfade;
    private float transitionTime = .2f;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Load(string scene) {
        SceneManager.LoadScene(scene);
        //StartCoroutine(LoadScene(scene));
    }

    /*private IEnumerator LoadScene(string scene) {
        crossfade.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(scene);
    }*/

    

}