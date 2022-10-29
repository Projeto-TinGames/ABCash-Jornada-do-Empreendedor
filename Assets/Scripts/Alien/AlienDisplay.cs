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
    [SerializeField]private TextMeshProUGUI wisdom;
    [SerializeField]private TextMeshProUGUI salary;

    public void RefreshDisplay(Alien alien) {
        image.sprite = alien.GetSprite();
        image.color = alien.GetColor();

        name.text = alien.GetName();
        species.text = alien.GetSpecies();
        planet.text = alien.GetPlanet();
        sector.text = alien.GetSector();
        age.text = alien.GetAge().ToString();
        rank.text = alien.GetRank().ToString();
        agility.text = alien.GetAgility().ToString();
        wisdom.text = alien.GetWisdom().ToString();
        salary.text = alien.GetSalary().ToString()+"/mês";
    }
}
