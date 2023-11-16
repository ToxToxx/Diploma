using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealth
{
    public  int CurrentHealth {get; set;}
    public  int MaxHealth { get; set;}

    public event Action<int> OnHealthChanged;
}
