using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThePowerOfParallel
{
    public static class LoopHelper
    {
        internal static double NormalForLoop(int numberOfIterations)
        {
            var startTime = DateTime.Now;
            for (var i = 0; i < numberOfIterations; i++)
            {
                Program.SlowOperation(i);
            }

            var totalRunTime = DateTime.Now - startTime;

            return totalRunTime.TotalSeconds;
        }

        internal static double ParallelForLoop(int numberOfIterations)
        {
            var startTime = DateTime.Now;

            Parallel.For(0, numberOfIterations, index => { Program.SlowOperation(index); } );

            var totalRunTime = DateTime.Now - startTime;

            return totalRunTime.TotalSeconds;
        }

        internal static double NormalForEachLoop(int numberOfIterations)
        {
            var listOfObjects = new List<bool>();

            for (var i = 0; i < numberOfIterations; i++)
            {
                listOfObjects.Add(true);
            }

            var startTime = DateTime.Now;

            foreach (var listObject in listOfObjects)
            {
                Program.SlowOperation(listObject);
            }

            var totalRunTime = DateTime.Now - startTime;

            return totalRunTime.TotalSeconds;
        }

        internal static double ParallelForEachLoop(int numberOfIterations)
        {
            // Notice that I don't use List in a paralell contect, since it is not thread safe.
            var listOfObjects = new ConcurrentBag<bool>();

            for (var i = 0; i < numberOfIterations; i++)
            {
                listOfObjects.Add(true);
            }

            var startTime = DateTime.Now;

            Parallel.ForEach(listOfObjects, currentObject => 
            {
                Program.SlowOperation(currentObject);
            });

            var totalRunTime = DateTime.Now - startTime;

            return totalRunTime.TotalSeconds;
        }
    }
}