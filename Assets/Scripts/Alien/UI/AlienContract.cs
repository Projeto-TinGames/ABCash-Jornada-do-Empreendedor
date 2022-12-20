using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienContract : MonoBehaviour {
    private Alien alien;
    [SerializeField]private AlienInfo display;

    [SerializeField]private Button acceptButton;
    [SerializeField]private Button rejectButton;

    private static int cooldown;

    private void Start() {
        acceptButton.onClick.AddListener(Accept);
        rejectButton.onClick.AddListener(Reject);

        ResetButtonsColors();
        GenerateRandomAlien();
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
        AlienGenerator alienGenerator = new AlienGenerator();
        alien = alienGenerator.GetRandomAlien();
        alien.Work();

        //display.RefreshDisplay(alien);
    }

    private void Accept() {
        Company.AddAlien(alien);
        StartCooldown();
    }

    private void Reject() {
        StartCooldown();
    }
}