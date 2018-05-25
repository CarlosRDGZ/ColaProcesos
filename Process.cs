namespace ProcessQueue
{
    class Process
    {
        public static System.Random random = 
            new System.Random(System.DateTime.Now.Millisecond);

        public Process Next;
        public Process Previous;
        public int Steps;
        public readonly int Pid;

        public Process()
        {
            System.DateTime now = System.DateTime.Now;
            this.Steps = random.Next(4,15);
            this.Pid = now.Millisecond + random.Next(60);
        }
    }
}