using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienDisplay : MonoBehaviour {
    private Alien alien;

    [SerializeField]private Image alienImage;
    [SerializeField]private Button button;

    public void Select() {
        AlienInfo.refreshInfo.Invoke(this);
    }

    public void Focus() {
        button.Select();
    }

    #region Getters

        public Alien GetAlien() {
            return alien;
        }

    #endregion

    #region Setters
    
        public void SetAlien(Alien alien) {
            this.alien = alien;

            alienImage.sprite = alien.GetSprite();
            alienImage.color = alien.GetColor();
        }

    #endregion
}
