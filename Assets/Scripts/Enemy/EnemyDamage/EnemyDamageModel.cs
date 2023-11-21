using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageModel : IEnemyDamage
{
   public float EnemyDamageAmount { get; set; }
    

   public EnemyDamageModel (EnemyDamageConfig enemyDamageConfig)
    {
        EnemyDamageAmount = enemyDamageConfig.DamageAmount;
    }
}
