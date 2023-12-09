using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AmmoController : MonoBehaviour
{
    private PlayerInventoryController _playerInventoryController;
    [SerializeField] private RangedWeaponController _rangedWeaponController;
    private RangedWeaponConfig _rangedWeaponConfig;

    [Inject]
    public void Construct(PlayerInventoryController playerInventoryController)
    {
        _playerInventoryController = playerInventoryController;
        _rangedWeaponController.OnReloading += OnPlayersReloading;
    }

    private void OnPlayersReloading(RangedWeaponConfig obj)
    {
        _rangedWeaponConfig = obj;
        FindAmmoAndReload();
    }

    private void FindAmmoAndReload()
    {
        foreach (IInventoryItem playerInventoryItem in _playerInventoryController.GetPlayerInventory())
        {
            if (playerInventoryItem is IAmmoItem ammoItem && ammoItem.AmmoType == _rangedWeaponConfig.RangedWeaponAmmoType)
            {
                _playerInventoryController.UsePlayerInventoryItem(playerInventoryItem);
            }
        }
    }
}
