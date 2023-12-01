using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RangedWeaponModel : MonoBehaviour, IRangedWeaponModel
{
    public float RangedWeaponDamage { get; set; }
    public float FireRate { get; set; }
    public int MaxAmmo { get; set; }
    public float ReloadTime {  get; set; }
    public bool IsScoped { get; set; }

    private int currentAmmo;
    private bool isReloading = false;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;


    [Inject]
    public void Construct(RangedWeaponConfig rangedWeaponConfig)
    {
        RangedWeaponDamage = rangedWeaponConfig.RangedWeaponDamage;
        FireRate = rangedWeaponConfig.FireRate;
        MaxAmmo = rangedWeaponConfig.MaxAmmo;
        ReloadTime = rangedWeaponConfig.ReloadTime;
        IsScoped = rangedWeaponConfig.IsScoped;
    }

    private void Start()
    {
        currentAmmo = MaxAmmo;
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && !isReloading)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            ProjectileModel projectileModel = projectile.GetComponent<ProjectileModel>();
            projectileModel.SetDamage(RangedWeaponDamage);

            currentAmmo--;

            if (currentAmmo <= 0)
            {
                Reload();
            }
        }
        else if (currentAmmo <= 0 && !isReloading)
        {
            Reload();
        }
    }

    public void Reload()
    {
        if (!isReloading)
        {
            isReloading = true;
            Invoke(nameof(FinishReload), ReloadTime);
        }
    }

    private void FinishReload()
    {
        currentAmmo = MaxAmmo;
        isReloading = false;
    }

    public void ToggleScope(bool isScoped)
    {
        this.IsScoped = isScoped;
    }
}
