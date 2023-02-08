using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUI : MonoBehaviour {
    public void UpdateSpeed(float value) {
        TimeManager.instance.UpdateSpeed(value);
    }

    public void SkipTime() {
        TimeManager.instance.SkipTime();
    }
}
