using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPriorityUI : MonoBehaviour {
    private void Awake() {
        transform.SetAsFirstSibling();
    }
}
