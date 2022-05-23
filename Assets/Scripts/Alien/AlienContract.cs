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

    private static int cooldown;

    private void Awake() {
        aliens = GetComponentsInChildren<Alien>();
        foreach (Alien alien in aliens) {
            alien.gameObject.SetActive(false);
        }

        if (cooldown == 0) {
            GenerateRandomAlien();
        }
        else {
            display.gameObject.SetActive(false);
        }

    }

    private void Start() {
        company = Company.instance;

        acceptButton.onClick.AddListener(Accept);
        rejectButton.onClick.AddListener(Reject);

        ResetButtonsColors();
    }

    private void FixedUpdate() {
        UpdateCooldown();
    }

    private void ResetButtonsColors() {
        acceptButton.interactable = false;
        rejectButton.interactable = false;

        acceptButton.interactable = true;
        rejectButton.interactable = true;
    }

    private void StartCooldown() {
        cooldown = 1;
        display.gameObject.SetActive(false);
    }

    private void UpdateCooldown() {
        if (cooldown > 0) {
            cooldown++;
            if (cooldown >= 180) {
                EndCooldown();
            }
        }
    }

    private void EndCooldown() {
        cooldown = 0;
        display.gameObject.SetActive(true);
        ResetButtonsColors();
        GenerateRandomAlien();
    }

    private void GenerateRandomAlien() {
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
        StartCooldown();
    }

    private void Reject() {
        Debug.Log(activeAlien.GetType() + " Rejected");
        StartCooldown();
    }
}
