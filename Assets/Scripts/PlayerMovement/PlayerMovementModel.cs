using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementModel
{
    private float _currentSpeed;
    private float _actualSpeed;

    public float Speed
    {
        get { return _currentSpeed; }
        set
        {
            OnSpeedChanged?.Invoke(_currentSpeed);
        }
    }

    public event Action<float> OnSpeedChanged;

    public PlayerMovementModel(float actualSpeed)
    {
        _actualSpeed = actualSpeed;
        Speed = actualSpeed;
    }

}
