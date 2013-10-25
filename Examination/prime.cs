using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication7
{
    class prime
    {
        static int[] primeArr = new int[38]
        {
            0, 0, 1, 1, 0, 1, 0,
            1, 0, 0, 0, 1, 0, 1,
            0, 0, 0, 1, 0, 1, 0,
            0, 0, 1, 0, 0, 0, 0,
            0, 1, 0, 1, 0, 0, 0,
            0, 0, 1
         };
        static List<string> ret = new List<string>();
        static string sFileName = "prime";
        static StreamWriter writer = File.CreateText(sFileName + ".out");
        static void Main2(string[] args)
        {

            StreamReader reader = File.OpenText(sFileName + ".in");

            int[] a = new int[20];
            int n = int.Parse(reader.ReadLine());

            primeCircle(a, n, 0);

            writer.WriteLine(ret.Count.ToString());
            foreach (string s in ret)
            {
                writer.WriteLine(s);
            }

            writer.Close();
            reader.Close();

        }
        private static bool checkNum(int[] a, int last, int cur)
        {
            if (last < 0)
                return true;

            if (!(((cur + a[last]) & 1) == 1))
                return false;

            if (primeArr[a[last] + cur] == 0)
                return false;

            for (int i = 0; i <= last; i++)
                if (a[i] == cur)
                    return false;

            return true;
        }
        private static void primeCircle(int[] a, int n, int t)
        {
            if (n % 2 != 0)
                return;

            if (t == n)
            {
                if (primeArr[a[0] + a[n - 1]] == 1)
                    getRet(a, n);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    a[t] = i;
                    if (checkNum(a, t - 1, i))
                        primeCircle(a, n, t + 1);
                }
            }
        }

        private static void getRet(int[] a, int n)
        {
            string tmp = string.Empty;
            for (int i = 0; i < n; i++)
            {
                tmp += a[i].ToString() + " ";
            }
            ret.Add(tmp);
        }

    }
}
