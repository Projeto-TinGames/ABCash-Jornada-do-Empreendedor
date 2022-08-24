using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch {
    private int id;

    private Market market;
    private List<Sector> sectors = new List<Sector>();

    public Branch(int id, Market market) {
        this.id = id;
        this.market = market;
    }

    #region Get Functions

        public int GetId() {
            return id;
        }

        public Market GetMarket() {
            return market;
        }

        public List<Sector> GetSectors() {
            return sectors;
        }

        public Sector GetSector(int id) {
            return sectors[id];
        }

    #endregion

    #region Add Functions

        public void AddSector(Sector sector) {
            sectors.Add(sector);
        }

    #endregion
}