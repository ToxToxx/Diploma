using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MeleeWeaponController : MonoBehaviour, IDisposable
{
    [SerializeField] private MeleeWeaponConfig _meleeWeaponConfig;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Transform _playerTransform;

    private IMeleeWeapon _meleeWeaponModel;
    private MeleeWeaponTypeController _meleeWeaponTypeController;

    private PlayerInputSystem _playerInputSystem;
    private PlayerStaminaAndRunController _playerStaminaAndRunController;

    private bool canAttack = true;
    private float AttackSpeedCoef = 1.0f;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem, PlayerStaminaAndRunController playerStaminaAndRunController)
    {
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnAttackPlayerInputPerformed += OnMeleeWeaponAttackPerformed;
        _playerInputSystem.OnAlternativeAttackPlayerInputPerformed += OnMeleeWeaponAlternativeAttackPerformed;

        _playerStaminaAndRunController = playerStaminaAndRunController;
    }

    private void Awake()
    {
        _meleeWeaponTypeController = new MeleeWeaponTypeController();
        _meleeWeaponModel = _meleeWeaponTypeController.InitializeMeleeWeaponType(_meleeWeaponConfig);
    }

    private void OnMeleeWeaponAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack)
        {
            StartCoroutine(AttackCooldown());
            PerformAttack();
        }
    }

    private void OnMeleeWeaponAlternativeAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack && _playerStaminaAndRunController.GetCurrentStamina() >= _meleeWeaponModel.AlternativeAttackStaminaCost)
        {
            _playerStaminaAndRunController.DecreaseStaminaOnAmount(_meleeWeaponModel.AlternativeAttackStaminaCost);

            StartCoroutine(AttackCooldown());
            PerformAlternativeAttack();
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
        Vector2 attackPosition = DetermineTheAttackDirection();
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition, _meleeWeaponModel.AttackDistance, _enemyMask);

        foreach (var enemy in enemiesToDamage)
        {
            if (enemy.GetComponent<EnemyHealthController>())
            {
                enemy.GetComponent<EnemyHealthController>().TakeDamage(_meleeWeaponModel.AttackDamage);
            }
        }
    }

    private void PerformAlternativeAttack()
    {
        Vector2 attackPosition = DetermineTheAttackDirection();
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition, _meleeWeaponModel.AttackDistance, _enemyMask);

        foreach (var enemy in enemiesToDamage)
        {
            if (enemy.GetComponent<EnemyHealthController>())
            {
                enemy.GetComponent<EnemyHealthController>().TakeDamage(_meleeWeaponModel.AttackDamage * _meleeWeaponModel.AlternativeAttackCritDamage);
            }
        }
    }

    private Vector2 DetermineTheAttackDirection()
    {
        float attackDirectionX = _playerTransform.localScale.x;
        Vector2 attackPosition = (Vector2)_playerTransform.position + new Vector2(attackDirectionX, 0) * _meleeWeaponModel.AttackDistance;
        return attackPosition;
    }


    public MeleeWeaponConfig GetMeleeWeaponConfig()
    {
        return _meleeWeaponConfig;
    }
    public void Dispose()
    {
        _playerInputSystem.OnAttackPlayerInputPerformed -= OnMeleeWeaponAttackPerformed;
    }


}
