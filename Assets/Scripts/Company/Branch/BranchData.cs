using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BranchData {
    public int id;
    public MarketData market;
    public List<SectorData> sectors = new List<SectorData>();

    public BranchData(Branch branch) {
        this.id = branch.id;
        this.market = new MarketData(branch.market);

        Debug.Log(branch.sectors.Count);
        foreach (Sector sector in branch.sectors) {
            this.sectors.Add(new SectorData(sector));
        }
    }
}