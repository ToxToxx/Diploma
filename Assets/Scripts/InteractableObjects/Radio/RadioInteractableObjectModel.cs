using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RadioInteractableObjectModel : MonoBehaviour, IInterectableObject
{
    [SerializeField] private InteractableObjectsConfig _interactableObjectsConfig;
    [SerializeField] private AudioClip _radioClip;

    private InteractableObjectView _interactableObjectView;
    private AudioSource _audioSource; 
    

    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }
    public string DescriptionBoxText { get; set; }

    [Inject]
    public void Construct(InteractableObjectView interactableObjectView)
    {
        _interactableObjectView = interactableObjectView;
        _audioSource = GetComponent<AudioSource>(); 
        _audioSource.clip = _radioClip; 
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
            Debug.Log("You interact with: " + InteractableObjectName);
            _interactableObjectView.OnInteractionWithObject(DescriptionBoxText);

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Stop();
            }
        }
        else
        {
            Debug.Log(InteractableObjectName + " is not interactable");
        }
    }
}
