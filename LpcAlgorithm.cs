using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar1NewVersion
{
    internal class LpcAlgorithm
    {
        public double[] Example1(byte[] s, int n)
        {
            double[] d = new double[n];
            d[0] = s[0];
            for(int i = 1; i < n; i++)
            {
                d[i] = s[i] - s[i - 1];
            }
            return d;
        }

        private double CalculateArrayAverage(byte[] array, double n)
        {
            double result = 0;
            foreach (var elem in array)
                result += elem;

            return result * n;
        }

        private double CalculateArrayAverage(double[] array, double n)
        {
            double result = 0;
            foreach (var elem in array)
                result += elem;

            return result * n;
        }

        public byte[] Example2(double[] d, int n)
        {
            byte[] s = new byte[n];
            s[0] = Convert.ToByte(d[0]);
            for(int i = 1; i< n; i++)
                s[i] = Convert.ToByte(d[i] + s[i - 1]);

            return s;
        }

        public double[] Example3(byte[] s, int n, int h)
        {
            byte[] last = new byte[h];
            double[] d = new double[n];
            int lastPos = 0;
            byte current;

            for(int i = 0; i < n; i++)
            {
                current = s[i];
                d[i] = current - CalculateArrayAverage(last, (double)1 / h);
                last[lastPos] = s[i];
                lastPos = (lastPos + 1) & 3;
            }

            return d;
        }

        public byte[] Example4(double[] d, int n, int h)
        {
            byte[] last = new byte[h];
            byte[] s = new byte[n];
            int lastPos = 0;
            double current;

            for(int i = 0; i < n; i++)
            {
                current = d[i];
                s[i] = Convert.ToByte(current + CalculateArrayAverage(last, (double) 1 / h));
                last[lastPos] = s[i];
                lastPos = (lastPos + 1) & 3;
            }

            return s;
        }

        public (double[] a, double[] d) Example5(byte[] s, int n)
        {

            double[] a = new double[(int)(Math.Round((decimal)n / 2))]; //полусумма (Average)
            double[] d = new double[(int)(Math.Round((decimal)n / 2))]; // разность (Delta)

            for (int i = 0; i < n / 2; i++)
            {
                a[i] = Convert.ToDouble(((double)s[2 * i] + (double)s[2 * i + 1]) / 2);
                d[i] = Convert.ToDouble((double)s[2 * i] - (double)s[2 * i + 1]);
            }

            if (n % 2 != 0)
            {
                a[n / 2] = Convert.ToDouble(s[n - 1]);
                d[n / 2] = 0;
            }
            return (a, d);

        }

        public byte[] Example6(double[] a, double[] d, int n, byte[] temp)
        {
            byte[] s = new byte[n];
            for (int i = 0; i < n / 2; i++)
            {
                s[2 * i] = Convert.ToByte((2 * a[i] + d[i]) / 2);
                s[2 * i + 1] = Convert.ToByte((2 * a[i] - d[i]) / 2);
            }
            if (n % 2 != 0)
                s[n - 1] = Convert.ToByte(a[n / 2]);

            return s;
        }
    }
}
