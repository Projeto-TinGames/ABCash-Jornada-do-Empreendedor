using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MarketData {
    public List<float> percentages = new List<float>();

    public MarketData(Market market) {
        percentages = market.percentages;
    }
}
