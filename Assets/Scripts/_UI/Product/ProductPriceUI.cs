using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductPriceUI : MonoBehaviour {
    [SerializeField]private Transform priceComponentList;

    [SerializeField]private TextMeshProUGUI priceComponentPrefab;
    [SerializeField]private TextMeshProUGUI marketValorization;
    [SerializeField]private TextMeshProUGUI exportationTax;
    [SerializeField]private TextMeshProUGUI finalPrice;

    private void OnEnable() {
        Tendency tendency = ProductUI.GetTendency();
        Product product = Company.GetProducts(tendency.GetProductId());
        Sector sector = SectorUI.GetSector();        
        int dayId = ProductUI.GetDay();

        float price = tendency.GetProductNormalizedPrice(dayId);

        foreach (Transform child in priceComponentList) {
            Destroy(child.gameObject);
        }

        TextMeshProUGUI basePrice = Instantiate(priceComponentPrefab);
        basePrice.transform.SetParent(priceComponentList);
        basePrice.transform.localScale = Vector3.one;
        basePrice.text = $"+ Preço Base: {product.GetBasePrice().ToString("C2")}";

        if (product.GetUpgradePrice() > 0f) {
            TextMeshProUGUI upgradePrice = Instantiate(priceComponentPrefab);
            upgradePrice.transform.SetParent(priceComponentList);
            upgradePrice.transform.localScale = Vector3.one;
            upgradePrice.text = $"+ Melhorias: {product.GetUpgradePrice().ToString("C2")}";
        }

        if (tendency.GetIsRumor(dayId)) {
            float valorization = tendency.GetProductRumorNormalizedPrice(dayId) - product.GetPrice();
            float percentage = tendency.GetRumorValorizations(dayId);
            marketValorization.text = $"+ Rumor de Valorização: {valorization.ToString("C2")} ({percentage}%)";
            marketValorization.color = Color.red;
        }
        else {
            float valorization = tendency.GetProductNormalizedPrice(dayId) - product.GetPrice();
            float percentage = tendency.GetValorizations(dayId);
            marketValorization.text = $"+ Valorização: {valorization.ToString("C2")} ({percentage}%)";
            marketValorization.color = Color.green;
        }

        if (SectorUI.GetIsEditing() && sector.GetExportationTax() > 0f) {
            exportationTax.gameObject.SetActive(true);
            exportationTax.text = $"+ Taxa de Exportação: {(-sector.GetExportationTax()).ToString("C2")}";
            price -= sector.GetExportationTax();
        }
        else {
            exportationTax.gameObject.SetActive(false);
        }

        finalPrice.text = $"Preço Final: {price.ToString("C2")}";
    }
}
