using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemyHealth : MonoBehaviour
{
    public virtual int CurrentHealth { get; set; }
    public virtual int MaxHealth { get; set; }

    public event Action<int> OnHealthChanged;

}
