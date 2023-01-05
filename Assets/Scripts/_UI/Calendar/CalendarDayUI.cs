using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarDayUI : MonoBehaviour {
    private int day;

    [SerializeField]private Button dayButton;
    [SerializeField]private TextMeshProUGUI dayText;

    public void SetDay(int dayValue) {
        day = dayValue;
        dayText.text = $"Dia\n{day+1}";
    }

    public void Select() {
        EventHandlerUI.setDay.Invoke(day);
        dayText.color = Color.red;
    }

    public void Deselect() {
        dayText.color = new Color(.1960f, .1960f, .1960f, 1);
    }
}
