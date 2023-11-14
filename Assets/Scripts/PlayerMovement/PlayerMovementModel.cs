using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementModel
{
    private float _actualSpeed;
    private float _speed;

    public float ActualSpeed { get { return _actualSpeed; } }

    public float Speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            OnSpeedChanged?.Invoke(_speed);
        }
    } 

    public event Action<float> OnSpeedChanged;

    public PlayerMovementModel(float actualSpeed)
    {
        _actualSpeed = actualSpeed;
        Speed = actualSpeed;
    }

}
