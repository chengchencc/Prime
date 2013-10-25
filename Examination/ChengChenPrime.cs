using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Examination
{
    class ChengChenPrime
    {
        List<string> resultStringList = new List<string>();
        static int[] primeArr = new int[41] { 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 };
        int count = 0;
        DateTime startTime;
        public void Test()
        {
            startTime = DateTime.Now;
            StreamReader reader = File.OpenText("prime.in");
            StreamWriter writer = File.CreateText("prime.out");
            string[] sl = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(sl[0]);
            MethodSuper();
            writer.WriteLine(resultStringList.Count);
            foreach (var item in resultStringList)
            {
                writer.WriteLine(item);
            }

            reader.Close();
            writer.Close();
            var timeSpan = DateTime.Now - startTime;
            Console.WriteLine(timeSpan);
            Console.ReadKey();
        }

        public void MethodSuper()
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 1; i <= count; i++)
            {
                for (int j = 1; j <= count; j++)
                {
                    if (j != i)
                    {
                        if (IsPrime(i + j))
                        {
                            if (!dic.ContainsKey(i))
                            {
                                dic.Add(i, new List<int>());
                            }
                            dic[i].Add(j);
                        }
                    }
                }
            }
            var resultItem = new List<int>();
            resultItem.Add(1);

            Recursion(1, dic, resultItem);
        }

        public void Recursion(int start, Dictionary<int, List<int>> ds, List<int> result)
        {
            for (int i = 0; i < ds[start].Count; i++)
            {
                if (!result.Contains(ds[start][i]))
                {
                    result.Add(ds[start][i]);
                    if (result.Count == count)
                    {
                        if (IsPrime(ds[start][i] + 1))
                        {
                            CacheResult(result);
                        }
                    }
                    else
                    {
                        Recursion(ds[start][i], ds, result);
                    }
                    result.Remove(ds[start][i]);
                }
            }


        }

        public void CacheResult(List<int> oneResult)
        {
            Queue<int> tempList = new Queue<int>(oneResult.ToArray());
            //var index = tempList[0];
            for (int i = 0; i < count; i++)
            {
                var t = string.Empty;
                foreach (var item in tempList)
                {
                    t += item + " ";
                    //writer.Write(item + " ");
                }
                var a = tempList.Dequeue();
                tempList.Enqueue(a);
                //writer.WriteLine();
                resultStringList.Add(t);
            }
        }

        public static bool IsPrime(int number)
        {
            return primeArr[number - 1] == 1;
            //int boundary = (int)Math.Floor(Math.Sqrt(number));
            //if (number == 1) return false;
            //if (number == 2) return true;
            //for (int i = 2; i <= boundary; ++i)
            //{
            //    if (number % i == 0) return false;
            //}
            //return true;
        }

    }
}
