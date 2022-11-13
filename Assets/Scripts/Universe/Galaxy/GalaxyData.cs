using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxyData {
    [SerializeField]private int id;
    [SerializeField]private string name;
    [SerializeField]private int x;
    [SerializeField]private int y;
    [SerializeField]private bool hasBranch;
    [SerializeField]private float[] position;
    [SerializeField]private MarketData market;

    public GalaxyData(Galaxy galaxy) {
        this.id = galaxy.GetId();
        this.name = galaxy.GetName();
        this.x = galaxy.GetX();
        this.y = galaxy.GetY();
        this.hasBranch = galaxy.GetHasBranch();
        this.position = new float[]{galaxy.GetPosition().x, galaxy.GetPosition().y, galaxy.GetPosition().z};
        this.market = new MarketData(galaxy.GetMarket());
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

        public bool GetHasBranch() {
            return hasBranch;
        }

        public float[] GetPosition() {
            return position;
        }

        public float GetPosition(int index) {
            return position[index];
        }

        public MarketData GetMarket() {
            return market;
        }

    #endregion
}
