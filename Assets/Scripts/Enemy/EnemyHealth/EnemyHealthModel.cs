using System;

public class EnemyHealthModel : IEnemyHealth
{
    private int _currentHealth;
    private int _maxHealth;
    public event Action<int> OnHealthChanged;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }

    public EnemyHealthModel(EnemyConfig enemyConfig)
    {
        _maxHealth = enemyConfig.MaxHealth;
        _currentHealth = _maxHealth;
    }
}