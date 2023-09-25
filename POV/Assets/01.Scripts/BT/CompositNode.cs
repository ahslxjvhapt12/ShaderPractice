using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTVisual
{
    public abstract class CompositNode : Node
    {
        public List<Node> children = new List<Node>();
    }
}