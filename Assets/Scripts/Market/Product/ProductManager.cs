using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class ProductManager {
    private static bool started;

    private static List<Product> loadedProducts;
    private static UnityEvent<string> FinishLoadEvent = new UnityEvent<string>();
    private static string filePath = Application.streamingAssetsPath + "/Products/products.json";

    public static void Start() {
        if (!started) {
            Load();
        }
    }

    public static void Load() {
        FinishLoadEvent.AddListener(DefineProducts);
        DataManager.instance.Load(filePath, FinishLoadEvent);
    }

    private static void DefineProducts(string dataAsJson) {
        if (loadedProducts == null) {
            ProductData data = JsonUtility.FromJson<ProductData>(dataAsJson);

            foreach (Product product in data.GetProducts()) {
                product.SetProductionTimeMetrics();
            }
            loadedProducts = data.GetProducts();

            if (Company.GetProducts().Count == 0) {
                for (int i = 0; i < 3; i++) {
                    Company.AddProduct(loadedProducts[i]);
                }
            }

            Universe.Generate();
        }
    }

    public static List<Product> GetProducts() {
        return loadedProducts;
    }

    public static Product GetProducts(int id) {
        return loadedProducts[id];
    }
}
