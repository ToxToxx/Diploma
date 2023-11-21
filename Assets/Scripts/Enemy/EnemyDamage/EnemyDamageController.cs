using System.Collections;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class EnemyDamageController : MonoBehaviour
{
    private IEnemyDamage _enemyDamageModel;
    [SerializeField] private EnemyDamageConfig _enemyDamageConfig;
    [SerializeField] private GameObject _playerGameObject;

    private PlayerHealthController _playerHealthController;

    [SerializeField] private float _attackRadius = 2f;
    [SerializeField] private float _attackCooldown = 3f;

    private bool _canAttack = true;

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
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _playerGameObject.transform.position);

        if (distanceToPlayer <= _attackRadius && _canAttack)
        {
            StartCoroutine(AttackWithCooldown());
        }
    }

    IEnumerator AttackWithCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        AttackPlayer();
        _canAttack = true;
    }

    void AttackPlayer()
    {
        if (_playerGameObject != null)
        {
            _playerHealthController.PlayerTakeDamage(_enemyDamageModel.EnemyDamageAmount);
        }
    }
}
