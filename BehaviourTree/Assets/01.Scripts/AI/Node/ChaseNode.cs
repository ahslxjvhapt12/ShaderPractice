using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEngine.AI;

public class ChaseNode : Node
{
    private NavMeshAgent _agent;
    private EnemyBrain _enemyBrain;

    private Transform _target;

    public ChaseNode(NavMeshAgent agent, Transform target, EnemyBrain brain)
    {
        _agent = agent;
        _enemyBrain = brain;
        _target = target;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(_agent.transform.position, _target.position);
        if (distance > 0.2f)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_target.transform.position);
            if (_nodeState != NodeState.RUNNING)
            {
                _enemyBrain.TryToTalk("추적시작");
                _nodeState = NodeState.RUNNING;
            }
        }
        else
        {
            _agent.isStopped = true;
            _nodeState = NodeState.SUCCESS;
        }
        return _nodeState;
    }
}
