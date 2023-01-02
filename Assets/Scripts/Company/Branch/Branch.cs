using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch {
    private int id;
    private string name;
    private List<Sector> sectors = new List<Sector>();

    private Sector currentSector;

    public Branch(int id, string name) {
        this.id = id;
        this.name = name;
    }

    public Branch(BranchData branchData) {
        this.id = branchData.GetId();
        this.name = branchData.GetName();
        
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

        public void RemoveSector() {
            sectors.Remove(currentSector);
            currentSector = null;
        }

        public void RemoveSector(Sector sector) {
            sectors.Remove(sector);
            currentSector = null;
        }

        public void RemoveSector(int index) {
            sectors.RemoveAt(index);
            currentSector = null;
        }

    #endregion

    #region Getters

        public int GetId() {
            return id;
        }

        public string GetName() {
            return name;
        }

        public List<Sector> GetSectors() {
            return sectors;
        }

        public Sector GetSectors(int index) {
            return sectors[index];
        }

        public Sector GetCurrentSector() {
            return currentSector;
        }

    #endregion

    #region Setters

        public void SetId(int value) {
            id = value;
        }

        public void SetName(string value) {
            name = value;
        }

        public void SetSectors(List<Sector> value) {
            sectors = value;
        }

        public void SetSectors(int index, Sector value) {
            sectors[index] = value;
        }

        public void SetCurrentSector(Sector value) {
            currentSector = value;
        }

    #endregion
}