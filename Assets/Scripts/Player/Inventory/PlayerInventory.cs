using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    int gold = 13;
    List<Item> PlayerItens = new List<Item>();


    #region gold
    //just call it to add founds to the player, to remove use RemoveGold Method
    public void AddGold(int value)
    {
        gold += Mathf.Abs(value);
    }

    public void RemoveGold(int value)
    {
        gold -= Mathf.Abs(value);
    }

    public int GetGold()
    {
        return gold;
    }
    #endregion

    #region itens
    public List<Item> GetPlayerItems()
    {
        return PlayerItens;
    }
    public void AddItemToInventory(Item item)
    {
        PlayerItens.Add(item);
    }
    public void RemoveItemFromInventory(Item item)
    {
        PlayerItens.Remove(item);
    }
    #endregion

    #region transactions
    public void BuyItem(Item item, int price)
    {
        AddItemToInventory(item);
        RemoveGold(price);
    }

    public void SellItem(Item item, int price)
    {
        RemoveItemFromInventory(item);
        AddGold(price);
    }


    #endregion

}
