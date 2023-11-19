using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunModel
{
    public float CurrentStamina { get; set; }
    public float MaxStamina { get; private set; }
    public float SpeedCoef { get; private set; }

    public PlayerRunModel(PlayerRunningConfig playerRunningConfig)
    {
        MaxStamina = playerRunningConfig.MaxStamina;
        SpeedCoef = playerRunningConfig.SpeedCoef;
        CurrentStamina = MaxStamina;
    }
}
