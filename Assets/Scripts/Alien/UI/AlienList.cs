using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AlienList : MonoBehaviour {
    public static UnityEvent refreshList = new UnityEvent();
    private List<AlienDisplay> alienDisplayList = new List<AlienDisplay>();

    [SerializeField]private AlienDisplay contractDisplay;
    [SerializeField]private AlienDisplay alienDisplayPrefab;

    private void Awake() {
        refreshList.AddListener(RefreshList);
    }

    private void Start() {
        refreshList.Invoke();
    }

    private void RefreshList() {
        alienDisplayList.Clear();

        for (int i = 1; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (Alien alien in Company.GetAliens()) {
            AlienDisplay display = Instantiate(alienDisplayPrefab);

            display.SetAlien(alien);

            display.transform.SetParent(transform);
            display.transform.localScale = Vector3.one;

            alienDisplayList.Add(display);
        }

        if (alienDisplayList.Count > 0) {
            alienDisplayList[0].Select();
        }
        else {
            contractDisplay.Select();
        }
    }
}