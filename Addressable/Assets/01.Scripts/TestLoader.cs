using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoader : MonoBehaviour
{
    private GameObject _levelArt;
    private GameObject _player;
    private GameObject _zombie;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject _levelArt = Resources.Load<GameObject>("Level Art");
            GameObject _player = Resources.Load<GameObject>("Woman");
            GameObject _zombie = Resources.Load<GameObject>("Zombie");
            Instantiate(_levelArt, Vector3.zero, Quaternion.identity);
            Instantiate(_player, Vector3.zero, Quaternion.identity);
            Instantiate(_zombie, Vector3.zero, Quaternion.identity);
        }
    }
}
