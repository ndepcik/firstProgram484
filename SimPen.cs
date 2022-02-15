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
        }
        
       
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
    public class RK : SimPen
    {
        private double yi = 0;
        
    //    public string tempStr = "RK : SimPen";

       //TODO 4th oder RK4
        public void RK4(double x0, double y0, double x, double h)
        {
        
                double k1, k2, k3, k4;
                yi = y0;
                int num = (int) ( (x-x0) /h);   //number of itterations
                

                for(int i = 0; i < num; i++)
                    {
                        k1 = h * (dxdy(x0,yi));
                        k2 = h * (dxdy(x0 + 0.5 *h ,yi + 0.5 *k1));
                        k3 = h * (dxdy(x0 + 0.5 * h ,yi + 0.5 * k2));
                        k4 = h * (dxdy(x0 + h,yi + k3));

                        // y[i] = yi;
                        yi += (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);  //update y
                        x0 = x0 +h; //update x
                    }
                    // return yi;       //yi
        }
        
        public double dxdy(double x, double y)
        {
            return((x-y) /2);
        }
                
        public double y
        {
            get { return yi; }

            set { yi = value; }
        }
    }
}
