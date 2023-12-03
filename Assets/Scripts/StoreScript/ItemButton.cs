using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public Item item;
    [SerializeField] Image ItemImage;
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] TextMeshProUGUI ItemPrice;

    void Start()
    {
        ItemImage.sprite = item.GetItemImage();
        ItemName.text = item.GetItemName();
        ItemPrice.text = item.GetItemBuyPrice() + " G";
        
    }

    public void SetInfos()
    {
        ItemDescription.instance.SetInfos(item);
    }
}
