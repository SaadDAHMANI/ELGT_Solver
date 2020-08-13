using System;
using ELGTSolverLib;

namespace ELGTSolverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ELGT_Solver started ...");
            ELGTSolver solver = new ELGTSolver();
            Console.WriteLine(solver.Version);


        }
    }
}
