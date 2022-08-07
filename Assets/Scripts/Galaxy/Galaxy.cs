using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy {
    private int id;
    private GalaxyStats stats;

    public Galaxy(int id) {
        this.id = id;
        stats = new GalaxyStats();
    }

    #region Get Functions

        public int GetId() {
            return id;
        }

        public GalaxyStats GetStats() {
            return stats;
        }

    #endregion
}