using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementModel
{
    private float _actualSpeed;

    public float Speed { get { return Speed; } set { OnSpeedChanged?.Invoke(Speed); } }

    public event Action<float> OnSpeedChanged;

    public PlayerMovementModel(float actualSpeed)
    {
        _actualSpeed = actualSpeed;
        Speed = actualSpeed;
    }

}
