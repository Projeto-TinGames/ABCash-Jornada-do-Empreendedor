using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductManager : MonoBehaviour {
    public static ProductManager instance;

    private List<Product> loadedProducts;
    private UnityEvent<string> FinishLoadEvent;

    private void Awake() {
        if (instance == null) {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        FinishLoadEvent = new UnityEvent<string>();
        FinishLoadEvent.AddListener(DefineProducts);

        StartLoad();
    }

    private void StartLoad() {
        string filePath = Application.streamingAssetsPath + "/Products/products.json";
        DataManager.instance.Load(filePath, FinishLoadEvent);
    }

    private void DefineProducts(string dataAsJson) {
        ProductData data = JsonUtility.FromJson<ProductData>(dataAsJson);
        loadedProducts = data.products;

        GalaxyMap.instance.GenerateMap(null);
    }

    public Product GetProduct(int id) {
        return loadedProducts[id];
    }

    public List<Product> GetProducts() {
        return loadedProducts;
    }
}
