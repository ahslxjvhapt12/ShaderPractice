using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    [CreateAssetMenu(menuName = "BehaviourTree/Tree")]
    public class BehaviourTree : ScriptableObject
    {
        public Node rootNode;
        public Node.State treeState = Node.State.RUNNING;

        public Node.State Update()
        {
            if (treeState == Node.State.RUNNING)
                return rootNode.Update();
            return treeState;
        }

    }
}