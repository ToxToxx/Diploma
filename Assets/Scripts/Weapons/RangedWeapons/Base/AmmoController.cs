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
        var playerInventory = _playerInventoryController.GetPlayerInventory();
        int count = playerInventory.Count;

        for (int i = count - 1; i >= 0; i--)
        {
            var playerInventoryItem = playerInventory[i];
            IAmmoItem ammoItem = playerInventoryItem.gameObject.GetComponent<IAmmoItem>();

            if (ammoItem != null && ammoItem.AmmoType == _rangedWeaponConfig.RangedWeaponAmmoType)
            {
                _playerInventoryController.UsePlayerInventoryItem(playerInventoryItem);
            }
        }
    }
}
