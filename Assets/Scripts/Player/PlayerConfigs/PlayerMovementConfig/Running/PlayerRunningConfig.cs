using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRunningConfig", menuName = "Configs/PlayerConfig/PlayerRunningConfig")]
public class PlayerRunningConfig : ScriptableObject
{
    [field: SerializeField, Range(1, 150)] public float MaxStamina { get; private set; }
    [field: SerializeField, Range(1, 2)] public float SpeedCoef { get; private set; }

    [field: SerializeField, Range(1, 10)] public float StaminaRegenerationRate { get; private set; }
}
