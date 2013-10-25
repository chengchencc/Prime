using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Examination
{
    class Prime
    {
        List<int> all = new List<int>();
        List<int> itemResult = new List<int>();
        List<List<int>> resultList = new List<List<int>>();
        List<string> resultStringList = new List<string>();
        
        List<int[]> aaa = new List<int[]>();
        static int[] primeArr = new int[41]{ 0,1,1,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,0,0,1,0,0,0,1  };
        int count = 0;
        DateTime startTime;
        public void Test()
        {
            startTime = DateTime.Now;
            StreamReader reader = File.OpenText("prime.in");
            StreamWriter writer = File.CreateText("prime.out");
            string[] sl = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(sl[0]);
            //method(num, writer);
            //method2(count, writer);
            #region method3
            //int[] a = new int[count];
            //for (int i = 0; i < count; i++)
            //{
            //    a[i] = i + 1;
            //}
            //Method3(a, count, 0, writer);
            //writer.WriteLine(resultList.Count);
            //foreach (var item in resultList)
            //{
            //    foreach (var item1 in item)
            //    {
            //        writer.Write(item1 + " ");
            //    }
            //    writer.WriteLine();
            //}
            #endregion
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
                            SuperOutput(result);
                            //CacheResult(result);
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
            var re = new List<int>();
            foreach (var item in oneResult)
            {
                re.Add(item);
            }
            resultList.Add(re);
        }

        public void SuperOutput(List<int> oneResult)
        {
            Queue<int> tempList = new Queue<int>(oneResult.ToArray());
            //var index = tempList[0];
            for (int i = 0; i < count; i++)
            {
                var t = string.Empty;
                foreach (var item in tempList)
                {
                    t += item+ " ";
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
            return primeArr[number-1] == 1;
            //int boundary = (int)Math.Floor(Math.Sqrt(number));
            //if (number == 1) return false;
            //if (number == 2) return true;
            //for (int i = 2; i <= boundary; ++i)
            //{
            //    if (number % i == 0) return false;
            //}
            //return true;
        }





        #region method0

        public void method(int num, StreamWriter writer)
        {

            for (int i = 1; i <= num; i++)
            {

                all.Add(i);

                itemResult.Add(0);

            }



            Set(0, writer);

        }

        public void Set(int index, StreamWriter writer)
        {

            foreach (var item in all)
            {

                if (itemResult.Contains(item))

                    continue;

                itemResult[index] = item;

                if (itemResult.Contains(0))
                {

                    Set(index + 1, writer);

                }

                else
                {

                    if (isSuShuHuan(itemResult))
                    {

                        //resultList.Add(itemResult);

                        foreach (var item1 in itemResult)
                        {

                            writer.Write(item1 + " ");

                        }

                        writer.WriteLine();

                    }

                }

                itemResult[index] = 0;

            }

        }

        public bool isSuShuHuan(List<int> list)
        {

            for (int i = 0; i < list.Count; i++)
            {

                var a = 0;

                if (i != list.Count - 1)
                {

                    a = list[i] + list[i + 1];

                }

                else
                {

                    a = list[i] + list[0];

                }

                if (!IsPrime(a))
                {

                    return false;

                }

            }

            return true;

        }


        #endregion

        #region method1
        public void method2(int num, StreamWriter writer)
        {
            for (int i = 1; i <= num; i++)
            {
                all.Add(i);
            }
            List<CC> ds = new List<CC>();
            for (int i = 1; i <= num; i++)
            {
                for (int j = i + 1; j <= num; j++)
                {
                    if (IsPrime(i + j))
                    {
                        ds.Add(new CC { A = i, B = j });
                    }

                }
            }

            //if (isprime(num+1))
            //{
            //    ds.Add(new CC { A=num,B=1});
            //}

            Result re = new Result() { Index = 0, Value = 1 };
            get(1, ds, writer, re, true);
            get(4, ds, writer, re, false);

        }

        public bool get(int n, List<CC> ds, StreamWriter writer, Result re, bool zheng)
        {
            var isAll = false;
            var res = new Result();
            IEnumerable<CC> a;
            if (zheng)
            {
                a = ds.Where(s => s.A == n);
            }
            else
            {
                a = ds.Where(s => s.B == n);
            }
            foreach (var item in a)
            {
                if (re.Index < count - 2)
                {
                    res.Index = re.Index + 1;
                    isAll = get(item.B, ds, writer, res, zheng);
                }
                else
                {
                    if (IsPrime(item.B + 1))
                    {
                        isAll = true;
                    }
                    else
                    {
                        isAll = false;
                    }
                }
                if (isAll)
                {
                    if (re.Next == null)
                    {
                        re.Next = new List<Result>();
                    }
                    res.Pre = re;
                    res.Value = item.B;
                    re.Next.Add(res);
                }
            }
            return isAll;
        }
        #endregion

        #region method2

        // Check a permutation
        bool Check(int[] a, int n)
        {
            if (!IsPrime(a[0] + a[n - 1]))
                return false;

            for (int i = 0; i < n - 1; i++) // avoid duplicate
                if (!IsPrime(a[i] + a[i + 1]))
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

    class Result
    {
        public Result Pre { get; set; }
        public int Index { get; set; }
        public int Value { get; set; }
        public List<Result> Next { get; set; }
    }

    class CC
    {
        public int A { get; set; }
        public int B { get; set; }
    }
}
