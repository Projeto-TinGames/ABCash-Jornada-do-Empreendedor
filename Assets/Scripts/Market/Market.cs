using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market {
    /*--------------------------------------------------------------
    Substituir futuramente a forma com que se identifica os produtos
    por um arquivo JSON que é gerado por meio da GUI do objeto
    de produto, tendo um ID próprio para ser referenciado 
    --------------------------------------------------------------*/

    private List<string> products = new List<string>{"Produto A", "Produto B", "Produto C"};
    private float[] values = new float[3]; //Percentagem de valorização/desvalorização

    public Market() {
        for (int i = 0; i < products.Count; i++) {
            values[i] = (float)Random.Range(-100, 101)/100;
        }
    }

    #region Get Functions

        public List<string> GetProducts() {
            return products;
        }

        public string GetProduct(int id) {
            return products[id];
        }

        public float GetValue(int id) {
            return values[id];
        }

    #endregion
}