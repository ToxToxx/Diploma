using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyHealthController : IInitializable, ITickable
{
    private IEnemyHealth _enemyHealthModel;
    private EnemyHealthVIew _enemyHealthView;
    public event Action<int> OnHealthChanged;

    [Inject]
    public void Construct(IEnemyHealth healthModel, EnemyHealthVIew healthView)
    {
        this._enemyHealthModel = healthModel;
        this._enemyHealthView = healthView;
    }

    public void Initialize()
    {
        _enemyHealthView.SetHealthModel(_enemyHealthModel);
    }

    public void Tick()
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
            _enemyHealthModel.CurrentHealth = 0;
        }
    }
}
