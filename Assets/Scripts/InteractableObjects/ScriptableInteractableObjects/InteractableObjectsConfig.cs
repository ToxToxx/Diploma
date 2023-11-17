using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObjectsConfig", menuName = "Configs/InteractableObjects/Base")]
public class InteractableObjectsConfig : ScriptableObject
{
    public string InteractableObjectName;
    public bool IsInteractable;
}
