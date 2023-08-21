using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class HammaTest : MonoBehaviour
{
    SpriteRenderer _renderer;
    private readonly int offsetHash = Shader.PropertyToID("_Offset");


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(1);
            StartCoroutine(ShowCoroutine());
        }
    }

    IEnumerator ShowCoroutine()
    {
        float t = 2f;
        float ct = 0f;
        float percent = 0;
        float value;
        while (percent < 1)
        {
            ct += Time.deltaTime;
            percent = ct / t;
            value = Mathf.Lerp(-1, 1, percent);
            Debug.Log(value);
            //Debug.Log(percent);
            _renderer.material.SetFloat(offsetHash, value);
            yield return null;
        }
    }
}
