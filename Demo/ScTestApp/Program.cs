using System;
using Starcounter;
using Starcounter.NUnit.Runner;

namespace ScTestApp
{
    public class Program
    {
        static void Main()
        {
            StarcounterNUnitRunner runner = new StarcounterNUnitRunner();
            runner.Start();
        }
    }
}