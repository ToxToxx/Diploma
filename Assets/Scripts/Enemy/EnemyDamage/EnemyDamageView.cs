using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageView : MonoBehaviour
{
    private EnemyDamageController _enemyDamageController;

    private void Start()
    {
        _enemyDamageController = GetComponent<EnemyDamageController>();
        _enemyDamageController.OnDamageDealed += UpdateDamageText;
    }

    private void UpdateDamageText(float damage)
    {
        Debug.Log("Урон: " + damage.ToString());
    }
}
