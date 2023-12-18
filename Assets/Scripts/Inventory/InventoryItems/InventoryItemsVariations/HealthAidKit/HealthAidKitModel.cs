using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryItemType;
using Zenject;

public class HealthAidKitModel : MonoBehaviour
{
    [SerializeField] private AmmoConfig _healthKitConfig;
    private PlayerHealthController _playerHealthController;
    public ItemType Type { get; set; }
    public int ItemCount { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite Sprite { get; set; }
    public int HealingCount { get; set; }

    [Inject]
    public void Construct(PlayerHealthController playerHealthController)
    {
        _playerHealthController = playerHealthController;
    }

    private void Awake()
    {
        Type = _healthKitConfig.Type;
        Name = _healthKitConfig.Name;
        Description = _healthKitConfig.Description;
        Sprite = _healthKitConfig.Sprite;
        ItemCount = _healthKitConfig.ItemCount;
    }
    public void UseInventoryItem()
    {
        if (gameObject != null)
        {
            if (_playerHealthController.GetPlayerHealthModel().Health <= _playerHealthController.GetPlayerHealthModel().MaxHealth && ItemCount > 0)
            {
                _playerHealthController.GetPlayerHealthModel().Health += HealingCount;
                ItemCount--;
            }
            Debug.Log($"Healing complete {ItemCount} of {Name} is left");
        }
    }

}
