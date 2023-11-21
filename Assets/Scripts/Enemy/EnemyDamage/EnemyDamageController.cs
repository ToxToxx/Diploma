using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class EnemyDamageController : MonoBehaviour
{
    private IEnemyDamage _enemyDamageModel;

    [SerializeField] private EnemyDamageConfig _enemyDamageConfig;
    private PlayerHealthController _playerHealthController;

    public float _attackCooldown = 3f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealthView>())
        {
            if (_canAttack)
            {
                StartCoroutine(AttackWithCooldown());
            }
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
        _playerHealthController.PlayerTakeDamage(_enemyDamageModel.EnemyDamageAmount);
    }
}
