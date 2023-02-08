using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ClickableDisplayUI : MonoBehaviour {
    private Button button;

    protected virtual void Awake() {
        button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(Click);
    }

    protected virtual void Start() {
        ColorBlock colors = button.colors;
        colors.highlightedColor = new Color(0.9f,0.9f,0.9f);
        colors.selectedColor = new Color(0.75f,0.75f,0.75f);
        button.colors = colors;

        Select();
    }

    public virtual void Select() {
        button.Select();
    }
    
    public abstract void Click();
}
