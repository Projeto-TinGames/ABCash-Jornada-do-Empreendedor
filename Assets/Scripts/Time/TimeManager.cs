using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour {
    public static TimeManager instance;

    private int playTimeCounter = 0;
    private float speed = 1f; 

    [System.NonSerialized]public UnityEvent UpdateUI = new UnityEvent();

    private void Awake() {
        if (instance == null) {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Pause();
        for (int i = 0; i < Company.GetCompTime(); i++) {
            UpdateGame();
        }
        Play();
    }

    public void UpdateGame() {
        Universe.Update();
        Company.Update();

        UpdateUI.Invoke();
        playTimeCounter++;
    }

    public void Play() {
        InvokeRepeating("UpdateGame", 1f, speed);
    }

    public void Pause() {
        CancelInvoke();
    }

    public void UpdateSpeed(float speed) {
        Pause();

        this.speed = 1f/speed;

        Play();
    }

    #region Getters

        public int GetPlayTimeCounter() {
            return playTimeCounter;
        }

    #endregion
}
