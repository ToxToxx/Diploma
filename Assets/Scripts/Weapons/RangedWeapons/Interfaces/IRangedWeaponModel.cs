using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangedWeaponModel
{
    public float RangedWeaponDamage { get; set; }
    public float FireRate { get; set; }
    public int CurrentAmmo { get; set; }
    public int MaxAmmo { get; set; }
    public float ReloadTime { get; set; }
    public bool IsScoped { get; set; }
    public GameObject ProjectilePrefab { get; set; }
    public float ProjectileSpeed { get; set; }
    public float ProjectileDestroyingTime { get; set; }
}
