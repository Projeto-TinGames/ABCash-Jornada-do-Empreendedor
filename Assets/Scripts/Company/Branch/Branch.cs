using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch {
    public int id;
    public Market market;
    public List<Sector> sectors = new List<Sector>();

    public Branch(int id, Market market) {
        this.id = id;
        this.market = market;
    }
}