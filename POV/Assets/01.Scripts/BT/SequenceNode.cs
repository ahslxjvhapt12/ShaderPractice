using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace BTVisual
{
    public class SequenceNode : CompositNode
    {
        private int _current; // 현재 실행할 자식의 번호

        protected override void OnStart()
        {
            _current = 0;
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            var child = children[_current];

            switch (child.Update())
            {
                case State.RUNNING:
                    return State.RUNNING;
                case State.FAILURE:
                    return State.FAILURE;
                case State.SUCCESS:
                    _current++;
                    break;
            }

            return _current == children.Count ? State.SUCCESS : State.RUNNING;
        }
    }
}