using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSiblingUI : MonoBehaviour {
    private void Awake() {
        transform.SetAsFirstSibling();
    }
}
