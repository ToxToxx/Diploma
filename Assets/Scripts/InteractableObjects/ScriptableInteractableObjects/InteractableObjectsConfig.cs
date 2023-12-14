using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObjectsConfig", menuName = "Configs/InteractableObjects/Base")]
public class InteractableObjectsConfig : ScriptableObject
{
    public string InteractableObjectName;
    public bool IsInteractable;
    public string DescriptionBoxText;
    public TypeOfInteractableObject TypeOfObject;

    public enum TypeOfInteractableObject
    {
        Base,
        Ammo,
        Chest,
        Radio,
    }
}
