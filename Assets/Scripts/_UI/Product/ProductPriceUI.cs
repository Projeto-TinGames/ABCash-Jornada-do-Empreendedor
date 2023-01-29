using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductPriceUI : MonoBehaviour {
    [SerializeField]private Transform benefitList;

    [SerializeField]private TextMeshProUGUI benefitPrefab;
    [SerializeField]private TextMeshProUGUI finalPrice;

    private void OnEnable() {
        /*Tendency tendency = ProductUI.GetTendency();
        Product product = Company.GetProducts(tendency.GetProductId());

        foreach (Transform child in benefitList) {
            Destroy(child.gameObject);
        }

        TextMeshProUGUI basePrice = Instantiate(benefitPrefab);
        basePrice.transform.SetParent(benefitList);
        basePrice.transform.localScale = Vector3.one;
        basePrice.text = $"+ Preço Base: {product.GetBasePrice().ToString("C2")}";

        finalPrice.text = $"Preço Final: {.GetFinal().ToString("C2")}";*/
    }
}
