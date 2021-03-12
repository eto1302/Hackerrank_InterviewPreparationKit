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

    // Complete the luckBalance function below.
    static int luckBalance(int k, int[][] contests)
    {
        int total = 0;
        contests = contests.OrderByDescending(e => e[1]).ThenByDescending(e => e[0]).ToArray();
        foreach (var contest in contests)
        {
            if (contest[1] > k)
            {
                total -= contest[0];
                continue;
            }
            total += contest[0];
            k -= contest[1];
        }
        return total;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[][] contests = new int[n][];

        for (int i = 0; i < n; i++)
        {
            contests[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
        }

        int result = luckBalance(k, contests);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}