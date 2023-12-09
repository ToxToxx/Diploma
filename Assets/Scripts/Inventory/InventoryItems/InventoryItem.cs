using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Configs/InventoryItem/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public ScriptableObject InventoryItemConfig;
    public bool IsCountable;
    public int Count;
}
