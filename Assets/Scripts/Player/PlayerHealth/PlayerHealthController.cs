using System;
using UnityEngine;
using Zenject;

public class PlayerHealthController : ITickable
{
    public event Action<float> OnHealthDecreased;
    public event EventHandler OnPlayerDeath;
    private PlayerHealthModel _healthModel;
    private bool _isSecondChance;

    [Inject]
    public void Construct(PlayerHealthModel healthModel)
    {
        _healthModel = healthModel;
        _isSecondChance = true;
    }


    public void Tick()
    {

    }

    public void PlayerTakeDamage(float damageAmount)
    {
        if (_healthModel.Health > 0)
        {
            _healthModel.Health -= damageAmount;
            OnHealthDecreased(_healthModel.Health);
        }
        else if (_isSecondChance)
        {
            _healthModel.Health = 5;
            _isSecondChance = false;
        }
        else
        {
            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    public float GetMaxHealth()
    {
        return _healthModel.MaxHealth;
    }
}