using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryItemType;
using Zenject;
using System;

public class HealthKitModel : MonoBehaviour, IInventoryItem
{
    [SerializeField] private HealthKitConfig _healthKitConfig;
    private HealthItemController _healthItemController;

    private PlayerHealthController _playerHealthController;
    private PlayerInventoryController _playerInventoryController;

    public ItemType Type { get; set; }
    public int ItemCount { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite Sprite { get; set; }
    public int HealingCount { get; set; }


    public event Action<GameObject> OnItemCountZero;

    [Inject]
    public void Construct(PlayerHealthController playerHealthController, PlayerInventoryController playerInventoryController, HealthItemController healthItemController)
    {
        _playerHealthController = playerHealthController;
        _healthItemController = healthItemController;
        _healthItemController.OnHealthItemUse += _healthItemController_OnHealthItemUse;
    }

    private void _healthItemController_OnHealthItemUse(object sender, EventArgs e)
    {
        if (ItemCount > 0)
        {
            UseInventoryItem();
        }
    }

    private void Awake()
    {
        Type = _healthKitConfig.Type;
        Name = _healthKitConfig.Name;
        Description = _healthKitConfig.Description;
        Sprite = _healthKitConfig.Sprite;
        ItemCount = _healthKitConfig.ItemCount;
        HealingCount = _healthKitConfig.HealingCount;
    }

    public void UseInventoryItem()
    {
        if (gameObject != null)
        {
            if (_playerHealthController.GetCurrentHealth() < _playerHealthController.GetMaxHealth() && ItemCount > 0)
            {
                _playerHealthController.HealHealth(HealingCount);
                ItemCount--;
                Debug.Log($"Вы полечились, Осталось {ItemCount} предмета {Name}");
            }
            else
            {
                Debug.Log("Полное здоровье");
            }
            RemoveItemFromInventory();
        }
    }

    public void RemoveItemFromInventory()
    {
        if (ItemCount == 0)
        {
            OnItemCountZero?.Invoke(gameObject);
        }
    }
}
