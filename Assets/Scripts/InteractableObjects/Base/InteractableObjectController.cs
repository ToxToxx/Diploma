using System;
using UnityEngine;


public class InteractableObjectController : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject _interactableObjectModel;

    public event Action<string> OnInteractionWithObject;

    public void Interact()
    {
        if (_interactableObjectModel != null)
        {
            _interactableObjectModel.GetComponent<IInterectableObject>().InteractReact();
            OnInteractionWithObject?.Invoke(_interactableObjectModel.GetComponent<IInterectableObject>().DescriptionBoxText);
        }
        else
        {
            Debug.LogError("InteractableObjectModel is not initialized!");
        }
    }
}
