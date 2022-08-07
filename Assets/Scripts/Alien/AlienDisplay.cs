using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienDisplay : MonoBehaviour {
    [SerializeField]private Image image;
    [SerializeField]private new TextMeshProUGUI name;
    [SerializeField]private TextMeshProUGUI species;
    [SerializeField]private TextMeshProUGUI planet;
    [SerializeField]private TextMeshProUGUI sector;
    [SerializeField]private TextMeshProUGUI age;
    [SerializeField]private TextMeshProUGUI rank;
    [SerializeField]private TextMeshProUGUI agility;
    [SerializeField]private TextMeshProUGUI knowledge;
    [SerializeField]private TextMeshProUGUI salary;

    public void RefreshDisplay(AlienStats stats) {
        image.sprite = stats.sprite;
        image.color = stats.color;

        name.text = stats.name;
        species.text = stats.species;
        planet.text = stats.planet;
        sector.text = stats.sector.ToString();
        age.text = stats.age.ToString();
        rank.text = stats.rank.ToString();
        agility.text = stats.agility.ToString();
        knowledge.text = stats.knowledge.ToString();
        salary.text = stats.salary.ToString()+"/mês";
    }
}
