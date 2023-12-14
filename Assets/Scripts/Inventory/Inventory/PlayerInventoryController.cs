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

    public void UsePlayerInventoryItem(GameObject inventoryItem)
    {
        inventoryItem.GetComponent<IInventoryItem>().UseInventoryItem();
        if (inventoryItem.GetComponent<IInventoryItem>().ItemCount == 0)
        {
            _playerInventory.Remove(inventoryItem);
        }
    }
    public int GetPlayerInventoryCount()
    {
        return _playerInventoryCount;
    }
    public List<GameObject> GetPlayerInventory()
    {
        return _playerInventory;
    }
}
