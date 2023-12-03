using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionStore : ItemDescription
{
    [SerializeField] Button buyButton;
    [SerializeField] protected TextMeshProUGUI itemPrice;

    public override void OnEnable()
    {
        base.OnEnable();
        buyButton.gameObject.SetActive(false);
    }

    public override void SetInfos(Item itemToReceive)
    {
        base.SetInfos(itemToReceive);
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

        LocalPlayer.instance.GetInventory().BuyItem(item);
        SetInfos(item);
    }

    public override void ResetInfos()
    {
        itemPrice.text = "";
        buyButton.gameObject.SetActive(true);
        base.ResetInfos();
    }


    public void SetBuyButtonState(string priceText, bool interactable, Color textColor)
    {
        buyButton.interactable = interactable;
        itemPrice.text = priceText;
        itemPrice.color = textColor;

    }
}
