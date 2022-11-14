using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MarketData {
    [SerializeField]private List<TendencyData> tendencies = new List<TendencyData>();

    public MarketData(Market market) {
        foreach (Tendency tendency in market.GetTendencies()) {
            tendencies.Add(new TendencyData(tendency));
        }
    }

    #region Getters

        public List<TendencyData> GetTendencies() {
            return tendencies;
        }

        public TendencyData GetTendencies(int index) {
            return tendencies[index];
        }

    #endregion
}