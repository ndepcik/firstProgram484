//****************************************************************************
/*
    simplePen.cd  defines a class for simulating a simple pendulum

*/

using System;

namespace Sim
{
    public class SimPen
    {
        private double leng = 1.1;  // length of pendulum
        private double g = 9.81;    // gravity

        private int n = 2;          //num of states
        private double[] x;         //array of states
        private double[] f;         //right side of eq evaluated
        

        //const
        public SimPen()
        {
            x = new double [n];
            f = new double [n];

            x[0] = 1.0;
            x[1] = 0.0;

        }
        /*methods ************************************************************
            step : perform intgration
            rhsFunc: function to calculate
        */
        public void step(double dt)
        {
            rhsFunc(x,f);
            
            for(int i=0; i<n; i++)
            {
                x[i] = x[i] +f[i] * dt;
            }
            // Console.WriteLine($"x: {x[0].ToString()}   {x[1].ToString()}"  );
            // Console.WriteLine($"f: {f[0].ToString()}   {f[1].ToString()}"  );
        }
        
        //TODO 4th oder RK4

        public void rhsFunc(double[] st, double[] ff)
        {
            ff[0] = st[1];
            ff[1] = -g/leng * Math.Sin(st[0]);
        }

       //getter and setter ***************************************************
        public double L
        {
            get {return(leng);}

            set 
            {
                if(value >0.0)
                    leng = value;
            }
        }

        public double G
        {
            get {return(g);}

            set 
            {
                if(value >=0.0)
                    g = value;
            }
        }
        
        public double theta
        {
            get { return x[0]; }

            set { x[0] = value; }
        }

        public double thetaDot
        {
            get { return x[1]; }

            set { x[1] = value; }
        }


    }
}