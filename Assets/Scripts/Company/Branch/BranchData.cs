using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BranchData {
    [SerializeField]private int id;
    [SerializeField]private MarketData market;
    [SerializeField]private List<SectorData> sectors = new List<SectorData>();

    public BranchData(Branch branch) {
        this.id = branch.GetId();
        this.market = new MarketData(branch.GetMarket());

        foreach (Sector sector in branch.GetSectors()) {
            this.sectors.Add(new SectorData(sector));
        }
    }

    #region Add

        public void AddSector(SectorData sector) {
            sectors.Add(sector);
        }

    #endregion

    #region Remove

        public void RemoveSector(SectorData sector) {
            sectors.Remove(sector);
        }

        public void RemoveSector(int index) {
            sectors.RemoveAt(index);
        }

    #endregion

    #region Getters

        public int GetId() {
            return id;
        }

        public MarketData GetMarket() {
            return market;
        }

        public List<SectorData> GetSectors() {
            return sectors;
        }

        public SectorData GetSectors(int index) {
            return sectors[index];
        }

    #endregion

    #region Setters

        public void SetId(int value) {
            id = value;
        }

        public void SetMarket(MarketData value) {
            market = value;
        }

        public void SetSectors(List<SectorData> value) {
            sectors = value;
        }

        public void SetSectors(int index, SectorData value) {
            sectors[index] = value;
        }

    #endregion
}