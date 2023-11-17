using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObjectController : IInteractable
{
    private InteractableObjectModel _interactableObjectModel;
    private InteractableObjectView _interactableObjectView;
    public event EventHandler OnInteractionWithObject;

    public void Initialize(InteractableObjectModel model, InteractableObjectView view)
    {
        this._interactableObjectModel = model;
        this._interactableObjectView = view;
        _interactableObjectView.Initialize(this);
    }

    public void Interact()
    {
        if (_interactableObjectModel.IsInteractable)
        {
            Debug.Log("Interacting with " + _interactableObjectModel.InteractableObjectName);
            
        }
        else
        {
            Debug.Log(_interactableObjectModel.InteractableObjectName + " is not interactable.");
        }
        OnInteractionWithObject?.Invoke(this, EventArgs.Empty);
    }
}
