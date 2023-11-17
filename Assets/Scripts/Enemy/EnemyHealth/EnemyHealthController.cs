using System;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    private IEnemyHealth _enemyHealthModel;
    public event Action<float> OnHealthDecreased;
    [SerializeField] private EnemyConfig _enemyConfig;

    private void Awake()
    {
        try
        {
            _enemyHealthModel = new EnemyHealthModel(_enemyConfig);
        }
        catch
        {
            Debug.Log("No enemy health model found");
        }
        
    }
    private void Start()
    {
        Debug.Log(_enemyHealthModel.GetType().Name);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float amount)
    {
        _enemyHealthModel.CurrentHealth -= amount - (amount * _enemyHealthModel.Armor);
        if (_enemyHealthModel.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
        OnHealthDecreased?.Invoke(_enemyHealthModel.CurrentHealth);
    }
}
