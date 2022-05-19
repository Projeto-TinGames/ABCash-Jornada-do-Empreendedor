using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienContract : MonoBehaviour {
    private Company company;

    private Alien[] aliens;
    private Alien activeAlien;
    [SerializeField]private AlienDisplay display;

    [SerializeField]private Button acceptButton;
    [SerializeField]private Button rejectButton;

    private void Awake() {
        aliens = GetComponentsInChildren<Alien>();
        foreach (Alien alien in aliens) {
            alien.gameObject.SetActive(false);
        }

        GenerateRandomAlien();
    }

    private void Start() {
        company = Company.instance;

        acceptButton.interactable = false;
        rejectButton.interactable = false;

        acceptButton.onClick.AddListener(Accept);
        rejectButton.onClick.AddListener(Reject);

        acceptButton.interactable = true;
        rejectButton.interactable = true;
    }

    public void GenerateRandomAlien() {
        if (activeAlien != null) {
            activeAlien.gameObject.SetActive(false);
        }

        activeAlien = aliens[Random.Range(0,aliens.Length)];
        activeAlien.gameObject.SetActive(true);
        activeAlien.GenerateStats();

        display.RefreshDisplay(activeAlien.stats);
    }

    private void Accept() {
        company.AddEmployee(activeAlien);
        GenerateRandomAlien();
    }

    private void Reject() {
        Debug.Log(activeAlien.GetType() + " Rejected");
        GenerateRandomAlien();
    }
}
