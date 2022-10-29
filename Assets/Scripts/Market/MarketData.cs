using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MarketData {
    [SerializeField]private List<float> percentages = new List<float>();

    public MarketData(Market market) {
        percentages = market.GetPercentages();
    }

    #region Getters

        public List<float> GetPercentages() {
            return percentages;
        }

        public float GetPercentages(int index) {
            return percentages[index];
        }

    #endregion

    #region Setters

        public void SetPercentages(List<float> value) {
            percentages = value;
        }

        public void GetPercentages(int index, float value) {
            percentages[index] = value;
        }

    #endregion
}
