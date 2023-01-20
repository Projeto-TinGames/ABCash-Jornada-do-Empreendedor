using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSelectionUI : ProductUI {
    public void SelectProduct() {
        Debug.Log(productId);
        SceneController.instance.Load("sc_branch_creation");
    }
}
