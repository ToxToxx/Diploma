using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryItemType;

public interface IInventoryItem
{
    public string Name { get; set; } 
    public string Description { get; set; }
    public Sprite Sprite { get; set; }
    ItemType Type { get; set; }
    public int ItemCount { get; set; }  
    public void UseInventoryItem();
}
