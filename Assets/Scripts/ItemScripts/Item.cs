using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] Sprite itemImage;
    [SerializeField] string itemName;
    [SerializeField] int BuyPrice;
    [SerializeField] int SellPrice;
    [TextArea][SerializeField] string description;
    [Tooltip("if enabled, the system will check if player already have in the inventory. If True: will lock the buy")]
    [SerializeField] bool canOnlyContainOne;
    [SerializeField] List<ModifierStats> modifierStats = new List<ModifierStats>();

    //made this way because it is easier to control than variables getter setter
    public Sprite GetItemImage()
    {
        return itemImage;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public List<ModifierStats> GetItemtats()
    {
        return modifierStats;
    }

    public int GetItemBuyPrice()
    {
        return BuyPrice;
    }

    public int GetItemSelPrice()
    {
        return SellPrice;
    }

    public string GetDescription()
    {
        return description;
    }

    public bool GetCanOnlyContainOne()
    {
        return canOnlyContainOne;
    }

}

[Serializable]
public class ModifierStats
{
    public string statName;
    public int statValue;
    [Tooltip ("Leave 0 empty if not apply")]
    public float effectTime = 0;
}
