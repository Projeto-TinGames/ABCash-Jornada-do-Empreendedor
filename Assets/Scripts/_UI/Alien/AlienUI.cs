using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienUI : MonoBehaviour {
    private static int alienId;
    private static int galaxyId;

    private Alien alien;

    [SerializeField]private AlienDisplay displayPrefab;
    [SerializeField]private Transform alienList; 
    [SerializeField]private AlienDisplay contractDisplay; 

    [SerializeField]private TextMeshProUGUI galaxyName;
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

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.selectGalaxy.AddListener(SetGalaxy);
    }

    private void Start() {
        EventHandlerUI.setAlien.AddListener(UpdateInfo);
        aliens = Company.GetUnemployedAliens();

        if (galaxyName != null) {
            galaxyName.text = Universe.GetGalaxies(galaxyId).GetName();
        }
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

        int distance = Universe.GetDistance(galaxyValue, Universe.GetGalaxies(galaxyId));
        alien.SetFinalSalary(distance);

        alienName.text = alien.GetName();
        alienImage.sprite = alien.GetSprite();
        alienImage.color = alien.GetColor();
        alienGalaxy.text = $"Galáxia de Origem: {galaxyValue.GetName()}";
        alienProduct.text = $"Produto Favorito: {productValue.GetName()}";
        alienAgility.text = $"Agilidade: {alien.GetAgility().ToString()}";
        alienWisdom.text = $"Sabedoria: {alien.GetWisdom().ToString()}";
        alienSalary.text = $"Salário: {alien.GetFinalSalary().ToString()}/dia";
    }

    public void Contract() {
        Company.AddAlien(alien);
        UpdateList();

        //alienId = 1;
        //displayList[alienId].Click();
    }

    public void Select() {
        EventHandlerUI.selectAlien.Invoke(alien);
        alienId--;

        Close();
    }

    public void Close() {
        SceneController.instance.LoadPreviousScene();
    }

    public void SelectGalaxy() {
        SceneController.instance.Load("sc_universe_select");
    }

    public void test() {
        Debug.Log(alien.GetBaseSalary());;
    }

    #region Setters

        private static void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

    #endregion
}