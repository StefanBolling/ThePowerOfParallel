using System;
using System.Threading;

namespace ThePowerOfParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfIterations = 10;
            Console.WriteLine($"How much faster is parallel.for in {numberOfIterations} iterations");
            Console.WriteLine($"Normal for-loop run in {LoopHelper.NormalForLoop(numberOfIterations)} seconds");
            Console.WriteLine($"Parallel for-loop run in {LoopHelper.ParallelForLoop(numberOfIterations)} seconds");
            Console.WriteLine($"Normal foreach-loop run in {LoopHelper.NormalForEachLoop(numberOfIterations)} seconds");
            Console.WriteLine($"Parallel foreach-loop run in {LoopHelper.ParallelForEachLoop(numberOfIterations)} seconds");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void SlowOperation()
        {
            Thread.Sleep(500);
        }
    }
}