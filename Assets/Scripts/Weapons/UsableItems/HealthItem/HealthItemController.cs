using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthItemController : MonoBehaviour
{
    public event EventHandler OnHealthItemUse;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnHealthItemUse?.Invoke(this,EventArgs.Empty);
        }
    }
}
