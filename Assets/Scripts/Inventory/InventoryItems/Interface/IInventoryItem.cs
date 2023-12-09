using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    public string Name { get; set; } 
    public string Description { get; set; }
    public Sprite Sprite { get; set; }

    public int ItemCount { get; set; }  
    public void UseInventoryItem();
}
