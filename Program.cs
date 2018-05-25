using System;

namespace ProcessQueue
{
    class Program
    {
        static Random random = new Random(DateTime.Now.Millisecond);
        static Queue queue = new Queue();
        static void Main(string[] args)
        {
            Simulation();
        }

        static void Simulation()
        {
            int emptyCounter, finishCounter, pendingCounter, restSteps; 
            emptyCounter = finishCounter = pendingCounter = restSteps = 0;

            for (int i = 0; i < 300; i++)
            {
                if (random.Next(100) < 35)
                    queue.Enqueue(new Process());

                if (!queue.IsEmpty())
                {
                    Process process = queue.Peek();
                    process.Steps--;
                    if (process.Steps == 0)
                    {
                        finishCounter++;
                        queue.Dequeue();
                    }
                }
                else
                    emptyCounter++;
            }

            Process temp = queue.Dequeue();
            while (temp != null)
            {
                pendingCounter++;
                restSteps += temp.Steps;
                temp = queue.Dequeue();
            }

            Console.WriteLine(
                "Statics{0}Iterations With Empty Queue: {1}{2}FinishedProcesses: {3}{4}Pending Processes: {5}{6}Steps to Go: {7}{8}",
                Environment.NewLine,
                emptyCounter,
                Environment.NewLine,
                finishCounter,
                Environment.NewLine,
                pendingCounter,
                Environment.NewLine,
                restSteps,
                Environment.NewLine
            );
        }
    }
}
