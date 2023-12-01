using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeaponConfig", menuName = "Configs/WeaponConfig/RangedWeaponConfig")]
public class RangedWeaponConfig : ScriptableObject
{
    public float RangedWeaponDamage;
    public float FireRate;
    public int MaxAmmo;
    public float ReloadTime;
    public bool IsScoped;
    public Transform firePoint;
    public GameObject projectilePrefab;
}
