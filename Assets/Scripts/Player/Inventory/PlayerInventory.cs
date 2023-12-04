using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    int gold = 13;
    [SerializeField]List<Item> PlayerItens = new List<Item>();
    private Item HeadGear;
    private Item BodyGear;
    [SerializeField] TextMeshProUGUI GoldAmount;
    [SerializeField] GameObject InventoryScreen;


    private void Start()
    {
        UpdateGold();
    }
    public void OpenInventory()
    {
        InventoryScreen.SetActive(true);
    }

    #region gold
    //just call it to add founds to the player, to remove use RemoveGold Method
    public void AddGold(int value)
    {
        gold += Mathf.Abs(value);
        UpdateGold();
    }

    public void RemoveGold(int value)
    {
        gold -= Mathf.Abs(value);
        UpdateGold();
    }

    public int GetGold()
    {
        return gold;
    }

    void UpdateGold()
    {
        GoldAmount.text = gold + " G";
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
    public void BuyItem(Item item)
    {
        AddItemToInventory(item);
        RemoveGold(item.GetItemBuyPrice());
    }

    public void SellItem(Item item)
    {
        RemoveItemFromInventory(item);
        AddGold(item.GetItemSelPrice());
    }


    #endregion

    #region Equipements
    public void Equip(Item item)
    {
        if(item is EquipableItem)
        {
            if(((EquipableItem)item).type == Type.BodyGear)
            {
                BodyGear = item;
                
                GameObject equipmentVisual = Instantiate(((EquipableItem)item).Equipement, LocalPlayer.instance.transform);
                equipmentVisual.transform.localPosition = Vector3.zero;
            }
            else
            {
                HeadGear = item;
            }

        }
    }

    public void Unequip(Item item)
    {
        if (item is EquipableItem)
        {
            if (((EquipableItem)item).type == Type.BodyGear)
            {
                BodyGear = null;
            }
            else
            {
                HeadGear = null;
            }

        }
    }

    public Item GetBodyGear()
    {
        return BodyGear;
    }

    public Item GetHeadGear()
    {
        return HeadGear;
    }

    #endregion
}
