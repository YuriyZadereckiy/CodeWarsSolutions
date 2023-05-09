using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsNet.Source
{
    public class LoopSize
    {
        public static int getLoopSize(LoopDetector.Node startNode)
        {
            Dictionary<LoopDetector.Node, int> collection = new Dictionary<LoopDetector.Node, int>();
            int i = 0;
            while (startNode != null &&
                   !collection.TryGetValue(startNode, out var value))
            {
                collection.Add(startNode, i++);
                startNode = startNode.next;
            }

            if (startNode != null && collection.TryGetValue(startNode, out var index))
            {
                return collection.Count - index;
            }

            return 0;
        }
    }

    public class LoopDetector
    {
        public class Node
        {
            public Node next = null;
        }
    }
}
