using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private KeyAction _keyAction;

    public Action<Vector2> OnMovement;
    public Action OnJump;

    private void Awake()
    {
        _keyAction = new KeyAction();

        _keyAction.Player.Enable();
        _keyAction.Player.Jump.performed += JumpPerformed;

        _keyAction.UI.Submit.performed += UISubmitPressed;

        _keyAction.Player.Disable();
        _keyAction.Player.Jump.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .WithCancelingThrough("<keyboard>/escape")
            .OnComplete(op =>
            {
                Debug.Log(op);
                op.Dispose();
                _keyAction.Player.Enable();
            })
            .OnCancel(op =>
            {
                Debug.Log("바인딩 취소");
                op.Dispose();
                _keyAction.Player.Enable();
            })
            .Start();
    }

    private bool _uiMode = false;

    private void Update()
    {
        Vector2 inputVector = _keyAction.Player.Movement.ReadValue<Vector2>();
        OnMovement?.Invoke(inputVector);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            print("lb");
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            print("t");
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _keyAction.Disable();
            if (!_uiMode)
            {
                _keyAction.UI.Enable();
                _uiMode = true;
            }
            else
            {
                _keyAction.Player.Enable();
                _uiMode = false;
            }
        }
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void UISubmitPressed(InputAction.CallbackContext context)
    {
        Debug.Log("UI Space Pressed");
    }
}