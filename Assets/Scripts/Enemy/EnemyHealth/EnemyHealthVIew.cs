using UnityEngine;


public class EnemyHealthView : MonoBehaviour
{
    private EnemyHealthController _enemyHealthController;
    private void Start()
    {
        try
        {
            _enemyHealthController = GetComponent<EnemyHealthController>();
        }
        catch
        {
            Debug.Log("No enemy health controller is attached");
        }

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
