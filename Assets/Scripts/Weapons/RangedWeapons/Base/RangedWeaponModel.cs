using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponModel : MonoBehaviour, IRangedWeaponModel
{
    public float RangedWeaponDamage { get; set; }
    public float FireRate { get; set; }
    public int MaxAmmo { get; set; }
    public float ReloadTime {  get; set; }
    public bool IsScoped { get; set; }

    private int currentAmmo;
    private bool isReloading = false;

    public Transform firePoint;
    public GameObject projectilePrefab;

    private void Start()
    {
        currentAmmo = MaxAmmo;
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && !isReloading)
        {
            // Instantiate a projectile and set its properties
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            ProjectileModel projectileModel = projectile.GetComponent<ProjectileModel>();
            projectileModel.SetDamage(RangedWeaponDamage);

            currentAmmo--;

            // Visual and audio feedback for shooting
            // ...

            if (currentAmmo <= 0)
            {
                // Auto-reload or provide feedback to the player
                Reload();
            }
        }
        else if (currentAmmo <= 0 && !isReloading)
        {
            // Auto-reload or provide feedback to the player
            Reload();
        }
    }

    public void Reload()
    {
        if (!isReloading)
        {
            isReloading = true;

            // Visual and audio feedback for reloading
            // ...

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
        // Logic for enabling/disabling scope
        this.IsScoped = isScoped;

        // Visual and audio feedback for toggling scope
        // ...
    }
}
