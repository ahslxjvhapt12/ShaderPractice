using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using System;

public class SimpleEnemyBrain : EnemyBrain
{
    private Node _topNode;

    private NodeState _beforeTopState;

    protected override void Start()
    {
        base.Start();
        ConstructAITree();
    }

    private void ConstructAITree()
    {
        RangeNode shootingRange = new RangeNode(8f, _targetTrm, transform);
        ShootNode shootNode = new ShootNode(agent, this, 1f);
        Sequence shootSeq = new Sequence(new List<Node> { shootingRange, shootNode });

        RangeNode chaseRange = new RangeNode(15f, _targetTrm, transform);
        ChaseNode chaseNode = new ChaseNode(agent, _targetTrm, this);
        Sequence chaseSeq = new Sequence(new List<Node> { chaseRange, chaseNode });

        _topNode = new Selector(new List<Node> { shootSeq, chaseSeq });
    }

    private void Update()
    {
        _topNode.Evaluate();

        if (_topNode.nodeState == NodeState.FAILURE && _beforeTopState != NodeState.FAILURE)
        {
            TryToTalk("아무것도 할게 없어");
        }

        _beforeTopState = _topNode.nodeState;

    }
}
