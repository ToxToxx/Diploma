using System;
using UnityEngine;

public class InteractableObjectModel : IInterectableObject
{
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }
    public string DescriptionBoxText { get; set; }
    public InteractableObjectModel(InteractableObjectsConfig interactableObjectsConfig)
    {
        InteractableObjectName = interactableObjectsConfig.InteractableObjectName;
        IsInteractable = interactableObjectsConfig.IsInteractable;
        DescriptionBoxText = interactableObjectsConfig.DescriptionBoxText;
    }

    public void InteractReact()
    {
        if(IsInteractable)
        {
            Debug.Log("You interact with: " + InteractableObjectName);
        }
        else
        {
            Debug.Log(InteractableObjectName + " is not interactable");
        }
    }
}
