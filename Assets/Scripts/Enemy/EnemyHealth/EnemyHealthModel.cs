using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthModel : IEnemyHealth
{
    private int _currentHealth;
    private int _maxHealth;
    public override event Action<int> OnHealthChanged;

    public override int MaxHealth
    {
        get { return _maxHealth; }
    }

    public override int CurrentHealth
    {
        get { return _currentHealth; }
        set { OnHealthChanged?.Invoke(_currentHealth); }
    }

    public EnemyHealthModel(int maxHealth)
    {
        this._maxHealth = maxHealth;
        this._currentHealth = maxHealth;
    }

}