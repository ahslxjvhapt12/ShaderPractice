using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Inverter : Node
    {
        protected Node _node;

        public Inverter(Node node)
        {
            _node = node;
        }

        public override NodeState Evaluate()
        {
            switch (_node.Evaluate())
            {
                case NodeState.SUCCESS:
                    _nodeState = NodeState.FAILURE;
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.SUCCESS;
                    break;
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    break;
                default:
                    break;
            }
            return _nodeState;
        }
    }
}