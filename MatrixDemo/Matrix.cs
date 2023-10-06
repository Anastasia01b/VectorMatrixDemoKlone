using System;
using VectorDemo;

namespace MatrixDemo
{
    public class Matrix
    {
        private double[,] data;
        public Matrix()
        {
            data = new double[3, 3];
       
        }

        public Matrix(int r, int c)
        {
            data = new double[r, c];
        }

        public Matrix(double[,] data)
        {
           this.data = data;
        }
        
        public double[,] GetArrayRef
        {
            get
            {
               return data;
            }
        }

        public int Row
        {
            get
            {
               return data.GetLength(0);
            }
        }

        public int Col
        {
            get
            {
                return data.GetLength(1);
            }
        }

        private static void ValidateMatrixSizes(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Col != m2.Col)
            {
                throw new InvalidOperationException("Matrix sizes do not match");
            }
        }

        public static Matrix operator*(Matrix m1, double c)
        {
           int row =m1.Row;
           int col =m1.Col;
           Matrix result = new Matrix(row, col);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result.data[i, j] = m1.data[i, j] * c;
                }
            }

            return result;

        }
        
        public static Matrix operator*(double c, Matrix m1)
        {
            return m1 * c;
        }
        
        public static Matrix operator*(Matrix m1, Matrix m2)
        {
            int row1 = m1.Row;
            int col1 = m1.Col;
            int col2 = m2.Col;
            int row2 = m2.Row;

            if (col1 != row2)
            {
                throw new InvalidOperationException("The number of colums is not equal tothe number of rows");
            }

            Matrix result = new Matrix(row1, col2);

            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < col1; k++)
                    {
                        sum += m1.data[i, k] * m2.data[k, j];
                    }
                    result.data[i, j] = sum;
                }
            }

            return result;
        }
        
        public static Matrix operator+(Matrix m1, Matrix m2)
        {
            ValidateMatrixSizes(m1, m2);

            int row1 = m1.Row;
            int col1 = m1.Col;
            int col2 = m2.Col;
            int row2 = m2.Row;

            Matrix result = new Matrix(row1, col1);
            for (int i =0; i<row1; i++)
            {
                for (int j =0; j<col1; j++)
                {
                    result.data[i, j] = m1.data[i, j] + m2.data[i, j];
                }
            }
            return result;
        }
        
        public static Matrix operator-(Matrix m1, Matrix m2)
        {
            ValidateMatrixSizes(m1, m2);

            int row1 = m1.Row;
            int col1 = m1.Col;
            int col2 = m2.Col;
            int row2 = m2.Row;

            Matrix result = new Matrix(row1, col1);
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j<col1; j++)
                {
                    result.data[i, j]= m1.data[i, j]- m2.data[i, j];
                }
            }
            return result;
        }
        
        public static Vector operator*(Matrix m1, Vector v1)
        {
            if (m1.Col != v1.Length )
            {
                throw new InvalidOperationException("Matrix col size is not equal to the length of the vector");
            }

            int row = m1.Row;
            int col = m1.Col;

            Vector result = new Vector(row);
            for (int i = 0; i < row;i++)
            {
                double sum = 0;
                for (int j=0; j<col; j++)
                {
                    sum += m1.data[i, j] * v1[j];
                }
                result[i] = sum;
            }
            return result;
        }
        
        public static Vector operator*(Vector v1,Matrix m1)
        {
            if (m1.Row != v1.Length)
            {
                throw new InvalidOperationException("Matrix row size is not equal to the length of the vector");
            }

            int row = m1.Row;
            int col = m1.Col;

            Vector result = new Vector(col);
            for (int j = 0; j < col; j++)
            {
                double sum = 0;
                for (int i = 0; i < row; i++)
                {
                    sum += v1[i]* m1.data[i, j];
                }
                result[j] = sum;
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Matrix m = (Matrix) obj;
            if (Row != m.Row || Col != m.Col)
                return false;
            for(int i=0;i<Row;++i)
                for(int j=0;j<Col;++j)
                    if (data[i, j] != m.data[i, j])
                        return false;
            return true;
        }

        public override string ToString()
        {
            var row = Row;
            var col = Col;
            var lines = new string[row];

            for (int i = 0; i < row; i++)
            {
                var line = new double[col];
                for (int j = 0; j < col; j++)
                {
                    line[j] = data[i, j];
                }
                lines[i] = string.Join(" ", line);
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}
