using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> _playerInventory;
    [SerializeField] private int _playerInventoryCount;

    private void Awake()
    {
        
    }

    public void AddItem(InventoryItem playerInventoryItem)
    {
        if(_playerInventory.Count < _playerInventoryCount)
        {
            _playerInventory.Add(playerInventoryItem);
        }
    }

}
