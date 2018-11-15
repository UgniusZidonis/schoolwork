using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labdara__U1_11_
{
    class Node
    {
        private Shoe _value;
        private Node _next;

        public Node(Shoe value = null, Node next = null) {
            _value = value;
            _next = next;
        }

        public Shoe GetValue() { return _value; }

        public Node GetNext() { return _next; }

        public void SetValue(Shoe value) { _value = value; }

        public void SetNext(Node next) { _next = next; }

        public static void Swap(Node lhs, Node rhs) {
            var tmp = lhs._value;
            lhs._value = rhs._value;
            rhs._value = tmp;
        }
    }
}
