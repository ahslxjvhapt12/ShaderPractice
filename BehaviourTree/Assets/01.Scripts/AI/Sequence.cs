using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviourTree
{
    public class Sequence : Node
    {
        protected List<Node> _nodes = new();

        public Sequence(List<Node> node)
        {
            _nodes = node;
        }

        public override NodeState Evaluate()
        {
            bool isAnyNodeRun = false;
            foreach (var node in _nodes)
            {
                switch (node.Evaluate())
                {
                    case NodeState.SUCCESS:
                        isAnyNodeRun = true;
                        break;
                    case NodeState.FAILURE:
                        _nodeState = NodeState.FAILURE;
                        return _nodeState;
                    case NodeState.RUNNING:
                        break;
                    default:
                        break;
                }
            }
            _nodeState = isAnyNodeRun ? NodeState.RUNNING : NodeState.SUCCESS;
            return _nodeState;
        }
    }
}