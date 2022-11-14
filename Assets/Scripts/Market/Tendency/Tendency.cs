using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendency {
    private Product product;
    private List<float> valorizations = new List<float>();
    private List<float> rumorValorizations = new List<float>();

    public Tendency(Product product) {
        this.product = product;

        for (int i = 0; i < 30; i++) { // Generates the valorization and rumor valorization for each day in the month
            this.AddValorization();
        }
    }

    public Tendency(TendencyData data) {
        this.product = ProductManager.GetProducts(data.GetProductId());
        this.valorizations = data.GetValorizations();
        this.rumorValorizations = data.GetRumorValorizations();
    }

    public void Update() {
        RemoveValorization();
        AddValorization();
    }

    #region Add

        public void AddValorization() {
            float valorization = (float)Random.Range(-100, 101)/100;
            valorizations.Add(valorization);

            int random = Random.Range(0, 2);

            if (random == 1) { // True rumor
                rumorValorizations.Add(valorization);
            }
            else {
                valorization = (float)Random.Range(-100, 101)/100;
                rumorValorizations.Add(valorization);
            }
        }

    #endregion

    #region Remove

        public void RemoveValorization(int index = 0) {
            valorizations.RemoveAt(index);
            rumorValorizations.RemoveAt(index);
        }

    #endregion

    #region Getters

        public Product GetProduct() {
            return product;
        }

        public float GetProductNormalizedPrice() {
            return product.GetPrice() * rumorValorizations[0];
        }

        public float GetProductNormalizedPrice(int index) {
            return product.GetPrice() * rumorValorizations[index];
        }

        public List<float> GetValorizations() {
            return valorizations;
        }

        public float GetValorizations(int day) {
            return valorizations[day];
        }

        public List<float> GetRumorValorizations() {
            return rumorValorizations;
        }

        public float GetRumorValorizations(int day) {
            return rumorValorizations[day];
        }

    #endregion
}
