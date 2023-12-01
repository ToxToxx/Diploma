using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileModel : MonoBehaviour
{
    private float _projectileDamage;

    public void SetDamage(float newDamage)
    {
        _projectileDamage = newDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealthController>())
        {
            if (collision.TryGetComponent<EnemyHealthController>(out var enemyModel))
            {
                enemyModel.TakeDamage(_projectileDamage);
            }
            Destroy(gameObject);
        }
    }
}
