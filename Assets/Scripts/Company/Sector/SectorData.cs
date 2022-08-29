using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SectorData {
    public int work;
    public int productId;
    public MarketData market;
    public List<AlienData> employees = new List<AlienData>();

    public SectorData(Sector sector) {
        this.work = sector.work;
        this.productId = sector.product.id;
        this.market = new MarketData(sector.market);
        
        foreach (Alien employee in sector.employees) {
            this.employees.Add(new AlienData(employee));
        }
    }
}