using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;
    [SerializeField] GameObject itemButton;
    [SerializeField] Transform ButtonsListHolder;
    [SerializeField] List<ItemButton> AllButtons;
    public static InventoryScreen instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        if(inventory == null)
        {
            inventory = LocalPlayer.instance.GetInventory();
        }
        foreach(Item item in inventory.GetPlayerItems())
        {
            GameObject itemBtnObj = Instantiate(itemButton, ButtonsListHolder);
            itemBtnObj.SetActive(true);
            ItemButton itemBtn = itemBtnObj.GetComponent<ItemButton>();
            itemBtn.item = item;
            itemBtn.name = item.GetItemName();
            AllButtons.Add(itemBtn);
        }
    }

    private void OnDisable()
    {
        while(AllButtons.Count > 0)
        {
            Destroy(AllButtons[0].gameObject);
            AllButtons.Remove(AllButtons[0]);
        }
    }

    public void RemoveItem(Item item)
    {
        foreach(ItemButton button in AllButtons)
        {
            if(button.item == item)
            {
                AllButtons.Remove(button);
                Destroy(button.gameObject);
            }
        }
    }

}
