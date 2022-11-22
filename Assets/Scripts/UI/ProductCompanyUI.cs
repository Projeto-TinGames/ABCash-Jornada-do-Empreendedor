using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductCompanyUI : ProductUI {
    [SerializeField]private GameObject navUI;

    protected override void Start() {
        navUI.SetActive(true);

        base.Start();
    }
}
