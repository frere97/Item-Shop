using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new armor", menuName = "Armor")]
public class ArmorItem : ScriptableObject
{

    [SerializeField] Sprite itemImage;
    [SerializeField] string itemName;
    [SerializeField] int itemPrice;
    [SerializeField] List<ArmorStats> armorStats = new List<ArmorStats>();
    [TextArea][SerializeField] string description;
    [Tooltip("if enabled, the system will check if player already have in the inventory. If True: will lock the buy")]
    [SerializeField] bool canOnlyContainOne;

    //made this way because it is easier to control than variables getter setter
    public Sprite GetItemImage()
    {
        return itemImage;
    }

    public string GetItemName()
    {
        return itemName;
    }
    public int GetItemPrice()
    {
        return itemPrice;
    }

    public List<ArmorStats> GetArmorStats()
    {
        return armorStats;
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
public class ArmorStats
{
   public string statName;
   public int statValue;
}