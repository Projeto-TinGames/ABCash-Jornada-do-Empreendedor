using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market {
    private List<Tendency> tendencies = new List<Tendency>();

    public Market() {
        foreach (Product product in ProductManager.GetProducts()) {
            AddTendency(product);
        }
    }

    public Market(MarketData data) {
        foreach (TendencyData tendency in data.GetTendencies()) {
            tendencies.Add(new Tendency(tendency));
        }
    }

    public void Update() {
        if (Universe.GetMarketUpdateCounter() <= 0) {
            foreach (Tendency tendency in tendencies) {
                tendency.Update();
            }
        }
    }

    #region Add

        public void AddTendency(Product product) {
            Tendency tendency = new Tendency(product);
            tendencies.Add(tendency);
        }

    #endregion

    #region Remove

        public void RemoveTendency(Tendency tendency) {
            tendencies.Remove(tendency);
        }

        public void RemoveTendency(int index) {
            tendencies.RemoveAt(index);
        }

    #endregion

    #region Getters

        public List<Tendency> GetTendencies() {
            return tendencies;
        }

        public Tendency GetTendencies(int index) {
            return tendencies[index];
        }

        public Tendency GetTendencies(Product product) {
            return tendencies.Find(tendency => tendency.GetProduct() == product);
        }

    #endregion
}