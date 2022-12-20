using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class AlienInfo : MonoBehaviour {
    public static UnityEvent<AlienDisplay> refreshInfo = new UnityEvent<AlienDisplay>();

    private Alien alien;
    private AlienDisplay alienDisplay;
    [SerializeField]private new TextMeshProUGUI name;
    [SerializeField]private Image image;
    [SerializeField]private TextMeshProUGUI galaxy;
    [SerializeField]private TextMeshProUGUI product;
    [SerializeField]private TextMeshProUGUI agility;
    [SerializeField]private TextMeshProUGUI wisdom;
    [SerializeField]private TextMeshProUGUI salary;
    [SerializeField]private GameObject contractButton;

    private void Awake() {
        refreshInfo.AddListener(RefreshInfo);
    }

    private void Update() {
        if (alienDisplay != null) {
            alienDisplay.Focus();
        }
    }

    private void RefreshInfo(AlienDisplay display) {
        alienDisplay = display;
        alien = alienDisplay.GetAlien();

        contractButton.SetActive(false);
        if (alien == null) {
            contractButton.SetActive(true);
            AlienGenerator generator = new AlienGenerator();
            alien = generator.GetRandomAlien();
        }

        Galaxy galaxyValue = Universe.GetGalaxies(alien.GetGalaxyId());
        Product productValue = ProductManager.GetProducts(alien.GetProductId());

        image.sprite = alien.GetSprite();
        image.color = alien.GetColor();

        name.text = alien.GetName();
        galaxy.text = $"Galáxia de Origem: {galaxyValue.GetName()}";
        product.text = $"Produto Favorito: {productValue.GetName()}";
        agility.text = $"Agilidade: {alien.GetAgility().ToString()}";
        wisdom.text = $"Sabedoria: {alien.GetWisdom().ToString()}";
        salary.text = $"Salário: {alien.GetSalary().ToString()}/dia";
    }

    public void Contract() {
        Company.AddAlien(alien);
        AlienList.refreshList.Invoke();
    }
}
