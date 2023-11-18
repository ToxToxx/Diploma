using System;
using UnityEditor;
using UnityEngine;

public class PlayerHealthModel
{
    private float _currentHealth;
    private float _maxHealth;

    public float MaxHealth
    {
        get { return _maxHealth; }
    }
    public float Health
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
            OnHealthChanged?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public event Action<float> OnHealthChanged;

    public PlayerHealthModel(float maxHealth)
    {
        _maxHealth = maxHealth;
        Health = maxHealth;
    }

    private void Die()
    {
       
    }
}