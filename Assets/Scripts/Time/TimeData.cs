using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TimeData {
    private int days;
    private int hours;
    private int minutes;
    private int seconds;

    private float counter;
    private float updateRate = 1f;

    public TimeData(float counter, float productionRate = 1f) {
        this.counter = counter;
        this.updateRate = productionRate;

        seconds = (int)(counter/productionRate);

        minutes = seconds / 60;
        seconds -= minutes * 60;

        hours = minutes / 60;
        minutes -= hours * 60;

        days = hours / 24;
        hours -= days * 24;
    }

    public TimeData(int days, int hours, int minutes, int seconds) {
        this.days = days;
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;

        hours += days * 24;
        minutes += hours * 60;
        seconds += minutes * 60;
        
        this.counter = seconds;
    }

    struct RealTime {
        public string datetime;
    }

    public TimeData(string dataAsJson) {
        RealTime realTime = JsonUtility.FromJson<RealTime>(dataAsJson);

		string date = Regex.Match(realTime.datetime, @"^\d{4}-\d{2}-\d{2}").Value;
		string time = Regex.Match(realTime.datetime, @"\d{2}:\d{2}:\d{2}").Value;

		DateTime dateTime = DateTime.Parse(string.Format("{0} {1}", date, time));

        this.seconds = dateTime.Second;
        this.minutes = dateTime.Minute;
        this.hours = dateTime.Hour;
        this.days = (2023-dateTime.Year)*365 + dateTime.Month*30 + dateTime.Day;

        this.counter = this.seconds + 60*(this.minutes + 60*(this.hours + this.days*24));
    }

    #region Getters

        public float GetCounter() {
            return counter;
        }

        public float GetUpdateRate() {
            return updateRate;
        }

        public int GetNormalizedCounter() {
            return (int)(counter/updateRate);
        }

        public int GetDays() {
            return days;
        }

        public int GetHours() {
            return hours;
        }

        public int GetMinutes() {
            return minutes;
        }

        public int GetSeconds() {
            return seconds;
        }

    #endregion
}
