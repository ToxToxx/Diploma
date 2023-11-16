using System;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    private IEnemyHealth _enemyHealthModel;
    public event Action<int> OnHealthDecreased;
    [SerializeField] private EnemyConfig _enemyConfig;

    private void Awake()
    {
        SetEnemyHealthModel();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10);
        }
    }

    public void SetEnemyHealthModel()
    {
        switch (_enemyConfig.HealthModelType)
        {
            case EnemyConfig.TypeHealthModel.Default:
                _enemyHealthModel = new EnemyHealthModel(_enemyConfig);
                break;
        }
    }

    public void TakeDamage(int amount)
    {
        _enemyHealthModel.CurrentHealth -= amount;

        if (_enemyHealthModel.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
        OnHealthDecreased?.Invoke(_enemyHealthModel.CurrentHealth);
    }
}
