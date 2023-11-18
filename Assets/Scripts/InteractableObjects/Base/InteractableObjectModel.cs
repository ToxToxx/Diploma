using System;
using UnityEngine;

public class InteractableObjectModel : IObject
{
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }

    public InteractableObjectModel(InteractableObjectsConfig interactableObjectsConfig)
    {
        InteractableObjectName = interactableObjectsConfig.InteractableObjectName;
        IsInteractable = interactableObjectsConfig.IsInteractable;
    }

    public void InteractReact()
    {
        if(IsInteractable)
        {
            IsInteractable = false;
            Debug.Log("You interact with Basic Interactable Object");
        }
    }
}
