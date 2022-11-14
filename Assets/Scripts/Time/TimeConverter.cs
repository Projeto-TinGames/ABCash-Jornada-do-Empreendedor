using System.Collections;
using System.Collections.Generic;

public class TimeConverter {
    private int days;
    private int hours;
    private int minutes;
    private int seconds;

    private int counter;
    private int updateRate = 1;

    public TimeConverter(int counter, int updateRate = 1) {
        this.counter = counter;
        this.updateRate = updateRate;

        seconds = counter/updateRate;

        minutes = seconds / 60;
        seconds -= minutes * 60;

        hours = minutes / 60;
        minutes -= hours * 60;

        days = hours / 24;
        hours -= days * 24;
    }

    public TimeConverter(int days, int hours, int minutes, int seconds) {
        this.days = days;
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;

        hours += days * 24;
        minutes += hours * 60;
        seconds += minutes * 60;
        
        this.counter = seconds;
    }

    #region Getters

        public int GetCounter() {
            return counter;
        }

        public int GetUpdateRate() {
            return updateRate;
        }

        public int GetNormalizedCounter() {
            return counter/updateRate;
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
