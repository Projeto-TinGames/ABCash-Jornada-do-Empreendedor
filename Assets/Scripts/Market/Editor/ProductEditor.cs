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

        if (string.IsNullOrEmpty(productObject.product.name)) {
            name = EditorGUILayout.TextField("Name:",name);
            if (GUILayout.Button("Save Name")) {
                productObject.product.name = name;
                productObject.product.id = -1;
            }
        }
        else {
            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Name: " + productObject.product.name);
                if (productObject.product.id != -1) {
                    EditorGUILayout.LabelField("Id: " + productObject.product.id);
                } 
            GUILayout.EndHorizontal();
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);

            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Price:");
                productObject.product.price = EditorGUILayout.FloatField(productObject.product.price);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Work:");
                productObject.product.work = EditorGUILayout.IntField(productObject.product.work);
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
            fileProduct.work = product.work;
            fileProduct.price = product.price;
        }
        else {
            product.id = productData.products.Count;
            productData.products.Add(product);
        }


        string dataAsJson = JsonUtility.ToJson(productData,true);
        File.WriteAllText(filePath,dataAsJson);

        LoadData();
    }

}