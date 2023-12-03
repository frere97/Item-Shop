using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static LocalPlayer instance;
     [SerializeField] PlayerInventory inventory;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one localPlayer. Destroying the others to keep only one Instance");
            Destroy(instance.gameObject);
            
        }
        instance = this;

        if(inventory == null)
        {
            inventory = new PlayerInventory();
        }
        
    }

    public PlayerInventory GetInventory()
    {
        return inventory;
    }

}
