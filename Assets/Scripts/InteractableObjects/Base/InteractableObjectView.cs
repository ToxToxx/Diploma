using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectView : MonoBehaviour
{
    private InteractableObjectController _interactableObjectController;

    private void Awake()
    {
        _interactableObjectController = GetComponent<InteractableObjectController>();
        _interactableObjectController.OnInteractionWithObject += OnInteractionWithObject;
    }

    private void OnInteractionWithObject(object sender, EventArgs e)
    {
        Debug.Log("INTERACT VIEW");
    }
}
