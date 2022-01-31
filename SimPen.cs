//****************************************************************************
/*
    simplePen.cd  defines a class for simulating a simple pendulum

*/

using System;

namespace Sim
{
    public class SimPen
    {
        private double leng = 1.1; // length of pendulum
        private double g = 9.81;    // gravity

        //const
        public SimPen()
        {
            Console.WriteLine("svilen is small");
        }

        /*public double getLeng()
        {
            return leng;
        }
        public double getG()
        {
            return g;
        }        
        public void setLeng(double l)
        {
            if(l > 0)
                leng = l;
        }
        public void setG(double g)
        {
            g = this.g;
        }
        */
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
    }
}