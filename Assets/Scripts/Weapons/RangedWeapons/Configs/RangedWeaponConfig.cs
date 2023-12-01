using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeaponConfig", menuName = "Configs/WeaponConfig/RangedWeaponConfig")]
public class RangedWeaponConfig : ScriptableObject
{
    public float RangedWeaponDamage;
    public float FireRate;
    public int CurrentAmmo;
    public int MaxAmmo;
    public float ReloadTime;
    public bool IsScoped;
    public GameObject ProjectilePrefab;
    public float ProjectileSpeed;
    public float ProjectileDestroyingTime;
}
