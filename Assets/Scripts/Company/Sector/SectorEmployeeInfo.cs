using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SectorEmployeeInfo : MonoBehaviour {
    public static UnityEvent<SectorEmployeeDisplay> refreshInfo = new UnityEvent<SectorEmployeeDisplay>();

    private Alien alien;
    private SectorEmployeeDisplay alienDisplay;
    [SerializeField]private new TextMeshProUGUI name;
    [SerializeField]private Image image;
    [SerializeField]private TextMeshProUGUI galaxy;
    [SerializeField]private TextMeshProUGUI product;
    [SerializeField]private TextMeshProUGUI agility;
    [SerializeField]private TextMeshProUGUI wisdom;
    [SerializeField]private TextMeshProUGUI salary;
    [SerializeField]private GameObject removeButton;

    [SerializeField]private GameObject info;
    [SerializeField]private GameObject allocate;

    private void Awake() {
        refreshInfo.AddListener(RefreshInfo);
    }

    private void Update() {
        if (alienDisplay != null) {
            alienDisplay.Focus();
        }
    }

    private void RefreshInfo(SectorEmployeeDisplay display) {
        alienDisplay = display;
        SectorEmployees.SetCurrentEmployee(display.GetId());

        alien = alienDisplay.GetAlien();

        info.SetActive(false);
        allocate.SetActive(false);
        if (alien == null) {
            allocate.SetActive(true);
            return;
        }

        info.SetActive(true);

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
