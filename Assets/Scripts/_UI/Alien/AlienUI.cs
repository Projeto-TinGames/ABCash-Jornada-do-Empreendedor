using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienUI : MonoBehaviour {
    private static int alienId;

    private Alien alien;

    [SerializeField]private AlienDisplay displayPrefab;
    [SerializeField]private Transform alienList; 
    [SerializeField]private AlienDisplay contractDisplay; 

    [SerializeField]private Transform alienInfo; 
    [SerializeField]private TextMeshProUGUI alienName;
    [SerializeField]private Image alienImage;
    [SerializeField]private TextMeshProUGUI alienGalaxy;
    [SerializeField]private TextMeshProUGUI alienProduct;
    [SerializeField]private TextMeshProUGUI alienAgility;
    [SerializeField]private TextMeshProUGUI alienWisdom;
    [SerializeField]private TextMeshProUGUI alienSalary;
    [SerializeField]private GameObject contractButton; 
    [SerializeField]private GameObject selectButton; 

    private List<Alien> aliens = new List<Alien>();
    private List<AlienDisplay> displayList = new List<AlienDisplay>();

    private void Start() {
        EventHandlerUI.setAlien.AddListener(UpdateInfo);
        aliens = Company.GetUnemployedAliens();

        UpdateList();
    }

    private void Update() {
        displayList[alienId].Select();
    }

    private void UpdateList() {
        displayList.Clear();

        if (contractDisplay != null) {
            displayList.Add(contractDisplay);
        }

        for (int i = 1; i < alienList.childCount; i++) {
            Destroy(alienList.GetChild(i).gameObject);
        }

        for (int i = 0; i < aliens.Count; i++) {
            Alien alien = aliens[i];
            AlienDisplay display = Instantiate(displayPrefab);

            display.SetDisplay(displayList.Count, alien);

            display.transform.SetParent(alienList);
            display.transform.localScale = Vector3.one;

            displayList.Add(display);
        }

        displayList[alienId].Click();
    }

    private void UpdateInfo(AlienDisplay alienDisplay) {
        alienId = alienDisplay.GetId();
        alien = alienDisplay.GetAlien();

        contractButton.SetActive(false);

        if (selectButton != null) {
            selectButton.SetActive(false);
        }

        if (alien == null) {
            contractButton.SetActive(true);
            AlienGenerator generator = new AlienGenerator();
            alien = generator.GetRandomAlien();
        }
        else {
            if (selectButton != null) {
                selectButton.SetActive(true);
            }
        }

        Galaxy galaxyValue = Universe.GetGalaxies(alien.GetGalaxyId());
        Product productValue = ProductManager.GetProducts(alien.GetProductId());

        alienName.text = alien.GetName();
        alienImage.sprite = alien.GetSprite();
        alienImage.color = alien.GetColor();
        alienGalaxy.text = $"Galáxia de Origem: {galaxyValue.GetName()}";
        alienProduct.text = $"Produto Favorito: {productValue.GetName()}";
        alienAgility.text = $"Agilidade: {alien.GetAgility().ToString()}";
        alienWisdom.text = $"Sabedoria: {alien.GetWisdom().ToString()}";
        alienSalary.text = $"Salário: {alien.GetSalary().ToString()}/dia";
    }

    public void Contract() {
        Company.AddAlien(alien);
        UpdateList();

        //alienId = 1;
        //displayList[alienId].Click();
    }

    public void Select() {
        Alien alien = displayList[alienId].GetAlien();
        EventHandlerUI.selectAlien.Invoke(alien);
        alienId--;

        Close();
    }

    public void Close() {
        SceneController.instance.LoadPreviousScene();
    }
}