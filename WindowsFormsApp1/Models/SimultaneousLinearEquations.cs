using System;
using System.Windows.Forms;

namespace DVLibrary.Mathematics
{
    public static class SystemOfLinearAlgebraicEquations
    {
        public static double[] GaussianMethod(double[,] a,double[] b,double eps = 0.001)
        {
            int n = b.Length;
            double[] x = b;
            for (int i = 0; i < n - 1; i++)
            {
                if (Math.Abs(a[i, i]) < eps)
                {
                    throw new ArgumentException();
                }
                for (int j = i + 1; j < n; j++)
                {
                    a[j, i] = -a[j, i] / a[i, i];
                    for (int k = i + 1; k < n; k++)
                    {
                        a[j, k] += a[j, i] * a[i, k];
                    }
                    b[j] += a[j, i] * b[i];
                }
            }
            x[n - 1] = b[n - 1] / a[n - 1, n - 1];
            double h = 0;
            for (int i = n - 2; i >= 0; i--)
            {
                h = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    h -= x[j] * a[i, j];
                }
                x[i] = h / a[i, i];
            }
            return x;
        }
        public static double[] MethodOfSimpleIteration(double[,] a, double[] b, double eps = 0.001)
        {
            int n = b.Length;
            double[] res = new double[n], Xn = new double[n];

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                res[i] = b[i] / a[i, i];
                for (int j = i + 1; j < n; j++) sum += Math.Abs(a[i, j]);
                if (Math.Abs(a[i, i]) <= sum) throw new ArgumentException();
            }

            do
            {
                for (int i = 0; i < n; i++)
                {
                    Xn[i] = b[i] / a[i, i];
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j) Xn[i] -= a[i, j] / a[i, i] * res[j];
                    }
                }

                bool flag = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (Math.Abs(Xn[i] - res[i]) > eps)
                    {
                        flag = false;
                        break;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    res[i] = Xn[i];
                }
                if (flag)
                    break;
            } while (true);

            return res;
        }
    }
}

