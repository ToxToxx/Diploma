using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedWeaponInventoryFirstView : MonoBehaviour
{
    [SerializeField] private RangedWeaponController _rangedWeaponController;
    [SerializeField] private Image _rangedWeaponImage;

    private void Update()
    {
        if (_rangedWeaponController.GetRangedWeaponConfig().RangedWeaponIcon != null)
        {
            _rangedWeaponImage.sprite = _rangedWeaponController.GetRangedWeaponConfig().RangedWeaponIcon;
        }
    }

}
