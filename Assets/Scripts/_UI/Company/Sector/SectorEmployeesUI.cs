using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SectorEmployeesUI : MonoBehaviour {
    private static Alien[] aliens = null;
    private static int alienId;
    private static int galaxyId;

    [SerializeField]private AlienDisplay displayPrefab;
    [SerializeField]private Transform alienList; 

    [SerializeField]private Transform alienInfo; 
    [SerializeField]private TextMeshProUGUI alienName;
    [SerializeField]private Image alienImage;
    [SerializeField]private TextMeshProUGUI alienGalaxy;
    [SerializeField]private TextMeshProUGUI alienProduct;
    [SerializeField]private TextMeshProUGUI alienAgility;
    [SerializeField]private TextMeshProUGUI alienWisdom;
    [SerializeField]private TextMeshProUGUI alienSalary;
    [SerializeField]private GameObject selectButton;

    private List<AlienDisplay> displayList = new List<AlienDisplay>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoadRuntimeMethod() { //Loads events out of scene
        EventHandlerUI.selectAlien.AddListener(SelectAlien);
        EventHandlerUI.selectGalaxy.AddListener(SetGalaxy);
    }

    private void Start() {
        EventHandlerUI.setSectorAlien.AddListener(UpdateInfo);
        
        aliens = SectorUI.GetSector().GetAliens();

        UpdateList();
    }

    private void Update() {
        displayList[alienId].Select();
    }

    private void UpdateList() {
        displayList.Clear();

        for (int i = 1; i < alienList.childCount; i++) {
            Destroy(alienList.GetChild(i).gameObject);
        }

        for (int i = 0; i < aliens.Length; i++) {
            Alien alien = aliens[i];
            AlienDisplay display = Instantiate(displayPrefab);

            display.SetDisplay(i, alien);

            display.transform.SetParent(alienList);
            display.transform.localScale = Vector3.one;
            display.transform.SetAsFirstSibling();

            displayList.Add(display);
        }

        displayList[alienId].Click();
    }

    private void UpdateInfo(AlienDisplay alienDisplay) {
        alienId = alienDisplay.GetId();
        Alien alien = alienDisplay.GetAlien();

        alienInfo.gameObject.SetActive(false);
        selectButton.gameObject.SetActive(false);

        if (alien != null) {
            alienInfo.gameObject.SetActive(true);
        }
        else {
            selectButton.gameObject.SetActive(true);
            return;
        }

        Galaxy galaxyValue = Universe.GetGalaxies(alien.GetGalaxyId());
        Product productValue = ProductManager.GetProducts(alien.GetProductId());

        int distance = Universe.GetDistance(galaxyValue, Universe.GetGalaxies(galaxyId));

        alienName.text = alien.GetName();
        alienImage.sprite = alien.GetSprite();
        alienImage.color = alien.GetColor();
        alienGalaxy.text = $"Galáxia de Origem: {galaxyValue.GetName()}";
        alienProduct.text = $"Produto Favorito: {productValue.GetName()}";
        alienAgility.text = $"Agilidade: {alien.GetAgility().ToString()}";
        alienWisdom.text = $"Sabedoria: {alien.GetWisdom().ToString()}";
        alienSalary.text = $"Salário: {alien.GetSalary().GetFinal().ToString()}/dia";
    }

    public void Change() {
        SceneController.instance.Load("sc_employees_select");
    }

    private static void SelectAlien(Alien alien) {
        if (aliens[alienId] != null) {
            Company.AddAlien(aliens[alienId]);
        }
        
        Company.EmployAlien(alien);
        SectorUI.GetSector().SetAliens(alienId, alien);
    }

    public static void ResetAliens() {
        alienId = 0;
        aliens = null;
    }

    #region Setters

        private static void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

    #endregion
}