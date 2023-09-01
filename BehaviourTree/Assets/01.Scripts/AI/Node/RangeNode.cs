using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class RangeNode : Node
{
    private float _range;
    private Transform _target;
    private Transform _transform;

    public RangeNode(float range, Transform target, Transform transform)
    {
        _range = range;
        _target = target;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(_target.position, _target.position);
        _nodeState = distance < _range ? NodeState.SUCCESS : NodeState.FAILURE;
        return _nodeState;
    }
}
