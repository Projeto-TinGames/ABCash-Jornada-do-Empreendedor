using System.Collections;
using System.Collections.Generic;

public class TimeData {
    private int days;
    private int hours;
    private int minutes;
    private int seconds;

    public TimeData(int counter) {
        seconds = counter;

        minutes = seconds / 60;
        seconds -= minutes * 60;

        hours = minutes / 60;
        minutes -= hours * 60;

        days = hours / 24;
        hours -= days * 24;
    }

    #region Getters

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
