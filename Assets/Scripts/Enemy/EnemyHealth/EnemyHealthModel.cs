using System;

public class EnemyHealthModel : IEnemyHealth
{
    protected float _currentHealth;
    protected float _maxHealth;
    protected float _armor;
    public event Action<float> OnHealthChanged;

    public float Armor
    {
        get { return _armor; }
        set { _armor = value; }
    }
    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public float CurrentHealth
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
        _armor = enemyConfig.Armor;
    }
}