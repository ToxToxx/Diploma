using System;
using UnityEngine;


public class InteractableObjectController : MonoBehaviour,IInteractable
{
    [SerializeField] private InteractableObjectsConfig _interactableObjectsConfig;
    private InteractableObjectModel _interactableObjectModel;
    public event EventHandler OnInteractionWithObject;


    private void Awake()
    {
        _interactableObjectModel = new InteractableObjectModel(_interactableObjectsConfig);
    }


    public void Interact()
    {
        if (_interactableObjectModel != null)
        {
            if (_interactableObjectModel.IsInteractable)
            {
                Debug.Log("Interacting with " + _interactableObjectModel.InteractableObjectName);
                _interactableObjectModel.InteractReact();
                OnInteractionWithObject?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Debug.Log(_interactableObjectModel.InteractableObjectName + " is not interactable.");
            }   
        }
        else
        {
            Debug.LogError("InteractableObjectModel is not initialized!");
        }
    }
}
