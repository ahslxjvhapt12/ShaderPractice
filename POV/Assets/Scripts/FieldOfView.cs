using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Range(0f, 360f)]
    public float viewAngle;
    public float viewRadius;

    public Vector3 DirFromAngle(float degree)
    {
        float rad = degree * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(rad), 0 ,Mathf.Cos(rad));
    }
}
