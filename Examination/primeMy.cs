using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Examination
{
    class primeMy
    {

        static void Main2(string[] args)
        {
            (new PrimeLink()).Test();
        }
    }

    class PrimeLink
    {
            List<int> all = new List<int>();
            List<int> itemResult = new List<int>();
            List<List<int>> resultList = new List<List<int>>();
            List<int[]> aaa = new List<int[]>();
            int count = 0;
            public void Test()
            {
                StreamReader reader = File.OpenText("prime.in");
                StreamWriter writer = File.CreateText("prime.out");
                string[] sl = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                count = int.Parse(sl[0]);
                #region method3
                int[] a = new int[count];
                for (int i = 0; i < count; i++)
                {
                    a[i] = i + 1;
                }
                Method3(a, count, 0, writer);
                writer.WriteLine(resultList.Count);
                foreach (var item in resultList)
                {
                    foreach (var item1 in item)
                    {
                        writer.Write(item1 + " ");
                    }
                    writer.WriteLine();
                }
                #endregion
                reader.Close();
                writer.Close();
            }


            public static bool isprime(int number)
            {

                int boundary = (int)Math.Floor(Math.Sqrt(number));



                if (number == 1) return false;

                if (number == 2) return true;



                for (int i = 2; i <= boundary; ++i)
                {

                    if (number % i == 0) return false;

                }

                return true;

            }



            #region method2

            // Check a permutation
            bool Check(int[] a, int n)
            {
                if (!isprime(a[0] + a[n - 1]))
                    return false;

                for (int i = 0; i < n - 1; i++) // avoid duplicate
                    if (!isprime(a[i] + a[i + 1]))
                        return false;

                return true;
            }

            void Method3(int[] a, int n, int t, StreamWriter writer)
            {
                if (t == n)
                {
                    //Output(a, n, writer);
                    if (Check(a, n))
                    {
                        var cc = new List<int>();
                        foreach (var item in a)
                        {
                            cc.Add(item);
                        }
                        resultList.Add(cc);
                    }
                }
                else
                {
                    for (int i = t; i < n; i++)
                    {
                        Swap(a, t, i);
                        Method3(a, n, t + 1, writer);
                        Swap(a, t, i);
                    }
                }
            }

            private static void Swap(int[] a, int t, int k)
            {
                var temp = a[k];
                a[k] = a[t];
                a[t] = temp;
            }

            private void Output(int[] a, int n, StreamWriter writer)
            {
                if (Check(a, n))
                {
                    for (int i = 0; i < n; i++)
                    {
                        writer.Write(a[i] + " ");
                    }
                    writer.WriteLine();
                }
            }


            #endregion
        }


    }


