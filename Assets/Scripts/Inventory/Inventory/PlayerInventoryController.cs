using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private List<IInventoryItem> _playerInventory;
    [SerializeField] private int _playerInventoryCount;

    [Inject]
    public void Construct()
    {
       
    }

    public void AddItem(IInventoryItem playerInventoryItem)
    {
        if(_playerInventory.Count < _playerInventoryCount)
        {
            _playerInventory.Add(playerInventoryItem);
        }
    }

    public List<IInventoryItem> GetPlayerInventory()
    {
        return _playerInventory;
    }

    public void UsePlayerInventoryItem(IInventoryItem inventoryItem)
    {
        inventoryItem.UseInventoryItem();
        if (inventoryItem.ItemCount == 0)
        {
            _playerInventory.Remove(inventoryItem);
        }
    }
}
