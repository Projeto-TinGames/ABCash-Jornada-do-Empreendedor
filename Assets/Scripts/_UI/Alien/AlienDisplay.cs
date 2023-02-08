using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlienDisplay : ClickableDisplayUI {
    [SerializeField]private TextMeshProUGUI alienText;
    [SerializeField]private Image alienImage;

    private int id;
    private Alien alien;

    public override void Click() {
        EventHandlerUI.setAlien.Invoke(this);
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

        public void SetDisplay(int id, Alien alien) {
            this.id = id;
            this.alien = alien;

            if (this.alien != null) {
                alienImage.gameObject.SetActive(true);
                alienImage.sprite = alien.GetSprite();
                alienImage.color = alien.GetColor();
            }
            else {
                alienText.gameObject.SetActive(true);
            }
        }

    #endregion
}
