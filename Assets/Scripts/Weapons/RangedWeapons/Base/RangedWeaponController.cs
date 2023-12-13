using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class RangedWeaponController : MonoBehaviour, IWeaponController
{
    [SerializeField] private RangedWeaponConfig _rangedWeaponConfig;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Transform _rangedWeaponTransform;
    private SwitchItemController _switchItemController;

    private IRangedWeaponModel _rangedWeaponModel;

    private PlayerInputSystem _playerInputSystem;
    private bool canAttack = true;
    private float attackCooldown = 0f;

    public event Action<RangedWeaponConfig> OnReloading;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem, SwitchItemController switchItemController)
    {
        _playerInputSystem = playerInputSystem;
        _switchItemController = switchItemController;
        _playerInputSystem.OnAttackPlayerInputPerformed += OnRangedWeaponAttackPerformed;
        _playerInputSystem.OnAlternativeAttackPlayerInputPerformed += OnRangedWeaponAlternativeAttackPerformed;
        _playerInputSystem.OnPlayerInputReload += OnReloadPerformed;
    }

    private void OnReloadPerformed(InputAction.CallbackContext obj)
    {
        StartCoroutine(Reload());
    }

    private void Awake()
    {
        _rangedWeaponModel = new RangedWeaponModel(_rangedWeaponConfig);
        _rangedWeaponModel.CurrentAmmo = _rangedWeaponModel.MaxAmmo;
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    private void OnRangedWeaponAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack && _switchItemController.GetCurrentItemState() == CurrentItemStateModel.CurrentItemState.Secondary)
        {
            PerformAttack();
        }
    }

    private void OnRangedWeaponAlternativeAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack && _switchItemController.GetCurrentItemState() == CurrentItemStateModel.CurrentItemState.Secondary)
        {
            PerformAlternativeAttack();
        }
    }

    public void PerformAttack()
    {
        if (attackCooldown <= 0f && _rangedWeaponModel.CurrentAmmo > 0)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector2 direction = (mousePosition - transform.position).normalized;
            GameObject projectile = Instantiate(_rangedWeaponModel.ProjectilePrefab, _rangedWeaponTransform.position, Quaternion.identity);
            ProjectileModel projectileModel = projectile.GetComponent<ProjectileModel>();

            projectileModel.Initialize(
                _rangedWeaponModel.RangedWeaponDamage,
                _rangedWeaponModel.CritMultiplier,
                _rangedWeaponModel.ProjectileSpeed,
                _rangedWeaponModel.ProjectileDestroyingTime,
                direction
            );

            projectile.GetComponent<Rigidbody2D>().velocity = direction * _rangedWeaponModel.ProjectileSpeed;

            _rangedWeaponModel.CurrentAmmo--;
            attackCooldown = 1f / _rangedWeaponModel.FireRate;

            if (_rangedWeaponModel.CurrentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }


    public void PerformAlternativeAttack()
    {
        if (_rangedWeaponModel.IsScoped)
        {
            Debug.Log("Scoped aiming activated!");
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(_rangedWeaponModel.ReloadTime);
        OnReloading?.Invoke(_rangedWeaponConfig);
        
    }
    public void ReloadWithAmmo(int amount)
    {
        _rangedWeaponModel.CurrentAmmo += amount;
    }

    public RangedWeaponConfig GetRangedWeaponConfig()
    {
        return _rangedWeaponConfig;
    }

    public IRangedWeaponModel GetRangedWeaponModel()
    {
        return _rangedWeaponModel;
    }

    public void Dispose()
    {
        _playerInputSystem.OnAttackPlayerInputPerformed -= OnRangedWeaponAttackPerformed;
        _playerInputSystem.OnAlternativeAttackPlayerInputPerformed -= OnRangedWeaponAlternativeAttackPerformed;
    }


}
