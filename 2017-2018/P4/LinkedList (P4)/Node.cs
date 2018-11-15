namespace P4
{
    class Node {
        public Device _device { get; set; }
        public Node _next { get; private set; }

        public Node(Device device) {
            _device = device;
            _next = null;
        }

        public Node(Device device, Node next) {
            _device = device;
            _next = next;
        }

        public override string ToString() {
            return _device.ToString();
        }

        public Device Get() { return _device; }

        public void SetNext(Device device) { _next = new Node(device, new Node(null)); }

        //static public void Switch(ref Node first, ref Node second) {
        //    var tmp = first._device;
        //    first._device = second._device;
        //    second._device = tmp;
        //}
    }
}
