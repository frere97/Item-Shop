using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ItemDescriptionInventory : ItemDescription
{
    [SerializeField] Button EquipButton;
    [SerializeField] TextMeshProUGUI EquipButtonText;
    [SerializeField] Button SellButton;
    [SerializeField] TextMeshProUGUI SellButtonText;

    public override void OnEnable()
    {
        base.OnEnable();
        EquipButton.gameObject.SetActive(false);
        SellButton.gameObject.SetActive(false);
    }

    public override void SetInfos(Item itemToReceive)
    {
        

        base.SetInfos(itemToReceive);

        EquipButton.gameObject.SetActive(true);
        SellButton.gameObject.SetActive(true);

        if (item is EquipableItem)
        {
            SetItemButtonsInfos(item);
        }
    }

    void SetItemButtonsInfos(Item item)
    {
        if ((EquipableItem)item != LocalPlayer.instance.GetInventory().GetBodyGear() && (EquipableItem)item != LocalPlayer.instance.GetInventory().GetHeadGear())
        {
            EquipButton.interactable = true;
            EquipButtonText.text = "Equip";
        }
        else
        {
            EquipButton.interactable = false;
            EquipButtonText.text = "Equiped";
        }
        SellButtonText.text = item.GetItemSelPrice() + " G";
    }

    public void EquipItemButton()
    {
        LocalPlayer.instance.GetInventory().Equip(item);
        SetItemButtonsInfos(item);
    }

    public void SellItem()
    {

        EquipButton.gameObject.SetActive(false);
        SellButton.gameObject.SetActive(false);
        {
            LocalPlayer.instance.GetInventory().SellItem(item);
            InventoryScreen.instance.RemoveItem(item);
        }
        


    }

    public override void ResetInfos()
    {
        EquipButton.gameObject.SetActive(false);
        SellButton.gameObject.SetActive(false);
        base.ResetInfos();

    }

}
