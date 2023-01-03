using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorEmployeeDisplay : MonoBehaviour {
    private Alien alien;
    private int id;

    [SerializeField]private GameObject text;
    [SerializeField]private Image alienImage;
    [SerializeField]private Button button;

    public void Select() {
        SectorEmployeeInfo.refreshInfo.Invoke(this);
    }

    public void Focus() {
        button.Select();
    }

    #region Getters

        public int GetId() {
            return id;
        }

        public Alien GetAlien() {
            return alien;
        }

    #endregion

    #region Setters

        public void SetId(int value) {
            this.id = value;
        }
    
        public void SetAlien(Alien alien) {
            this.alien = alien;

            alienImage.sprite = alien.GetSprite();
            alienImage.color = alien.GetColor();
            alienImage.gameObject.SetActive(true);
            text.SetActive(false);
        }

    #endregion
}
