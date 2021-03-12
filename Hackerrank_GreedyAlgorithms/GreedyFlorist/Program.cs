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

    // Complete the getMinimumCost function below.
    static int getMinimumCost(int k, int[] c)
    {
        int totalCost = 0;
        c = c.OrderByDescending(e => e).ToArray();
        int flowersBought = 0, currentBoughtFlowers = 0;
        while (flowersBought < c.Length)
        {
            totalCost += (currentBoughtFlowers + 1) * c[flowersBought];
            flowersBought++;
            if (flowersBought % k == 0) currentBoughtFlowers++;
        }
        return totalCost;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
            ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}