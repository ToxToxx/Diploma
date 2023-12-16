using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealthInteractableObjectModel : MonoBehaviour, IInterectableObject
{
    [SerializeField] private GameObject _healthKitModel;
    [SerializeField] private InteractableObjectsConfig _interactableObjectsConfig;

    private InteractableObjectView _interactableObjectView;
    private PlayerInventoryController _playerInventoryController;
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }
    public string DescriptionBoxText { get; set; }

    [Inject]
    public void Construct(InteractableObjectView interactableObjectView, PlayerInventoryController playerInventoryController)
    {
        _interactableObjectView = interactableObjectView;
        _playerInventoryController = playerInventoryController;
    }

    private void Awake()
    {
        InteractableObjectName = _interactableObjectsConfig.InteractableObjectName;
        IsInteractable = _interactableObjectsConfig.IsInteractable;
        DescriptionBoxText = _interactableObjectsConfig.DescriptionBoxText;
    }


    public void InteractReact()
    {
        if (IsInteractable)
        {
            _playerInventoryController.AddPlayerItem(_healthKitModel);
            IsInteractable = false;
            _interactableObjectView.OnInteractionWithObject(DescriptionBoxText);
            Debug.Log("Add health kit");
        }
        else
        {
            Debug.Log(InteractableObjectName + " is not interactable");
        }
    }
}
