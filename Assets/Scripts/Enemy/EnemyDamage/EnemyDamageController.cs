using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class EnemyDamageController : MonoBehaviour
{
    private IEnemyDamage _enemyDamageModel;

    [SerializeField] private EnemyDamageConfig _enemyDamageConfig;
    [SerializeField] private GameObject _playerGameObject;

    public event Action<float> OnDamageDealed;

    private PlayerHealthController _playerHealthController;

    [SerializeField] private float _attackCooldown = 3f;

    private bool _canAttack;

    [Inject]
    public void Construct(PlayerHealthController playerHealthController)
    {
        _playerHealthController = playerHealthController;
    }

    private void Awake()
    {
        try
        {
            _enemyDamageModel = new EnemyDamageModel(_enemyDamageConfig);
        }
        catch
        {
            Debug.Log("No enemy damage model found");
        }
        _canAttack = true;
    }
    
    IEnumerator AttackWithCooldown()
    {
        AttackPlayer();
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }

    void AttackPlayer()
    {
        if (_playerGameObject != null)
        {
            _playerHealthController.PlayerTakeDamage(_enemyDamageModel.EnemyDamageAmount);
            OnDamageDealed?.Invoke(_enemyDamageModel.EnemyDamageAmount);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_canAttack && collision.gameObject == _playerGameObject)
        {
            StartCoroutine(AttackWithCooldown());
        }
    }
}
