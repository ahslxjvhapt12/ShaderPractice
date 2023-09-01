
using Unity.VisualScripting;

namespace BehaviourTree
{
    public enum NodeState
    {
        SUCCESS = 1,
        FAILURE = 2,
        RUNNING = 3,
    }

    public abstract class Node
    {
        protected NodeState _nodeState;
        public NodeState nodeState => _nodeState;


        public abstract NodeState Evaluate();
    }
}