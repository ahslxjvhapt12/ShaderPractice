using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName ="SO/Input/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<bool> FireEvent;
    public event Action JumpEnvent;
    public event Action<Vector2> MovementEvent;
    public Vector2 AimDelta { get; private set; }

    private Controls _playerInputAction;

    private void OnEnable()
    {
        if(_playerInputAction == null)
        {
            _playerInputAction = new Controls();
            _playerInputAction.Player.SetCallbacks(this);
        }
        _playerInputAction.Player.Enable();
    }


    public void OnAim(InputAction.CallbackContext context)
    {
        AimDelta = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FireEvent?.Invoke(true);
        }
        else if (context.canceled)
        {
            FireEvent?.Invoke(false);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpEnvent?.Invoke();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        MovementEvent?.Invoke(value);
    }
}
