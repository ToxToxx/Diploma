using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerHealthView : MonoBehaviour
{
    private PlayerHealthController _healthController;

    [SerializeField] private Image _healthBarUI;
    [SerializeField] private TextMeshProUGUI _healthBarText;

    private float _currentHealth;
    private float _maxHealthPlayer;

    [Inject]
    public void Construct(PlayerHealthController controller)
    {
        _healthController = controller;
        _healthController.OnHealthDecreased += UpdateHealthState;
        _healthController.OnPlayerDeath += OnPlayerDeath;
        _maxHealthPlayer = _healthController.GetMaxHealth();
        _healthBarText.text = "100";
    }
    private void OnPlayerDeath(object sender, EventArgs e)
    {
       Time.timeScale = 0;
    }

    private void UpdateHealthState(float health)
    {
        _currentHealth = health;
        _healthBarText.text = "" + _currentHealth;
        float fillAmount = _currentHealth / _maxHealthPlayer;
        _healthBarUI.fillAmount = fillAmount;
    }

    private void OnDestroy()
    {
        _healthController.OnHealthDecreased -= UpdateHealthState;
        _healthController.OnPlayerDeath -= OnPlayerDeath;
    }
}
