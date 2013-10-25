using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Examination
{
    public class gen
    {
        static void Main2(string[] args)
        {
            StreamReader reader = File.OpenText("gen.in");
            StreamWriter writer = File.CreateText("gen.out");
            string[] sl = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var genin = int.Parse(sl[0]);
            int count = 0;
            var genout = Gen(genin, count);
            writer.WriteLine(genout);
            reader.Close();
            writer.Close();

        }

        private static int Gen(int genin, int count)
        {
            var max = genin / 2;
            for (int i = 1; i <= max; i++)
            {
                count = Gen(i, count);
            }
            count++;
            return count;
        }

    }
}
