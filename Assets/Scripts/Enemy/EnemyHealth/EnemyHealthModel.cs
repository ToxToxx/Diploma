using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthModel : IEnemyHealth
{
    private int _currentHealth;
    private int _maxHealth;
    public  event Action<int> OnHealthChanged;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int CurrentHealth
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