using System;

namespace VectorDemo
{
    public class Vector
    {
        private double[] data;

        public Vector()
        {
            data = new double[3];
        }
        
        public Vector(int N)
        {
            data = new double[N];
        }
        
        public Vector(double[] d)
        {
           data = d ;
        }

        public Vector Add(Vector o)
        {
           if (data.Length !=o.Length)
            {
                throw new InvalidOperationException();
            }

           Vector result = new Vector(data.Length);
           for (int i =0; i< data.Length; i++)
            {
                result[i] = data[i] + o[i];
            }
           return result;
        }
        
        public Vector Sub(Vector o)
        {
            if (data.Length != o.Length)
            {
                throw new InvalidOperationException();
            }

            Vector result = new Vector(data.Length);
            for (int i=0; i<data.Length; i++)
            {
                result[i]= data[i] - o[i];
            }
            return result;
        }
        
        public double Scalar(Vector o)
        {
          if (data.Length != o.Length )
            {
                throw new InvalidOperationException();
            }  

          double result = 0;
            for (int i =0; i< data.Length;i++)
            {
                result += data[i] * o[i];
            }
            return result;

        }
        
        public static Vector operator*(Vector v, double c)
        {
            Vector result = new Vector(v.Length);
            for (int i=0; i< v.Length; i++)
            {
                result[i] = v[i] * c;
            }
            return result;
        }
        
        public static Vector operator*(double c,Vector v)
        {
            return v*c;
        }

        public override string ToString()
        {
            string result = "(" + string.Join(";", data) + ")";

            return result;
        }

        public int Length
        {
            get
            {
               return data.Length;
            }
        }
        
        public double[] GetArrayRef
        {
            get
            {
                return data;
            }
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= data.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return data[index];  
            }

            set
            {
                if (index < 0 || index >= data.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                data[index] = value;
            }
        }
    }
}