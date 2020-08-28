using System;
public class Pipe
{

public double Chw {get;set;}=110;
public double Diameter{get; set;}=0.1;

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
     double r =10.675*Math.Pow((1/Chw),Alpha)*(1/Math.Pow(Diameter, 4.87));
     return (1/(r*Math.Pow(Math.Abs(flow), (Alpha-1))));
}

}