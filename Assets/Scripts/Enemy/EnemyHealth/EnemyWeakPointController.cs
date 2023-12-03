using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakPointController : MonoBehaviour
{
    [SerializeField] private EnemyHealthController _enemyHealthController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ProjectileModel>(out var projectileModel))
        {
            _enemyHealthController.TakeDamage(projectileModel.GetDamage() * projectileModel.GetCritMultiplier());
        }
    }
}
