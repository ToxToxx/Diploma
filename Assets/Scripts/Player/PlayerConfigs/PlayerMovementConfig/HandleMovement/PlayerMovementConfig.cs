using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Configs/PlayerConfig")]
public class PlayerMovementConfig : ScriptableObject
{
    [field: SerializeField, Range(1, 10)] public float Speed { get; private set; }
    [field: SerializeField] public float JumpPower { get; private set; }

}
