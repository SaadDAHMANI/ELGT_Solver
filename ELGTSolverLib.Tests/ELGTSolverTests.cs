using System;
using Xunit;
using ELGTSolverLib;

namespace ELGTSolverLib.Tests
{
    public class ELGTSolverTests
    {   
        //solver under tests.
        readonly ELGTSolver solver_tst;

        public ELGTSolverTests()
        {
            solver_tst=new ELGTSolver();
        }

        [Fact]
        public void VersionTest()
        {
            Assert.Equal("1.0.0", solver_tst.Version);
        }
    }
}
