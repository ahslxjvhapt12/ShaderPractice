using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBrain : MonoBehaviour
{
    [SerializeField] protected Transform _targetTrm;
    protected NavMeshAgent _agent;

    public NavMeshAgent agent => _agent;

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start()
    {
        
    }

    public void TryToTalk(string text)
    {
        Debug.Log(text);
    }
}
