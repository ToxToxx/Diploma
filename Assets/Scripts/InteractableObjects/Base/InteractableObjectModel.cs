using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class InteractableObjectModel : MonoBehaviour,IInterectableObject
{
    [SerializeField] private InteractableObjectsConfig _interactableObjectsConfig;
    private InteractableObjectView _interactableObjectView;
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }
    public string DescriptionBoxText { get; set; }

    [Inject]
    public void Construct(InteractableObjectView interactableObjectView)
    {
        _interactableObjectView = interactableObjectView;
    }

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
            _interactableObjectView.OnInteractionWithObject(DescriptionBoxText);
        }
        else
        {
            Debug.Log(InteractableObjectName + " is not interactable");
        }
    }
}
