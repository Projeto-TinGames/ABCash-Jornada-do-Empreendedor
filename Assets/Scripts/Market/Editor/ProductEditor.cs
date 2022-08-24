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

        if (string.IsNullOrEmpty(productObject.GetName())) {
            name = EditorGUILayout.TextField("Name:",name);
            if (GUILayout.Button("Save Name")) {
                productObject.SetName(name);
            }
        }
        else {
            EditorGUILayout.LabelField("Name: " + productObject.GetName());
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);

            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Work Required:");
                productObject.SetWork(EditorGUILayout.IntField(productObject.GetWork()));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Price:");
                productObject.SetPrice(EditorGUILayout.FloatField(productObject.GetPrice()));
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Save Data")) {
                SaveData(productObject.product);
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

        Product fileProduct = productData.products.Find(data => data.name == product.name);

        if (fileProduct != null) {
            fileProduct.name = product.name;
            fileProduct.workRequired = product.workRequired;
            fileProduct.price = product.price;
        }
        else {
            productData.products.Add(product);
        }

        string dataAsJson = JsonUtility.ToJson(productData,true);
        File.WriteAllText(filePath,dataAsJson);

        LoadData();
    }

}