using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static InventoryItemType;

public class AmmoModel : MonoBehaviour, IInventoryItem
{
    [SerializeField] private AmmoConfig _pistolAmmoConfig;
    private RangedWeaponController _rangedWeaponController;
    private PlayerInventoryController _playerInventoryController;
    public ItemType Type { get; set; }
    public int ItemCount { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite Sprite { get; set; }

    public event Action<GameObject> OnItemCountZero;


    [Inject]
    public void Construct(RangedWeaponController rangedWeaponController, PlayerInventoryController playerInventoryController)
    {
        _rangedWeaponController = rangedWeaponController;
        _playerInventoryController = playerInventoryController;
    }

    private void Awake()
    {
        Type = _pistolAmmoConfig.Type;
        Name = _pistolAmmoConfig.Name;
        Description = _pistolAmmoConfig.Description;
        Sprite = _pistolAmmoConfig.Sprite;
        ItemCount = _pistolAmmoConfig.ItemCount;
    }
    public void UseInventoryItem()
    {
        if(gameObject != null)
        {
            int reloadBulletsAmount;
            if (_rangedWeaponController.GetRangedWeaponModel().CurrentAmmo <= _rangedWeaponController.GetRangedWeaponModel().MaxAmmo && ItemCount > 0)
            {
                reloadBulletsAmount = _rangedWeaponController.GetRangedWeaponModel().MaxAmmo - _rangedWeaponController.GetRangedWeaponModel().CurrentAmmo;
                if (ItemCount - reloadBulletsAmount > 0)
                {
                    _rangedWeaponController.ReloadWithAmmo(reloadBulletsAmount);
                    ItemCount -= reloadBulletsAmount;
                }
                else
                {
                    _rangedWeaponController.ReloadWithAmmo(ItemCount);
                    ItemCount = 0;   
                }
            }
            Debug.Log("Reload Complete bullets left in pack: " + ItemCount);
            RemoveItemFromInventory();
        }
    }

    public void RemoveItemFromInventory()
    {
        if (ItemCount <= 0)
        {
            OnItemCountZero?.Invoke(gameObject);
        }
    }
}
