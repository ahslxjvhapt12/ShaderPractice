using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        private BehaviourTree _tree;

        private void Start()
        {
            _tree = ScriptableObject.CreateInstance<BehaviourTree>();

            var waitNode = ScriptableObject.CreateInstance<WaitNode>();
            waitNode.duration = 2;

            var debugNode1 = ScriptableObject.CreateInstance<DebugNode>();
            debugNode1.message = "HELLO1";
            var debugNode2 = ScriptableObject.CreateInstance<DebugNode>();
            debugNode2.message = "HELLO2";
            var debugNode3 = ScriptableObject.CreateInstance<DebugNode>();
            debugNode3.message = "HELLO3";

            var seqNode = ScriptableObject.CreateInstance<SequenceNode>();

            seqNode.children.Add(waitNode);
            seqNode.children.Add(debugNode1);
            seqNode.children.Add(debugNode2);
            seqNode.children.Add(debugNode3);

            var repeatNode = ScriptableObject.CreateInstance<RepeatNode>();
            repeatNode.child = seqNode;

            _tree.rootNode = repeatNode;
        }

        private void Update()
        {
            _tree.Update();
        }
    }
}