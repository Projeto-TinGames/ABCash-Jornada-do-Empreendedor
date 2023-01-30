using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienUI : MonoBehaviour {
    protected static int alienId;
    protected static int galaxyId;
    protected static Alien alien;

    [SerializeField]protected AlienDisplay displayPrefab;
    [SerializeField]protected Transform alienList; 

    [SerializeField]protected Transform alienInfo; 
    [SerializeField]protected TextMeshProUGUI alienName;
    [SerializeField]protected Image alienImage;
    [SerializeField]protected TextMeshProUGUI alienGalaxy;
    [SerializeField]protected TextMeshProUGUI alienProduct;
    [SerializeField]protected TextMeshProUGUI alienAgility;
    [SerializeField]protected TextMeshProUGUI alienWisdom;
    [SerializeField]protected TextMeshProUGUI alienSalary;
    [SerializeField]protected GameObject selectButton; 

    protected List<Alien> aliens = new List<Alien>();
    protected List<AlienDisplay> displayList = new List<AlienDisplay>();

    protected virtual void Start() {
        UpdateList();
    }

    protected virtual void Update() {
        if (alienId < displayList.Count) {
            displayList[alienId].Select();
        }
    }

    protected virtual void UpdateList() {
        for (int i = 0; i < alienList.childCount; i++) {
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
    }

    protected virtual void UpdateList(int offset) {
        for (int i = offset; i < alienList.childCount; i++) {
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
    }

    protected virtual void UpdateInfo(AlienDisplay alienDisplay) {
        alien.SetWorkGalaxyId(galaxyId);

        Galaxy galaxyValue = Universe.GetGalaxies(alien.GetGalaxyId());
        Product productValue = ProductManager.GetProducts(alien.GetProductId());

        alienName.text = alien.GetName();
        alienImage.sprite = alien.GetSprite();
        alienImage.color = alien.GetColor();
        alienGalaxy.text = $"Galáxia de Origem: {galaxyValue.GetName()}";
        alienProduct.text = $"Produto Favorito: {productValue.GetName()}";
        alienAgility.text = $"Agilidade: {alien.GetAgility().ToString()}";
        alienWisdom.text = $"Sabedoria: {alien.GetWisdom().ToString()}";
        alienSalary.text = $"Salário: {alien.GetSalary().GetFinal().ToString()}/dia";
    }

    #region Getters

        public static Alien GetAlien() {
            return alien;
        }

    #endregion

    #region Setters

        protected static void SetGalaxy(Galaxy galaxy) {
            galaxyId = galaxy.GetId();
        }

    #endregion
}