using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Product")]
public class Product : ScriptableObject {
    public new string name;
    public int workRequired;
    public int price;
}