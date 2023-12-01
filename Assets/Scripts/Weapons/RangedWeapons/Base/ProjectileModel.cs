using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileModel : MonoBehaviour
{
    private float _projectileDamage;
    private float _projectileSpeed;
    private float _destroyingTime;
    private Vector2 _shootDirection;

    private void Start()
    { 
        Destroy(gameObject, _destroyingTime);
    }

    public void SetDamage(float newDamage)
    {
        _projectileDamage = newDamage;
    }    
    public void SetSpeed(float projectileSpeed)
    {
        _projectileSpeed = projectileSpeed;
    }    
    public void SetDestroyingTime(float destroyingTime)
    {
        _destroyingTime = destroyingTime;
    }

    public void SetShootDirection(Vector2 direction)
    {
        _shootDirection = direction;
    }

    private void Update()
    {
        transform.Translate(_projectileSpeed * Time.deltaTime * _shootDirection);
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
        else if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }
}

