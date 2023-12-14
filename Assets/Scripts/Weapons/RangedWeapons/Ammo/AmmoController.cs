using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AmmoController
{
    private PlayerInventoryController _playerInventoryController;
    private RangedWeaponController _rangedWeaponController;
    private RangedWeaponConfig _rangedWeaponConfig;

    [Inject]
    public void Construct(PlayerInventoryController playerInventoryController, RangedWeaponController rangedWeaponController)
    {
        _playerInventoryController = playerInventoryController;
        _rangedWeaponController = rangedWeaponController;
        _rangedWeaponController.OnReloading += OnPlayersReloading;
    }

    private void OnPlayersReloading(RangedWeaponConfig obj)
    {
        _rangedWeaponConfig = obj;
        FindAmmoAndReload();
    }

    private void FindAmmoAndReload()
    {
        var playerInventory = _playerInventoryController.GetPlayerInventory();
        int count = playerInventory.Count;

        for (int i = count - 1; i >= 0; i--)
        {
            var playerInventoryItem = playerInventory[i];
            IInventoryItem ammoItem = playerInventoryItem.GetComponent<IInventoryItem>();

            if (ammoItem != null && ammoItem.Type == _rangedWeaponConfig.RangedWeaponAmmoType)
            {
                _playerInventoryController.UsePlayerInventoryItem(playerInventoryItem);
            }
        }
    }
}
