//*********************************************************************************
// Written by : S.DAHMANI (s.dahmani@univ-bouira.dz - sd.dahmani2000@gmail.com) *
// 
// Reference :
// 1. Gupta, Rajiv and Prasad, TD (2000). Extended use of linear graph theory for 
// analysis of pipe networks. American Society of Civil Engineers. Volume 126, 
// pages 56--62. https://doi.org/10.1061/(ASCE)0733-9429(2000)126:1(56)
//
// 2. Ayad, A and Awad, H and Yassin, A (2013). Developed hydraulic simulation 
// model for water pipeline networks. Alexandria Engineering Journal. Elsevier.
// Volume 52, pages 43--49. https://doi.org/10.1016/j.aej.2012.11.005
//
//*********************************************************************************
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
