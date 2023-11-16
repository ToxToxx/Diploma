using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerHealthView : MonoBehaviour
{
    private PlayerHealthController _healthController;

    [Inject]
    public void Construct(PlayerHealthController controller)
    {
        _healthController = controller;
        _healthController.OnHealthDecreased += UpdateHealthState;
        _healthController.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    private void UpdateHealthState(int health)
    {
        Debug.Log(health);
    }

    private void OnDestroy()
    {
        _healthController.OnHealthDecreased -= UpdateHealthState;
        _healthController.OnPlayerDeath -= OnPlayerDeath;
    }
}
