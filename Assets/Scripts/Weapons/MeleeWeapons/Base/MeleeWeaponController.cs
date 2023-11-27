using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MeleeWeaponController : MonoBehaviour, IDisposable
{
    [SerializeField] private MeleeWeaponConfig _meleeWeaponConfig;
    [SerializeField] private LayerMask _enemyMask;

    private IMeleeWeapon _meleeWeaponModel;
    private MeleeWeaponTypeController _meleeWeaponTypeController;

    private PlayerInputSystem _playerInputSystem;
    private bool canAttack = true;
    private float AttackSpeedCoef = 1.0f;

    private bool isAttacking = false;
    private float attackStartTime;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem)
    {
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnAttackPlayerInputPerformed += OnMeleeWeaponAttackPerformed;
        _playerInputSystem.OnAttackPlayerInputStarted += OnMeleeWeaponAttackStarted;
        _playerInputSystem.OnAttackPlayerInputCanceled += OnMeleeWeaponAttackCanceled;
    }

    private void Awake()
    {
        _meleeWeaponTypeController = new MeleeWeaponTypeController();
        _meleeWeaponModel = _meleeWeaponTypeController.InitializeMeleeWeaponType(_meleeWeaponConfig);
    }

    private void OnMeleeWeaponAttackStarted(InputAction.CallbackContext obj)
    {
        isAttacking = true;
        attackStartTime = Time.time;
    }

    private void OnMeleeWeaponAttackCanceled(InputAction.CallbackContext obj)
    {
        isAttacking = false;
    }

    private void OnMeleeWeaponAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack)
        {
            StartCoroutine(AttackCooldown());
            PerformAttack();
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(AttackSpeedCoef / _meleeWeaponModel.AttackSpeed);
        canAttack = true;
    }

    private void PerformAttack()
    {
        float damageMultiplier = isAttacking && (Time.time - attackStartTime) < 1.0f ? 2.0f : 1.0f;

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, _meleeWeaponModel.AttackDistance, _enemyMask);

        foreach (var enemy in enemiesToDamage)
        {
            if (enemy.GetComponent<EnemyHealthController>())
            {
                enemy.GetComponent<EnemyHealthController>().TakeDamage(_meleeWeaponModel.AttackDamage * damageMultiplier);
                Debug.Log(enemy.GetComponent<EnemyHealthController>().GetHealth());
            }
        }
    }

    public void Dispose()
    {
        _playerInputSystem.OnAttackPlayerInputPerformed -= OnMeleeWeaponAttackPerformed;
        _playerInputSystem.OnAttackPlayerInputStarted -= OnMeleeWeaponAttackStarted;
        _playerInputSystem.OnAttackPlayerInputCanceled -= OnMeleeWeaponAttackCanceled;
    }
}
