using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementModel : IEnemyMovement
{
    public float EnemySpeed { get; set; }


    public EnemyMovementModel(EnemyMovementConfig enemyMovementConfig)
    {
        EnemySpeed = enemyMovementConfig.EnemySpeed;
    }
}
