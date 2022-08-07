using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyStats {
    private string[] possibleNames = {"a", "b", "c", "d", "e"};
    private string name;
    private Market market;

    public GalaxyStats() {
        name = possibleNames[Random.Range(0,possibleNames.Length)];
        market = new Market();
    }

    #region Get Functions

        public string GetName() {
            return name;
        }

        public Market GetMarket() {
            return market;
        }

    #endregion
}
