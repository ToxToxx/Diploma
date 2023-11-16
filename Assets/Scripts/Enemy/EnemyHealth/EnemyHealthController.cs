using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyHealthController : MonoBehaviour
{
    private IEnemyHealth _enemyHealthModel;
    private EnemyHealthView _enemyHealthView;
    public event Action<int> OnHealthDecreased;
    [SerializeField] private EnemyConfig _enemyConfig;

    private void Awake()
    {
        _enemyHealthModel = new EnemyHealthModel(_enemyConfig);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10);
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
