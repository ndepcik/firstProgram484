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
         private double[] yi;         //est
        private double[] t;         //time 
        private double  x0,  y0, x,  h;
        private int num;
        
        //const **************************************************************
        public RK()
        {
            num = 2;
            x0 = 1.0;
            y0 = 1.0;
            h = .02;

            yi = new double [num];
            t = new double [num];

            yi[0] = y0;
            t[0] = 0.0;

        }
        public RK(double x0, double y0, double x, double h)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x = x;
            this.h=h;
            
            num = (int) ( (x-x0) /h) + 1;   //number of itterations

            yi = new double [num];
            t = new double [num];
            yi[0] = y0;
            t[0] = 0.0;
                
        }

       /*methods ************************************************************
            rk4 : perform rk4
            dxdy: diff
        */
        public void RK4()
        {
        
                double k1, k2, k3, k4;
                yi[0] = y0;
               
                for(int i = 0; i < num-1; i++)
                    {
                        k1 = h * (dxdy(x0,yi[i]));
                        k2 = h * (dxdy(x0 + 0.5 *h ,yi[i] + 0.5 *k1));
                        k3 = h * (dxdy(x0 + 0.5 * h ,yi[i] + 0.5 * k2));
                        k4 = h * (dxdy(x0 + h,yi[i] + k3));

                        // y[i] = yi;
                        yi[i+1] = yi[i] + (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);  //update y
                        t[i+1] = t[i] + h;
                        x0 = x0 +h; //update x
                    }
                    // return yi;       //yi
        }
        
        public double dxdy(double x, double y)
        {
            return((x-y) /2.0);
        }

        //getter and setter ***************************************************
        public double[] y
        {
            get { return yi; }

            set { yi = value; }
        }
         public double[] time
        {
            get { return t; }

            set { t = value;}
        }
        public int number
        {
            get { return num; }

            set { num = value; }
        }
    }
}
