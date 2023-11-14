using System;
using UnityEngine;

public class PlayerHealthModel
{
    private int _currentHealth;
    private int _maxHealth;

    public int MaxHealth
    {
        get { return _maxHealth; }
    }
    public int Health
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

    public event Action<int> OnHealthChanged;

    public PlayerHealthModel(int maxHealth)
    {
        _maxHealth = maxHealth;
        Health = maxHealth;
    }

    private void Die()
    {
        // Действия при смерти
    }
}