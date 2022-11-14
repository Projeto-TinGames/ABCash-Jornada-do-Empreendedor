using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch {
    private int id;
    private List<Sector> sectors = new List<Sector>();

    public Branch(int id) {
        this.id = id;
    }

    public Branch(BranchData branchData) {
        this.id = branchData.GetId();
        
        foreach (SectorData sectorData in branchData.GetSectors()) {
            Sector sector = new Sector(sectorData);
            this.sectors.Add(sector);
        }
    }

    public void Update() {
        foreach (Sector sector in sectors) {
            sector.Update();
        }
    }

    #region Add

        public void AddSector(Sector sector) {
            sectors.Add(sector);
        }

    #endregion

    #region Remove

        public void RemoveSector(Sector sector) {
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

        public List<Sector> GetSectors() {
            return sectors;
        }

        public Sector GetSectors(int index) {
            return sectors[index];
        }

    #endregion

    #region Setters

        public void SetId(int value) {
            id = value;
        }

        public void SetSectors(List<Sector> value) {
            sectors = value;
        }

        public void SetSectors(int index, Sector value) {
            sectors[index] = value;
        }

    #endregion
}