using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MeleeWeaponConfig", menuName = "Configs/WeaponConfig/RangedWeaponConfig")]
public class RangedWeaponConfig : ScriptableObject
{
    public float RangedWeaponDamage;
    public float CritMultiplier;
    public float FireRate;
    public int CurrentAmmo;
    public int MaxAmmo;
    public float ReloadTime;
    public bool IsScoped;
    public GameObject ProjectilePrefab;
    public float ProjectileSpeed;
    public float ProjectileDestroyingTime;

    public Sprite RangedWeaponSprite;
    public Sprite RangedWeaponIcon;
    public string RangedWeaponDescription;
}
