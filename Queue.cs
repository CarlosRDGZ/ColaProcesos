namespace ProcessQueue
{
    class Queue
    {
        private Process head = null;
        private Process tail = null;

        public void Enqueue(Process process)
        {
            if (this.tail != null)
            {
                this.tail.Next = process;
                process.Previous = this.tail;
                this.tail = process;
            }
            else
                this.head = this.tail = process;
        }

        public Process Dequeue()
        {
            if (this.head != this.tail)
            {
                Process process = this.head;
                process.Next.Previous = null;
                this.head = process.Next;
                process.Next = null;
                if (this.head.Next == null)
                    this.tail = this.head;
                return process;
            }
            else if (this.head != null)
            {
                Process process = this.head;
                this.head = this.tail = null;
                return process;
            }
            return null;
        }

        public Process Peek() => this.head;

        public bool IsEmpty() => this.head == null;

        public override string ToString()
        {
            string str = "";
            Process temp = this.head;
            while (temp != null)
            {
                str += temp.Pid + System.Environment.NewLine;
                temp = temp.Next;
            }
            return str;
        }
        public string ToStringReverse()
        {
            string str = "";
            Process temp = this.tail;
            while (temp != null)
            {
                str += temp.Pid + System.Environment.NewLine;
                temp = temp.Previous;
            }
            return str;
        }
    }
}