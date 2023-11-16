using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class EnemyHealthView : MonoBehaviour
{
    private EnemyHealthController _enemyHealthController;
    private void Start()
    {
        _enemyHealthController = GetComponent<EnemyHealthController>();

        if (_enemyHealthController != null)
        {
            _enemyHealthController.OnHealthDecreased += UpdateHealthUI;
        }
    }


    private void UpdateHealthUI(int currentHealth)
    {
        Debug.Log("Health: " + currentHealth);
    }

    private void OnDisable()
    {
        if (_enemyHealthController != null)
        {
            _enemyHealthController.OnHealthDecreased -= UpdateHealthUI;
        }
    }

}
