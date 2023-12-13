using UnityEngine;
using static InventoryItemType;

[CreateAssetMenu(fileName = "RangedWeaponConfig", menuName = "Configs/WeaponConfig/RangedWeaponConfig")]
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

    public ItemType RangedWeaponAmmoType;
}
