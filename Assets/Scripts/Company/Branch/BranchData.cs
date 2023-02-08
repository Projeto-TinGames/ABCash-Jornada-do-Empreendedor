using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BranchData {
    [SerializeField]private int id;
    [SerializeField]private string name;
    [SerializeField]private List<SectorData> sectors = new List<SectorData>();

    public BranchData(Branch branch) {
        this.id = branch.GetId();
        this.name = branch.GetName();

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

        public string GetName() {
            return name;
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

        public void SetName(string value) {
            name = value;
        }

        public void SetSectors(List<SectorData> value) {
            sectors = value;
        }

        public void SetSectors(int index, SectorData value) {
            sectors[index] = value;
        }

    #endregion
}