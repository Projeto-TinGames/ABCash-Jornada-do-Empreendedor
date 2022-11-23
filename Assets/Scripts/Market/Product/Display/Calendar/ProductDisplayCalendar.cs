using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductDisplayCalendar : MonoBehaviour {
    [SerializeField]private GameObject calendarUI;

    [SerializeField]private ProductDisplayCalendarDay prefabDay;

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

    public void Select(int day) {
        ProductDisplayUI.SetRumorDay(day);
        calendarUI.SetActive(false);
    }
}