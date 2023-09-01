using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEngine.AI;
using UnityEditor.Rendering;

public class ShootNode : Node
{
    private NavMeshAgent _agent;
    private EnemyBrain _brain;

    private float _cooltime = 0;
    private float _lastFireTime = 0;

    public ShootNode(NavMeshAgent agent, EnemyBrain brain, float cooltime)
    {
        _agent = agent;
        _brain = brain;
        _cooltime = cooltime;
    }

    public override NodeState Evaluate()
    {
        _agent.isStopped = true; // Á¤Áö
        if (_cooltime + _lastFireTime > Time.time)
        {
            _brain.TryToTalk("0°Ý");
            _lastFireTime = Time.time;
        }

        return NodeState.RUNNING;
    }
}
