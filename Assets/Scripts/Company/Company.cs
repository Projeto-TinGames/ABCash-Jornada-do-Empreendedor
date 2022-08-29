using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Company : MonoBehaviour {
    public static Company instance;

    [HideInInspector]public new string name;
    [HideInInspector]public float revenue;

    [HideInInspector]public Branch currentBranch;
    [HideInInspector]public Dictionary<int, Branch> branches = new Dictionary<int, Branch>();
    [HideInInspector]public List<Alien> employees = new List<Alien>();

    private void Awake() {
        if (instance == null) {
            transform.parent = null;
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }
}