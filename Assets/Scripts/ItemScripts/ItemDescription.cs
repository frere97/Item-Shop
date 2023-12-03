using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public Item item;
    [SerializeField] protected Image ItemImage;
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI itemStats;
    [SerializeField] protected TextMeshProUGUI itemDescription;
    
    
    //making static, because in my idea, we will only have one started at a time;
    public static ItemDescription instance;

    public virtual void OnEnable()
    {
        instance = this;
        ResetInfos();
       

    }
    public void OnDisable()
    {
        instance = null;
        item = null;
    }

    public virtual void SetInfos(Item itemToReceive)
    {
        ResetInfos();
        item = itemToReceive;
        ItemImage.sprite = item.GetItemImage();
        ItemImage.color = new Color(1, 1, 1, 1);
        itemName.text = item.GetItemName();
        
        foreach(ModifierStats itemstats in item.GetItemtats())
        {
            itemStats.text += itemstats.statName + ": " + itemstats.statValue+ "\n";
        }
        itemDescription.text = item.GetDescription();
    }
    public virtual void ResetInfos()
    {

        if (item != null) { item = null; }
        ItemImage.sprite = null;
        itemName.text = "";
        itemStats.text= "";
        itemDescription.text = "";
        
        ItemImage.color = new Color(0, 0, 0, 0);
    }

}
