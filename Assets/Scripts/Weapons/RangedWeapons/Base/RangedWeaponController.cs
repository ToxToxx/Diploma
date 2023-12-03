using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class RangedWeaponController : MonoBehaviour, IWeaponController
{
    [SerializeField] private RangedWeaponConfig _rangedWeaponConfig;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Transform _rangedWeaponTransform;
    [SerializeField] private bool isWeaponActive = false;

    private IRangedWeaponModel _rangedWeaponModel;

    private PlayerInputSystem _playerInputSystem;
    private bool canAttack = true;
    private float attackCooldown = 0f;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem)
    {
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnAttackPlayerInputPerformed += OnRangedWeaponAttackPerformed;
        _playerInputSystem.OnAlternativeAttackPlayerInputPerformed += OnRangedWeaponAlternativeAttackPerformed;
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
        if (canAttack && isWeaponActive)
        {
            PerformAttack();
        }
    }

    private void OnRangedWeaponAlternativeAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack && isWeaponActive)
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
        _rangedWeaponModel.CurrentAmmo = _rangedWeaponModel.MaxAmmo;
        Debug.Log("Reload complete!");
    }

    public RangedWeaponConfig GetRangedWeaponConfig()
    {
        return _rangedWeaponConfig;
    }

    public void Dispose()
    {
        _playerInputSystem.OnAttackPlayerInputPerformed -= OnRangedWeaponAttackPerformed;
        _playerInputSystem.OnAlternativeAttackPlayerInputPerformed -= OnRangedWeaponAlternativeAttackPerformed;
    }
}
