using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AmmoType;

[CreateAssetMenu(fileName = "AmmoConfig", menuName = "Configs/InventoryItem/AmmoConfig")]
public class AmmoConfig : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public RangedWeaponAmmoType AmmoType;
    public int ItemCount;
}
