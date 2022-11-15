using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCreationMenu : MonoBehaviour {
    public static GalaxyDisplay galaxyDisplay;

    public static void LoadDisplay(GalaxyDisplay display) {
        if (galaxyDisplay != null) {
            galaxyDisplay.Deselect();
        }
        
        galaxyDisplay = display;
    }
}
