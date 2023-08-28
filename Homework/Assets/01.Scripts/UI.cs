using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    UIDocument _document;

    public Action<ClickEvent> bind;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _document.rootVisualElement.Q<Label>("JumpLabel").RegisterCallback<ClickEvent>(Binding);
    }

    private void Binding(ClickEvent evt)
    {
        bind?.Invoke(evt);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _document.enabled = !_document.enabled;
        }
    }
}
