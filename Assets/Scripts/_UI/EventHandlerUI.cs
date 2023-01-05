using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventHandlerUI {
    public static UnityEvent<Product> setProduct = new UnityEvent<Product>();
    public static UnityEvent<Galaxy> setGalaxy = new UnityEvent<Galaxy>();
    public static UnityEvent<int> setDay = new UnityEvent<int>();

    public static UnityEvent<Galaxy> clickGalaxyDisplay = new UnityEvent<Galaxy>();
}