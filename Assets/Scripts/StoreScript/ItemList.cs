using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] GameObject itemButton;
    public List<Item> itensInStore = new List<Item>();

    private void Awake()
    {
        foreach(Item item in itensInStore)
        {
            GameObject itemBtnObj = Instantiate(itemButton, this.transform);
            itemBtnObj.SetActive(true);
            ItemButton itemBtn = itemBtnObj.GetComponent<ItemButton>();
            itemBtn.item = item;
            itemBtn.name = item.GetItemName();
        }
    }

}


