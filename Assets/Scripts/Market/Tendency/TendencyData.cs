using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TendencyData {
    [SerializeField]private int productId;
    [SerializeField]private List<float> valorizations = new List<float>();
    [SerializeField]private List<float> rumorValorizations = new List<float>();

    public TendencyData(Tendency tendency) {
        this.productId = tendency.GetProduct().GetId();
        this.valorizations = tendency.GetValorizations();
        this.rumorValorizations = tendency.GetRumorValorizations();
    }

    #region Getters

        public int GetProductId() {
            return productId;
        }

        public List<float> GetValorizations() {
            return valorizations;
        }

        public List<float> GetRumorValorizations() {
            return rumorValorizations;
        }

    #endregion
}
