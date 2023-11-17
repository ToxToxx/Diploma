using System;
using UnityEngine;


public class InteractableObjectController : MonoBehaviour,IInteractable
{
    private IOjbect _interactableObjectModel;
    private InteractableObjectView _interactableObjectView;
    public event EventHandler OnInteractionWithObject;

    public void Initialize(IOjbect model, InteractableObjectView view)
    {
        model = new InteractableObjectModel("Chest", true);
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
