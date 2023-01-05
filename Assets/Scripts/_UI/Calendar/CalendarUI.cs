using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarUI : MonoBehaviour {
    private static int day;

    [SerializeField]private GameObject calendarUI;
    [SerializeField]private CalendarDayUI prefabDay;
    [SerializeField]private TextMeshProUGUI time;

    private int timeCounter;
    private List<CalendarDayUI> dayList = new List<CalendarDayUI>();

    private void Awake() {
        EventHandlerUI.setDay.AddListener(SetDay);
    }

    private void OnEnable() {
        dayList.Clear();
        
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 30; i++) {
            CalendarDayUI dayInstance = Instantiate(prefabDay);

            dayInstance.transform.SetParent(transform);
            dayInstance.transform.localScale = new Vector3(1f,1f,1f);

            dayInstance.SetDay(i);

            dayList.Add(dayInstance);
        }

        dayList[day].Select();
    }

    private void Update() {
        TimeConverter timeConverter = new TimeConverter(0);

        if (timeCounter > 0) {
            timeConverter = new TimeConverter(timeCounter - TimeManager.instance.GetPlayTimeCounter());
        }
        
        time.text = $"Tempo: {timeConverter.GetDays()}d {timeConverter.GetHours()}h {timeConverter.GetMinutes()}m {timeConverter.GetSeconds()}s";
    }

    public void Close() {
        calendarUI.SetActive(false);
    }

    #region Getters

        public static int GetDay() {
            return day;
        }

    #endregion

    #region Setters

        public void SetDay(int value) {
            dayList[day].Deselect();
            day = value;
        }

    #endregion
}