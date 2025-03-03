using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemBgShop
{
    public int numberBg;
    public StateItemShop stateItemShop;
    public int price;
}

public enum StateItemShop
{
    NoBuy,
    Buyed,
    Active
}
