using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AmmoType;

public interface IAmmoItem
{
    public int ItemCount { get; set; }
    public RangedWeaponAmmoType AmmoType { get; set; }
}
