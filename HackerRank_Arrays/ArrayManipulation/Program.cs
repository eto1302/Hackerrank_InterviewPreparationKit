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
    static long arrayManipulation(int n, int[][] queries)
    {
        int[] sums = new int[n];
        foreach (var query in queries)
        {
            int a = query[0];
            int b = query[1];
            int k = query[2];
            sums[a - 1] += k;
            if (b < n)
            {
                sums[b] -= k;
            }
        }
        int maxSum = 0;
        int current = 0;
        for (int i = 0; i < n; ++i)
        {
            current += sums[i];
            if (current > maxSum) maxSum = current;
        }
        return maxSum;
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}