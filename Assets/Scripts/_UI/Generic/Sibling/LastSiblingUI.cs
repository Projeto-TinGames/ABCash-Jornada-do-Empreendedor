using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSiblingUI : MonoBehaviour {
    private void Awake() {
        transform.SetAsLastSibling();
    }
}