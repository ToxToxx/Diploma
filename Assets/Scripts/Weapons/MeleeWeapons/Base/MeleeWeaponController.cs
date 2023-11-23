using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MeleeWeaponController : MonoBehaviour
{
    [SerializeField] private MeleeWeaponConfig _meleeWeaponConfig;
    [SerializeField] private LayerMask _enemyMask;

    private IMeleeWeapon _meleeWeaponModel;
    private MeleeWeaponTypeController _meleeWeaponTypeController;

    private PlayerInputSystem _playerInputSystem;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem)
    {
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnAttackPlayerInputPerformed += OnMeleeWeaponAttackPerformed;
    }

    private void OnMeleeWeaponAttackPerformed(InputAction.CallbackContext obj)
    {
        PerformAttack();
    }

    private void Awake()
    {
        _meleeWeaponTypeController = new MeleeWeaponTypeController();
        _meleeWeaponModel = _meleeWeaponTypeController.InitializeMeleeWeaponType(_meleeWeaponConfig);
    }
    private void PerformAttack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, _meleeWeaponModel.AttackDistance, _enemyMask);
        foreach (var enemy in enemiesToDamage)
        {
            if (enemy.GetComponent<EnemyHealthController>())
            {
                enemy.GetComponent<EnemyHealthController>().TakeDamage(_meleeWeaponModel.AttackDamage);
                Debug.Log(enemy.GetComponent<EnemyHealthController>().GetHealth());
            }
        }
    }
}
