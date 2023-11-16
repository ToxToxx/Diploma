using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealth
{
    public float CurrentHealth {get; set;}
    public float MaxHealth { get; set;}

    public event Action<float> OnHealthChanged;

    public float Armor { get; set;}
}
