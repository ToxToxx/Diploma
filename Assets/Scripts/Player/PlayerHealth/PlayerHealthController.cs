using System;
using UnityEngine;
using Zenject;

public class PlayerHealthController : ITickable
{
    public event Action<float> OnHealthDecreased;
    public event EventHandler OnPlayerDeath;
    private PlayerHealthModel _healthModel;

    [Inject]
    public void Construct(PlayerHealthModel healthModel)
    {
        _healthModel = healthModel;
    }


    public void Tick()
    {
        if(_healthModel.Health > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _healthModel.Health -= 10;
                OnHealthDecreased(_healthModel.Health);
            }
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