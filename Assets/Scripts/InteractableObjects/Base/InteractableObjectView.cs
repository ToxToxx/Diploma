using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableObjectView : MonoBehaviour
{
    private InteractableObjectController _interactableObjectController;
    [SerializeField] private GameObject _descriptionBoxUI;
    [SerializeField] private TextMeshProUGUI _descriptionBoxUIText;
    [SerializeField] private float _displayDuration = 3f; 
    [SerializeField] private float _baseFontSize = 200f; 

    private void Awake()
    {
        _interactableObjectController = GetComponent<InteractableObjectController>();
        _interactableObjectController.OnInteractionWithObject += OnInteractionWithObject;
        Hide();
    }

    private void OnInteractionWithObject(string descriptionBoxUIText)
    {
        Show();

        _descriptionBoxUIText.text = descriptionBoxUIText;
        int wordCount = CountWords(descriptionBoxUIText);
        AdjustFontSize(wordCount);

        StartCoroutine(HideDescriptionBoxAfterDelay());
    }

    private void AdjustFontSize(float wordCount)
    {
        float fontSize = _baseFontSize - (wordCount * 2);
        _descriptionBoxUIText.fontSize = Mathf.Max(fontSize, 12);
    }
    private int CountWords(string text)
    {
        string[] words = text.Split(' ');
        return words.Length;
    }

    private IEnumerator HideDescriptionBoxAfterDelay()
    {
        yield return new WaitForSeconds(_displayDuration);
        Hide();
    }

    private void Show()
    {
        _descriptionBoxUI.SetActive(true);
    }

    private void Hide()
    {
        _descriptionBoxUI.SetActive(false);
    }
}
