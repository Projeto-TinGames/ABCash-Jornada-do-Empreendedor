using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(ProductObject))]
public class ProductEditor : Editor {

    private new string name;
    private ProductData productData;

    public override void OnInspectorGUI() {
        ProductObject productObject = (ProductObject)target;
        Product product = productObject.GetProduct();

        if (string.IsNullOrEmpty(product.GetName())) {
            name = EditorGUILayout.TextField("Name:",name);
            if (GUILayout.Button("Save Name")) {
                product.SetName(name);
                product.SetId(-1);
                product.SetLevel(1);
            }
        }
        else {
            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Name: " + product.GetName());
                if (product.GetId() != -1) {
                    EditorGUILayout.LabelField("Id: " + product.GetId());
                } 
            GUILayout.EndHorizontal();
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);

            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Price:");
                product.SetBasePrice(EditorGUILayout.FloatField(product.GetBasePrice()));
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Production Time:");
            GUILayout.BeginHorizontal();
                product.SetProductionTimeDays(EditorGUILayout.IntField(product.GetProductionTimeDays()));
                product.SetProductionTimeHours(EditorGUILayout.IntField(product.GetProductionTimeHours()));
                product.SetProductionTimeMinutes(EditorGUILayout.IntField(product.GetProductionTimeMinutes()));
                product.SetProductionTimeSeconds(EditorGUILayout.IntField(product.GetProductionTimeSeconds()));
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Save Data")) {
                product.SetProductionTimeCounter();
                SaveData(product);
            }
        }

        EditorUtility.SetDirty(productObject);
    }

    private void LoadData() {
        /*if (string.IsNullOrEmpty(filePath)) {
            filePath = EditorUtility.OpenFilePanel("Select localization data file", Application.streamingAssetsPath, "json");
        }*/

        string filePath = Application.streamingAssetsPath + "/Products/products.json";
        string dataAsJson = File.ReadAllText(filePath);
        productData = JsonUtility.FromJson<ProductData>(dataAsJson);
    }

    private void SaveData(Product product) {
        LoadData();
        
        string filePath = Application.streamingAssetsPath + "/Products/products.json";

        Product fileProduct = productData.GetProducts().Find(data => data.GetName() == product.GetName());

        if (fileProduct != null) {
            fileProduct.SetName(product.GetName());
            fileProduct.SetProductionTimeCounter(product.GetProductionTimeCounter());
            fileProduct.SetBasePrice(product.GetBasePrice());
        }
        else {
            product.SetId(productData.GetProducts().Count);
            productData.AddProduct(product);
        }

        string dataAsJson = JsonUtility.ToJson(productData,true);
        File.WriteAllText(filePath,dataAsJson);

        LoadData();
    }

}