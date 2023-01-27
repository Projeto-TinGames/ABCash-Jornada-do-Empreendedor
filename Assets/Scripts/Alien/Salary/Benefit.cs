using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benefit {
    private string name;
    private float value;

    public Benefit(string name, float value) {
        this.name = name;
        this.value = value;
    }
    
    #region Getters

        public string GetName() {
            return name;
        }

        public float GetValue() {
            return value;
        }

    #endregion

}