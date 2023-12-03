using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileModel : MonoBehaviour
{
    private const string ENEMY_LAYER = "Enemy";
    private const string PLAYER_LAYER = "Player";

    private float _projectileDamage;
    private float _projectileSpeed;
    private float _destroyingTime;
    private Vector2 _shootDirection;

    private float _critMultiplier;

    private void Start()
    { 
        Destroy(gameObject, _destroyingTime);
    }

    public void SetDamage(float newDamage)
    {
        _projectileDamage = newDamage;
    }  

    public void SetCritMultiplier(float critMultiplier)
    {
        _critMultiplier = critMultiplier;
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
    public void Initialize(float damage, float critMultiplier, float speed, float destroyingTime, Vector2 shootDirection)
    {
        SetDamage(damage);
        SetCritMultiplier(critMultiplier);
        SetSpeed(speed);
        SetDestroyingTime(destroyingTime);
        SetShootDirection(shootDirection);
    }

    private void Update()
    {
        transform.Translate(_projectileSpeed * Time.deltaTime * _shootDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(ENEMY_LAYER))
        {
            if (collision.TryGetComponent<EnemyHealthController>(out var enemyModel))
            {
                float totalDamage = _projectileDamage;
                enemyModel.TakeDamage(totalDamage);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer(PLAYER_LAYER))
        {
            Destroy(gameObject);
        }
    }

    public float GetDamage()
    {
        return _projectileDamage;
    }
    public float GetCritMultiplier()
    {
        return _critMultiplier;
    }
}

