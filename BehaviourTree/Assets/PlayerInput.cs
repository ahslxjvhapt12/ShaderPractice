using System;
using System.Collections;
using System.Collections.Generic;
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
        _keyAction.PlayerInput.Enable();
        _keyAction.PlayerInput.Jump.performed += JumpPerformed;
    }

    private void Update()
    {
        Vector2 inputVector = _keyAction.PlayerInput.Movement.ReadValue<Vector2>();
        OnMovement?.Invoke(inputVector);
    }


    private void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

}
