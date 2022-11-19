using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class ProductManager {
    private static List<Product> loadedProducts;
    private static UnityEvent<string> FinishLoadEvent = new UnityEvent<string>();

    public static void Load() {
        string filePath = Application.streamingAssetsPath + "/Products/products.json";
        FinishLoadEvent.AddListener(DefineProducts);
        DataManager.instance.Load(filePath, FinishLoadEvent);
    }

    private static void DefineProducts(string dataAsJson) {
        ProductData data = JsonUtility.FromJson<ProductData>(dataAsJson);

        foreach (Product product in data.GetProducts()) {
            product.SetProductionTimeMetrics();
        }
        loadedProducts = data.GetProducts();

        Universe.Generate();
    }

    public static List<Product> GetProducts() {
        return loadedProducts;
    }

    public static Product GetProducts(int id) {
        return loadedProducts[id];
    }
}
