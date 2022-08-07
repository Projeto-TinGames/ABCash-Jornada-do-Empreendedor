using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Product", fileName = "scriptable_product_")]
public class Product : ScriptableObject {
    public new string name;
    public int workRequired;
    public float price;
}