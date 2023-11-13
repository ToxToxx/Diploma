using System;
using UnityEngine;
using Zenject;

public class PlayerHealthController : ITickable
{
    public event Action<int> OnHealthDecreased;
    private PlayerHealthModel _healthModel;

    [Inject]
    public void Construct(PlayerHealthModel healthModel)
    {
        _healthModel = healthModel;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _healthModel.Health -= 10;
            OnHealthDecreased(_healthModel.Health);
        }
    }
}