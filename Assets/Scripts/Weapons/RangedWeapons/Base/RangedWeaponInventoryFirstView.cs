using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RangedWeaponInventoryFirstView : MonoBehaviour
{
    private RangedWeaponController _rangedWeaponController;
    [SerializeField] private Image _rangedWeaponImage;
    [SerializeField] private TextMeshProUGUI _rangedWeaponAmmoText;

    private PlayerInventoryController _playerInventoryController;
    private int _ammoCount;

    [Inject]
    public void Construct(PlayerInventoryController playerInventoryController, RangedWeaponController rangedWeaponController)
    {
        _playerInventoryController = playerInventoryController;
        _rangedWeaponController = rangedWeaponController;
    }

    private void Update()
    {
        if (_rangedWeaponController.GetRangedWeaponConfig().RangedWeaponIcon != null)
        {
            _rangedWeaponImage.sprite = _rangedWeaponController.GetRangedWeaponConfig().RangedWeaponIcon;
        }
        _rangedWeaponAmmoText.text = _rangedWeaponController.GetRangedWeaponModel().CurrentAmmo.ToString() + "/" + GetAmmoCount();
    }

    private int GetAmmoCount()
    {
        _ammoCount = 0;

        foreach (GameObject playerInventoryItem in _playerInventoryController.GetPlayerInventory())
        {
            IInventoryItem inventoryItem = playerInventoryItem.GetComponent<IInventoryItem>();

            if (inventoryItem is not null and AmmoModel)
            {
                AmmoModel ammoModel = (AmmoModel)inventoryItem;
                if (_rangedWeaponController.GetRangedWeaponConfig().RangedWeaponAmmoType == ammoModel.Type)
                {
                    _ammoCount += ammoModel.ItemCount;
                }
            }
        }

        return _ammoCount;
    }

}
