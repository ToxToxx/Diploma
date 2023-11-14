using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerHealthView : MonoBehaviour
{
    // [SerializeField] private Slider _healthSlider;

    private PlayerHealthController _healthController;

    [Inject]
    public void Construct(PlayerHealthController controller)
    {
        _healthController = controller;
        _healthController.OnHealthDecreased += UpdateHealthUI;
    }

    private void UpdateHealthUI(int health)
    {
        Debug.Log(health);
        // _healthSlider.value = health;
    }
}
