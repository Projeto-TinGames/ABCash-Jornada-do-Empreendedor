using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Galaxy {
    private string[] possibleNames = {"a", "b", "c", "d", "e"};

    private int id;
    private int x;
    private int y;
    private string name;
    private Market market;

    public Galaxy(int id, int x, int y) {
        this.id = id;
        this.x = x;
        this.y = y;

        this.name = possibleNames[Random.Range(0,possibleNames.Length)];
        this.market = new Market();
    }

    #region Get Functions

        public int GetId() {
            return id;
        }

        public int GetPositionX() {
            return x;
        }

        public int GetPositionY() {
            return y;
        }

        public string GetName() {
            return name;
        }

        public Market GetMarket() {
            return market;
        }

    #endregion

}