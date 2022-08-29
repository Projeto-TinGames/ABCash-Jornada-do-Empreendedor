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

    public void RefreshDisplay(Alien alien) {
        image.sprite = alien.sprite;
        image.color = alien.color;

        name.text = alien.name;
        species.text = alien.species;
        planet.text = alien.planet;
        sector.text = alien.sector.ToString();
        age.text = alien.age.ToString();
        rank.text = alien.rank.ToString();
        agility.text = alien.agility.ToString();
        knowledge.text = alien.knowledge.ToString();
        salary.text = alien.salary.ToString()+"/mês";
    }
}
