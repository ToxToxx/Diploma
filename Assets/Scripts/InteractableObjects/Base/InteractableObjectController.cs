using System;
using UnityEngine;


public class InteractableObjectController : MonoBehaviour,IInteractable
{
    private IObject _interactableObjectModel;
    public event EventHandler OnInteractionWithObject;

    private void Awake()
    {
        _interactableObjectModel = new InteractableObjectModel("chest", true);
    }


    public void Interact()
    {
        if (_interactableObjectModel != null)
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
        else
        {
            Debug.LogError("InteractableObjectModel is not initialized!");
        }
    }
}
