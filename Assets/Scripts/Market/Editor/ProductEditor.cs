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

        if (string.IsNullOrEmpty(productObject.GetProduct().GetName())) {
            name = EditorGUILayout.TextField("Name:",name);
            if (GUILayout.Button("Save Name")) {
                productObject.GetProduct().SetName(name);
                productObject.GetProduct().SetId(-1);
            }
        }
        else {
            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Name: " + productObject.GetProduct().GetName());
                if (productObject.GetProduct().GetId() != -1) {
                    EditorGUILayout.LabelField("Id: " + productObject.GetProduct().GetId());
                } 
            GUILayout.EndHorizontal();
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);

            GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Price:");
                productObject.GetProduct().SetPrice(EditorGUILayout.FloatField(productObject.GetProduct().GetPrice()));
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Production Time:");
            GUILayout.BeginHorizontal();
                productObject.GetProduct().SetProductionTimeDays(EditorGUILayout.IntField(productObject.GetProduct().GetProductionTimeDays()));
                productObject.GetProduct().SetProductionTimeHours(EditorGUILayout.IntField(productObject.GetProduct().GetProductionTimeHours()));
                productObject.GetProduct().SetProductionTimeMinutes(EditorGUILayout.IntField(productObject.GetProduct().GetProductionTimeMinutes()));
                productObject.GetProduct().SetProductionTimeSeconds(EditorGUILayout.IntField(productObject.GetProduct().GetProductionTimeSeconds()));
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Save Data")) {
                productObject.GetProduct().SetProductionTimeCounter();
                SaveData(productObject.GetProduct());
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
            fileProduct.SetPrice(product.GetPrice());
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