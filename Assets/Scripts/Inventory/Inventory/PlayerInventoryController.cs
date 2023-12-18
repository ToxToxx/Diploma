using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] List<GameObject> _playerInventory;
    [SerializeField] private int _playerInventoryCount;

    public void AddPlayerItem(GameObject playerInventoryItem)
    {
        if (_playerInventory.Count < _playerInventoryCount)
        {
            _playerInventory.Add(playerInventoryItem);
        }
    }
    private void Update()
    {
        RemoveInventoryItem();
    }
    public void UsePlayerInventoryItem(GameObject inventoryItem)
    {
        inventoryItem.GetComponent<IInventoryItem>().UseInventoryItem();
    }
    public int GetPlayerInventoryCount()
    {
        return _playerInventoryCount;
    }
    public List<GameObject> GetPlayerInventory()
    {
        return _playerInventory;
    }

    public void RemoveInventoryItem()
    {
        foreach(var item in _playerInventory)
        {
            if (item.GetComponent<IInventoryItem>().ItemCount <= 0)
            {
                _playerInventory.Remove(item);
            }
        }
    }
}
