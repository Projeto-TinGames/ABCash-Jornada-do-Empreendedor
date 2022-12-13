using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductDisplayBranchUI : ProductDisplayUI {
    protected override void Start() {
        base.Start();
        scene = "sc_branch_creation_products";
    }
    
    public void Choose() {
        BranchCreation.SetProduct(ProductManager.GetProducts(productId));
        SceneController.instance.Load("sc_branch_creation");
    }
}
