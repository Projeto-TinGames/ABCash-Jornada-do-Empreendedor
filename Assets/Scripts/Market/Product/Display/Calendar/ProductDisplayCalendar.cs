using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductDisplayCalendar : MonoBehaviour {
    [SerializeField]private GameObject calendarUI;
    [SerializeField]private ProductDisplayCalendarDay prefabDay;
    [SerializeField]private TextMeshProUGUI time;

    private int timeCounter;

    private void OnEnable() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 30; i++) {
            ProductDisplayCalendarDay dayInstance = Instantiate(prefabDay);

            dayInstance.transform.SetParent(transform);
            dayInstance.transform.localScale = new Vector3(1f,1f,1f);

            dayInstance.SetValues(i, this);
        }
    }

    private void Update() {
        TimeConverter timeConverter = new TimeConverter(0);

        if (timeCounter > 0) {
            timeConverter = new TimeConverter(timeCounter - TimeManager.instance.GetPlayTimeCounter());
        }
        
        time.text = $"Tempo: {timeConverter.GetDays()}d {timeConverter.GetHours()}h {timeConverter.GetMinutes()}m {timeConverter.GetSeconds()}s";
    }

    public void Select(int day) {
        ProductDisplayCalendarDay currentDay, newDay;

        timeCounter = new TimeConverter(1*day,0,0,0).GetCounter();

        currentDay = transform.GetChild(ProductDisplayUI.GetRumorDay()).gameObject.GetComponent<ProductDisplayCalendarDay>();
        currentDay.Deselect();

        newDay = transform.GetChild(day).gameObject.GetComponent<ProductDisplayCalendarDay>();
        newDay.Select();

        ProductDisplayUI.SetRumorDay(day);
    }

    public void Close() {
        calendarUI.SetActive(false);
    }
}