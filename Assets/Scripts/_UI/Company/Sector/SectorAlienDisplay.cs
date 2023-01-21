using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorAlienDisplay : AlienDisplay {
    public override void Click() {
        EventHandlerUI.setSectorAlien.Invoke(this);
    }
}
