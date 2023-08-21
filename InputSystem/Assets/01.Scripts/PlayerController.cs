using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigid;
    Vector3 power = Vector3.up * 5f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        Debug.Log(".га");
        _rigid.AddForce(power, ForceMode.Impulse);
    }
}
