using System;
using UnityEngine;


public class InteractableObjectController : MonoBehaviour,IInteractable
{
    [SerializeField] private InteractableObjectsConfig _interactableObjectsConfig;
    private IObject _interactableObjectModel;
    public event EventHandler OnInteractionWithObject;
    private InteractableObjectTypeController _interactableObjectsTypeController;


    private void Awake()
    {
        _interactableObjectsTypeController = new InteractableObjectTypeController();
        _interactableObjectModel = _interactableObjectsTypeController.InitializeTypeOfModel(_interactableObjectsConfig);
    }


    public void Interact()
    {
        if (_interactableObjectModel != null)
        {
            _interactableObjectModel.InteractReact();
            OnInteractionWithObject?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.LogError("InteractableObjectModel is not initialized!");
        }
    }
}
