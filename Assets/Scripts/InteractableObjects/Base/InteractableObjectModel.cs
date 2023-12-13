using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractableObjectModel : MonoBehaviour,IInterectableObject
{
    [SerializeField] private InteractableObjectsConfig _interactableObjectsConfig;
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }
    public string DescriptionBoxText { get; set; }
    private void Awake()
    {
        InteractableObjectName = _interactableObjectsConfig.InteractableObjectName;
        IsInteractable = _interactableObjectsConfig.IsInteractable;
        DescriptionBoxText = _interactableObjectsConfig.DescriptionBoxText;
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
