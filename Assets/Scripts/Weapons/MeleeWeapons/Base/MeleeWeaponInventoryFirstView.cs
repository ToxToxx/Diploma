using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWeaponInventoryFirstView : MonoBehaviour
{
    [SerializeField] private MeleeWeaponController _meleeWeaponController;

    [SerializeField] private Image _meleeWeaponImage;

    private void Update()
    {
        if (_meleeWeaponController.GetMeleeWeaponConfig().WeaponSprite != null)
        {
            _meleeWeaponImage.sprite = _meleeWeaponController.GetMeleeWeaponConfig().WeaponSprite;
        }
    }

}
