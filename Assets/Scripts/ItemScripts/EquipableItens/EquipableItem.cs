using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : Item
{
    public Type type;
    public GameObject Equipement;

}

public enum Type
{
    BodyGear,
    HeadGear
}





