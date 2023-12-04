using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] GameObject ShopScreen;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<LocalPlayer>() == LocalPlayer.instance)
        {
            ShopScreen.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<LocalPlayer>() == LocalPlayer.instance)
        {
            ShopScreen.SetActive(false);
        }
    }

}
