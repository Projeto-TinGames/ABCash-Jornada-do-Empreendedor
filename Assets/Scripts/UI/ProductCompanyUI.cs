using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductCompanyUI : ProductUI {
    [SerializeField]private GameObject navMenu;

    protected override void Start() {
        navMenu.SetActive(true);

        if (ProductUI.isSelectingGalaxy) {
            navMenu.GetComponent<CompanyNavUI>().Toggle(false);
        }

        base.Start();
    }
}
