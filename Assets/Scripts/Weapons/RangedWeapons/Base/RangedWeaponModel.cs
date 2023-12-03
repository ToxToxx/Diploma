using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RangedWeaponModel : IRangedWeaponModel
{
    public float RangedWeaponDamage { get; set; }
    public float FireRate { get; set; }
    public int CurrentAmmo { get; set; }
    public int MaxAmmo { get; set; }
    public float ReloadTime {  get; set; }
    public bool IsScoped { get; set; }
    public GameObject ProjectilePrefab { get; set; }
    public float ProjectileSpeed { get; set; }
    public float ProjectileDestroyingTime { get; set; }

    public Sprite RangedWeaponSprite { get; set; }
    public Image RangedWeaponIcon { get; set; }
    public string RangedWeaponDescription { get; set; }

    public RangedWeaponModel(RangedWeaponConfig rangedWeaponConfig)
    {
        RangedWeaponDamage = rangedWeaponConfig.RangedWeaponDamage;
        FireRate = rangedWeaponConfig.FireRate;
        MaxAmmo = rangedWeaponConfig.MaxAmmo;
        ReloadTime = rangedWeaponConfig.ReloadTime;
        IsScoped = rangedWeaponConfig.IsScoped;
        ProjectilePrefab = rangedWeaponConfig.ProjectilePrefab;
        ProjectileSpeed = rangedWeaponConfig.ProjectileSpeed;
        ProjectileDestroyingTime = rangedWeaponConfig.ProjectileDestroyingTime;

        RangedWeaponSprite = rangedWeaponConfig.RangedWeaponSprite;
        RangedWeaponIcon = rangedWeaponConfig.RangedWeaponIcon;
        RangedWeaponDescription = rangedWeaponConfig.RangedWeaponDescription;

        if (rangedWeaponConfig.CurrentAmmo > 0)
        {
            CurrentAmmo = rangedWeaponConfig.CurrentAmmo;
        }
        else
        {
            CurrentAmmo = MaxAmmo;
        }
    }

}
