using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public Item item;
    [SerializeField] Image ItemImage;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemStats;
    [SerializeField] TextMeshProUGUI itemDescription;
    [SerializeField] TextMeshProUGUI itemPrice;
    [SerializeField] Button buyButton;
    //making static, because in my idea, we will only have one started at a time;
    public static ItemDescription instance;

    public void OnEnable()
    {
        instance = this;
        ResetInfos();

    }
    public void OnDisable()
    {
        instance = null;
        item = null;
    }

    public void SetInfos(Item itemToReceive)
    {
        ResetInfos();
        item = itemToReceive;
        ItemImage.sprite = item.GetItemImage();
        ItemImage.color = new Color(1, 1, 1, 1);
        itemName.text = item.GetItemName();
        if ((EquipableItem)item) { }
        foreach(ModifierStats itemstats in item.GetItemtats())
        {
            itemStats.text += itemstats.statName + ": " + itemstats.statValue+ "\n";
        }
        itemDescription.text = item.GetDescription();

        if (LocalPlayer.instance.GetInventory().GetPlayerItems().Contains(item))
        {
            SetBuyButtonState("SOLD OUT", false, Color.red);

        }
        else if (item.GetItemBuyPrice() > LocalPlayer.instance.GetInventory().GetGold())
        {
            SetBuyButtonState(item.GetItemBuyPrice() + " G", false, Color.red);

        }
        else
        {
            SetBuyButtonState(item.GetItemBuyPrice() + " G", true, Color.black);
            
        }
    }

    public void BuyItem()
    {
        LocalPlayer.instance.GetInventory().BuyItem(item, item.GetItemBuyPrice());
        SetInfos(item);
    }


    public void SetBuyButtonState(string priceText, bool interactable, Color textColor)
    {
        buyButton.interactable = interactable;
        itemPrice.text = priceText;
        itemPrice.color = textColor;

    }

    public void ResetInfos()
    {
        item = null;
        ItemImage.sprite = null;
        itemName.text = "";
        itemStats.text= "";
        itemDescription.text = "";
        itemPrice.text = "";
        ItemImage.color = new Color(0, 0, 0, 0);
    }

}
