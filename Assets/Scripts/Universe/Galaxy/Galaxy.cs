using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Galaxy {
    private const int taxPerDistance = 100;

    private string[] possibleNames = {"a", "b", "c", "d", "e"};

    private int id;
    private string name;
    private int x;
    private int y;
    private int branchPrice;
    private bool hasBranch;
    private Vector3 position;
    private Market market;

    public Galaxy(int id, int x, int y) {
        this.id = id;
        this.x = x;
        this.y = y;
        this.branchPrice = (x + y) * taxPerDistance;

        //this.name = possibleNames[Random.Range(0,possibleNames.Length)];
        this.name = $"Galáxia {this.x},{this.y}";
        this.market = new Market();
    }

    public Galaxy(GalaxyData data) {
        this.id = data.GetId();
        this.name = data.GetName();
        this.x = data.GetX();
        this.y = data.GetY();
        this.branchPrice = (this.x + this.y) * taxPerDistance;
        this.hasBranch = data.GetHasBranch();
        this.position = new Vector3(data.GetPosition(0), data.GetPosition(1), data.GetPosition(2));
        this.market = new Market(data.GetMarket());
    }

    public void Update() {
        market.Update();
    }

    #region Getters

        public int GetId() {
            return id;
        }
        
        public string GetName() {
            return name;
        }

        public int GetX() {
            return x;
        }

        public int GetY() {
            return y;
        }

        public int GetBranchPrice() {
            return branchPrice;
        }

        public bool GetHasBranch() {
            return hasBranch;
        }

        public Vector3 GetPosition() {
            return position;
        }

        public Market GetMarket() {
            return market;
        }

    #endregion

    #region Setters

        public void SetId(int value) {
            id = value;
        }
        
        public void SetName(string value) {
            name = value;
        }

        public void SetX(int value) {
            x = value;
        }

        public void SetY(int value) {
            y = value;
        }

        public void SetBranchPrice(int value) {
            branchPrice = value;
        }

        public void SetHasBranch(bool value) {
            hasBranch = value;
        }

        public void SetPosition(Vector3 value) {
            position = value;
        }

        public void SetMarket(Market value) {
            market = value;
        }

    #endregion
}