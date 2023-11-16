using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class EnemyHealthVIew : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    [Inject]
    public void SetHealthModel(IEnemyHealth healthModel)
    {
        healthModel.OnHealthChanged += UpdateHealthUI;
    }

    private void UpdateHealthUI(int currentHealth)
    {
        //healthText.text = "Health: " + currentHealth;
        Debug.Log("Health: " + currentHealth);
    }
}
