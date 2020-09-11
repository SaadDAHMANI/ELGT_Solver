//*********************************************************************************
// Written by : Saad DAHMANI (s.dahmani@univ-bouira.dz - sd.dahmani2000@gmail.com) *
// 
// References :
// 1. Gupta, Rajiv and Prasad, TD (2000). Extended use of linear graph theory for 
// analysis of pipe networks. American Society of Civil Engineers. Volume 126, 
// pages 56--62. https://doi.org/10.1061/(ASCE)0733-9429(2000)126:1(56)
//
// 2. Ayad, A and Awad, H and Yassin, A (2013). Developed hydraulic simulation 
// model for water pipeline networks. Alexandria Engineering Journal. Elsevier.
// Volume 52, pages 43--49. https://doi.org/10.1016/j.aej.2012.11.005
//
//*********************************************************************************
// MathNet.Numerics lib from : https://numerics.mathdotnet.com/
// Docs from : https://numerics.mathdotnet.com/Matrix.html
//

using System;
using ELGTSolverLib;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections;
using System.Collections.Generic;
namespace ELGTSolverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ELGT_Solver started ... Version : ");
            ELGTSolver solver = new ELGTSolver();
            Console.WriteLine(solver.Version);
            
        List<Pipe> pipes = new List<Pipe>();
        pipes.Add(new Pipe(1, 0.250, 100));
        pipes.Add(new Pipe(2, 0.150, 200));
        pipes.Add(new Pipe(3, 0.100, 100));
        pipes.Add(new Pipe(4, 0.250, 300));
        pipes.Add(new Pipe(5, 0.500, 200));
        //Pipe pip = new Pipe();
        Console.WriteLine(pipes[0].GetStiffnessFactor(1));
        int p=5; // pipes count 
        int n=4; // nodes count
       
        double[]qtn=new double[n]; // nodal demande vector.
        qtn[0]=0.01;
        qtn[2]=0.01;
        DenseVector qt= DenseVector.OfArray(qtn);

        double[,] S0= new double[p,n];
       
        S0[0,0]=-1;
        S0[0,1]=1;
        S0[1,1]=-1;
        S0[1,2]=1;
        S0[2,2]=-1;
        S0[2,3]=1;
        S0[3,0]=-1;
        S0[3,3]=1;
        S0[4,0]=-1;
        S0[4,2]=1;
        
        Matrix<double> S=DenseMatrix.OfArray(S0);
        Show(S.ToArray());    

        double[,] k0=new double[p,p]; 
        double [] ki= new double [p];
        for (int i=0; i<p;i++)
        {
            k0[i,i]=pipes[i].GetStiffnessFactor(1);
            ki[i]=k0[i,i];
        }

        Matrix<double> k= DenseMatrix.OfArray(k0);
        Console.WriteLine("The stiffness matrix [k] is :");
        Show(k.ToArray());
        
        Matrix<double> St= S.Transpose();
        Console.WriteLine("[St] matrix is :");
        Show(St.ToArray());

        var K =St.Multiply(k).Multiply(S);
        Console.WriteLine("[K] matrix is :");
        Show(K.ToArray());

        // The identity matrix :
        Matrix<double> I = DenseMatrix.CreateIdentity(n);
         Console.WriteLine("[I] matrix is :");
        Show(I.ToArray());

        var tmph=I.Multiply(-1).Multiply(qt);       
        Console.WriteLine("tmp.h = ");
        Show(tmph.ToArray());
                       
        var Kinv=K.Inverse();
        Console.WriteLine("[K]-1 = ");
        Show(Kinv.ToArray());

        var h =Kinv.Multiply(tmph);
        Console.WriteLine("h = ");
        Show(h.ToArray());

        var hc=S.Multiply(h).Multiply(-1);
        Console.WriteLine("hc = ");
        Show(hc.ToArray());

        var q=k.Multiply(hc);
        Console.WriteLine("pipe flow q = ");
        Show(q.ToArray());

        }
    
    
        public static void Show(double[,] matrix)
        {
            if(Equals(matrix, null)){return;}
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
             {
                Console.Write(Math.Round(matrix[i,j],4));
                 Console.Write(" ");    
             }
             Console.WriteLine();
            }
        }
         public static void Show(double[] matrix)   
            {
            if(Equals(matrix, null)){return;}
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                Console.Write(matrix[i]);
                 Console.WriteLine(" ");  
           
            }
        }
        
    }
}
