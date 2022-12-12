using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplayCalendarDay : MonoBehaviour {
    private int day;
    private ProductDisplayCalendar calendarDisplay;

    [SerializeField]private Button dayButton;
    [SerializeField]private TextMeshProUGUI dayText;

    public void SetValues(int dayValue, ProductDisplayCalendar calendar) {
        day = dayValue;
        calendarDisplay = calendar;

        dayText.text = $"Dia\n{day+1}";

        if (ProductDisplayUI.GetRumorDay() == day) {
            Select();
        }
    }

    public void UpdateRumorDay() {
        calendarDisplay.Select(day);
    }

    public void Select() {
        dayText.color = Color.red;
    }

    public void Deselect() {
        dayText.color = new Color(.1960f, .1960f, .1960f, 1);
    }
}
