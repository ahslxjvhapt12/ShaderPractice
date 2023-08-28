using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigid;
    private PlayerInput playerInput;
    Vector3 power = Vector3.up * 5f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.onActionTriggered += OnInputActionTriggered;
    }

    private void OnInputActionTriggered(InputAction.CallbackContext context)
    {
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(".га");
        if (context.started)
        {
            _rigid.AddForce(power, ForceMode.Impulse);
        }
    }
}
