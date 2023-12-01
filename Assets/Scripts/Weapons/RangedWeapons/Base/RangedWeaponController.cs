using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponController : MonoBehaviour
{
    private RangedWeaponModel _rangedWeaponModel;
   // private WeaponView weaponView;

    private float _nextFireTime = 0f;

    private void Start()
    {
        _rangedWeaponModel = GetComponent<RangedWeaponModel>();
        //weaponView = GetComponent<WeaponView>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + 1f / _rangedWeaponModel.FireRate;
        }

        if (Input.GetButtonDown("Reload"))
        {
            _rangedWeaponModel.Reload();
        }

        if (Input.GetButtonDown("ToggleScope"))
        {
            _rangedWeaponModel.ToggleScope(!_rangedWeaponModel.IsScoped);
        }
    }

    private void Shoot()
    {
        _rangedWeaponModel.Shoot();
       // weaponView.PlayShootAnimation();
    }
}
