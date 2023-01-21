using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventHandlerUI {
    public static UnityEvent<Product> setProduct = new UnityEvent<Product>();
    public static UnityEvent<Galaxy> setGalaxy = new UnityEvent<Galaxy>();
    public static UnityEvent<Sector> setSector = new UnityEvent<Sector>();
    public static UnityEvent<int> setDay = new UnityEvent<int>();

    public static UnityEvent<Alien> selectAlien = new UnityEvent<Alien>();
    public static UnityEvent<AlienDisplay> setAlien = new UnityEvent<AlienDisplay>();
    public static UnityEvent<AlienDisplay> setSectorAlien = new UnityEvent<AlienDisplay>();

    public static UnityEvent<Galaxy> clickGalaxyDisplay = new UnityEvent<Galaxy>();
}