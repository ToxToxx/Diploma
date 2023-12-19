using ModestTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using static UnityEditor.Progress;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] List<GameObject> _playerInventory;
    [SerializeField] private int _playerInventoryCount;

    public event EventHandler OnUpdateInventoryCount;

    private void Start()
    {
        if (_playerInventory == null)
        {
            _playerInventory = new List<GameObject>();
        }
    }
    public void AddPlayerItem(GameObject playerInventoryItem)
    {
        if (_playerInventory.Count < _playerInventoryCount)
        {
            _playerInventory.Add(playerInventoryItem);
            playerInventoryItem.GetComponent<IInventoryItem>().OnItemCountZero += RemoveItem;
        }
    }

    private void RemoveItem(GameObject obj)
    {
        _playerInventory.Remove(obj);
    }

    public void ChangeInventoryCount(int count)
    {
        _playerInventoryCount = count;
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


}
