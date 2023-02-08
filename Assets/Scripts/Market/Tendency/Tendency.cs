using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tendency {
    private const float rumorConfirmationPrice = 200f;

    private int productId;
    private List<float> valorizations = new List<float>();
    private List<float> rumorValorizations = new List<float>();
    private List<bool> isRumor = new List<bool>();

    public Tendency(int productId) {
        this.productId = productId;

        for (int i = 0; i < 30; i++) { // Generates the valorization and rumor valorization for each day in the month
            this.AddValorization();
        }

        //isRumor[0] = false;
    }

    public Tendency(TendencyData data) {
        this.productId = data.GetProductId();
        this.valorizations = data.GetValorizations();
        this.rumorValorizations = data.GetRumorValorizations();
        this.isRumor = data.GetIsRumor();
    }

    public void Update() {
        RemoveValorization();
        AddValorization();
    }

    public void Research(int day) {
        if (Company.Pay(rumorConfirmationPrice)) {
            isRumor[day] = false;
        }
    }

    #region Add

        public void AddValorization() {
            float valorization = (float)Random.Range(-100, 101)/100;
            valorizations.Add(valorization);
            isRumor.Add(true);

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
            isRumor.RemoveAt(index);
            isRumor[0] = false;
        }

    #endregion

    #region Getters

        public int GetProductId() {
            return productId;
        }

        public float GetProductNormalizedPrice(int index = 0) {
            Product product = ProductManager.GetProducts(productId);
            return product.GetPrice() + product.GetPrice() * valorizations[index];
        }

        public float GetProductRumorNormalizedPrice(int index = 0) {
            Product product = ProductManager.GetProducts(productId);
            return product.GetPrice() + product.GetPrice() * rumorValorizations[index];
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

        public List<bool> GetIsRumor() {
            return isRumor;
        }

        public bool GetIsRumor(int index) {
            return isRumor[index];
        }

    #endregion
}
