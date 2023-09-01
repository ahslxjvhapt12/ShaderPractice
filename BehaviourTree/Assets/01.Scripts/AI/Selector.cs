using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Selector : Node
    {
        protected List<Node> _nodes = new();

        public Selector(List<Node> node)
        {
            _nodes = node;
        }

        public override NodeState Evaluate()
        {
            foreach (var node in _nodes)
            {
                switch (node.Evaluate())
                {
                    case NodeState.SUCCESS:
                        _nodeState = NodeState.SUCCESS;
                        return _nodeState;
                    case NodeState.FAILURE:
                        break;
                    case NodeState.RUNNING:
                        _nodeState = NodeState.RUNNING;
                        return _nodeState;
                    default:
                        break;
                }
            }
            _nodeState = NodeState.FAILURE;
            return _nodeState;
        }
    }
}
