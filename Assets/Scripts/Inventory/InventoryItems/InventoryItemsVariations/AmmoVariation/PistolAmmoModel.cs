using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static AmmoType;

public class PistolAmmoModel : MonoBehaviour, IInventoryItem, IAmmoItem
{
    [SerializeField] private RangedWeaponController _rangedWeaponController;
    [SerializeField] public int ItemCount { get; set; }
    public RangedWeaponAmmoType AmmoType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite Sprite { get; set; }

    private void Awake()
    {
        AmmoType = RangedWeaponAmmoType.Pistol;
    }
    public void UseInventoryItem()
    {
        int reloadBulletsAmount;
        if (_rangedWeaponController.GetRangedWeaponModel().CurrentAmmo <= _rangedWeaponController.GetRangedWeaponModel().MaxAmmo && ItemCount > 0)
        {
            reloadBulletsAmount = _rangedWeaponController.GetRangedWeaponModel().MaxAmmo - _rangedWeaponController.GetRangedWeaponModel().CurrentAmmo;
            if (ItemCount  - reloadBulletsAmount > 0)
            {
                _rangedWeaponController.ReloadWithAmmo(reloadBulletsAmount);
                ItemCount -= reloadBulletsAmount;
            } else
            {
                _rangedWeaponController.ReloadWithAmmo(ItemCount);
                ItemCount = 0;
            }                  
        }   
    }
}
