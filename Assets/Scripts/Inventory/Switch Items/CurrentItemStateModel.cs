using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentItemStateModel
{
    public CurrentItemState CurrentItemType;
    public enum CurrentItemState
    {
        Primary,
        Secondary,
        FirstUsableItem,
        SecondaryUsableItem,
        ThirdUsableItem,
    }
}
