using System;
public class Pipe
{

public Pipe(int id, double D, double L)
{
    this.ID=id;
    this.Diameter=D;
    this.Length=L;
}

public int ID {get; set; }=-1;
public double Chw {get;set;}=110;
public double Diameter{get; set;}=0.1;

public double Length{get; set;}=100;

public double Alpha {get; set; }=1.852;

public double Flow {get; set;}=0;

public double StiffnessFactor
{
    get
    { 
        if(Flow!=0) { return GetStiffnessFactor(Flow);}
        else {return double.NaN;}       
    }
}
public double GetStiffnessFactor(double flow)
{
     double r =10.675*Length*Math.Pow((1/Chw),Alpha)*(1/Math.Pow(Diameter, 4.87));
     return (1/(r*Math.Pow(Math.Abs(flow), (Alpha-1))));
}

}