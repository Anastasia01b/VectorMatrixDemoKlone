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
        private void ValidateSize(Vector o)
        {
            if (data.Length != o.Length)
            {
                throw new InvalidOperationException("The operation cannot be performed for vectors of different sizes");
            }
        }

        public Vector Add(Vector o)
        {
            ValidateSize(o);

            Vector result = new Vector(data.Length);
           for (int i =0; i< data.Length; i++)
            {
                result[i] = data[i] + o[i];
            }
           return result;
        }
        
        public Vector Sub(Vector o)
        {
            ValidateSize(o);

            Vector result = new Vector(data.Length);
            for (int i=0; i<data.Length; i++)
            {
                result[i]= data[i] - o[i];
            }
            return result;
        }
        
        public double Scalar(Vector o)
        {
            ValidateSize(o);

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
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= data.Length)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

        }

        public double this[int index]
        {
            get
            {
                ValidateIndex(index);
                return data[index];  
            }

            set
            {
                ValidateIndex(index);
                data[index] = value;
            }
        }
    }
}
