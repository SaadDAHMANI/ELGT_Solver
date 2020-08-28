﻿//*********************************************************************************
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

namespace ELGTSolverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ELGT_Solver started ... Version : ");
            ELGTSolver solver = new ELGTSolver();
            Console.WriteLine(solver.Version);
            
        
        Pipe p = new Pipe();
        Console.WriteLine(p.GetStiffnessFactor(1));
        int n=5;
        int m=4;
        double[,] S0= new double[n,m];
 //for(int i=0; i<n; i++)
 //{
 //for(int j=0; j<m; j++)
 //{
 //   S[i,j]=0;
 //}
 //}

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

        double[] k0=new double[n]; 
        for (int i=0; i<n;i++)
        {
            k0[i]=p.GetStiffnessFactor(1);
        }

       Vector<double> k=DenseVector.OfArray(k0);
        Show(k.ToArray());
        
         Matrix<double> St= S.Transpose();
        Show(St.ToArray());

         var x=S.LeftMultiply(k);

         var K=St.Multiply(x); 

         Console.WriteLine("St*k matrix is : ");
         Show(K.ToArray());



        //Console.WriteLine("E is : ");
         //var E=A.Multiply(D);

 //Show(E.ToArray());
        }
    




    
        public static void Show(double[,] matrix)
        {
            if(Equals(matrix, null)){return;}
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
             {
                Console.Write(matrix[i,j]);
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
