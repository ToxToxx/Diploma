using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> _playerInventory;
    [SerializeField] private int _playerInventoryCount;

    private void Awake()
    {
        
    }

    public void AddItem(ScriptableObject playerInventoryItem)
    {
        if(_playerInventory.Count < _playerInventoryCount)
        {
            _playerInventory.Add(playerInventoryItem);
        }
    }

}
