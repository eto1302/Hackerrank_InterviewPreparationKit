using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    static long countTriplets(List<long> arr, long r)
    {
        long result = 0;
        Dictionary<long, long> dict = new Dictionary<long, long>();
        Dictionary<long, long> dictPairs = new Dictionary<long, long>();
        arr.Reverse();
        foreach (var i in arr)
        {
            if (dictPairs.ContainsKey(i * r))
            {
                result += dictPairs[i * r];
            }
            if (dict.ContainsKey(i * r))
            {
                if (!dictPairs.ContainsKey(i)) dictPairs.Add(i, 0);
                dictPairs[i] += dict[i * r];
            }
            if (!dict.ContainsKey(i)) dict.Add(i, 0);
            dict[i]++;
        }

        return result;
    }




    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}