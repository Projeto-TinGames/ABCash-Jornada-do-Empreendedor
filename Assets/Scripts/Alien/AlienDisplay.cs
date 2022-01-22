using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienDisplay : MonoBehaviour {
    public Image image;
    public TextMeshProUGUI name;
    public TextMeshProUGUI race;
    public TextMeshProUGUI age;
    public TextMeshProUGUI rank;
    public TextMeshProUGUI exigence;
    public TextMeshProUGUI agility;
    public TextMeshProUGUI knowledge;
    public Alien alien;

    void Start() {
        RefreshDisplay();
    }

    public void RefreshDisplay() {
        image.sprite = alien.stats.sprite;
        image.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1F));

        name.text = "Nome: " + alien.stats.name;
        race.text = "Raça: " + alien.stats.race;
        age.text = "Idade: " + alien.stats.age.ToString();
        rank.text = "Rank: " + alien.stats.rank.ToString();
        exigence.text = "Exigência: " + alien.stats.exigence.ToString();
        agility.text = "Agilidade: " + alien.stats.agility.ToString();
        knowledge.text = "Conhecimento: " + alien.stats.knowledge.ToString();
    }
}
