using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction _inputAction;

    public Action<Vector2> OnMovement;
    public Action<Vector2> OnAim;
    public Action OnJump;
    public Action OnFire;

    [SerializeField] UI _ui;

    private void Awake()
    {
        _inputAction = new PlayerInputAction();

        _inputAction.Player.Enable();
        _inputAction.Player.Jump.performed += JumpHandle;
        _inputAction.Player.Fire.performed += FireHandle;
        _ui.bind += Binding;
    }

    public void Binding(ClickEvent evt)
    {
        _inputAction.Player.Disable();
        _inputAction.Player.Jump.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .WithCancelingThrough("<keyboard>/escape")
            .OnComplete(op =>
            {
                Debug.Log(op);
                Debug.Log(1);
                op.Dispose();
                _inputAction.Player.Enable();
            })
            .OnCancel(op =>
            {
                Debug.Log("바인딩 취소");
                op.Dispose();
                _inputAction.Player.Enable();
            })
            .Start();
    }


    private void FireHandle(InputAction.CallbackContext context)
    {
        OnFire?.Invoke();
    }

    private void JumpHandle(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void Update()
    {
        Vector2 inputVector = _inputAction.Player.Movement.ReadValue<Vector2>();
        OnMovement?.Invoke(inputVector);

        Vector2 mouse = _inputAction.Player.Aim.ReadValue<Vector2>();
        OnAim?.Invoke(mouse);
    }
}