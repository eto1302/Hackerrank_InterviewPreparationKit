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

    // Complete the freqQuery function below.
    static List<int> freqQuery(List<List<int>> queries)
    {
        List<int> result = new List<int>();
        Dictionary<long, long> occurances = new Dictionary<long, long>();
        Dictionary<long, long> frequencies = new Dictionary<long, long>();
        frequencies.Add(0, 0);
        foreach (var query in queries)
        {
            int command = query[0];
            long value = query[1];
            if (command == 1)
            {
                if (!occurances.ContainsKey(value)) occurances.Add(value, 1);
                else occurances[value]++;
                if (!frequencies.ContainsKey(occurances[value]))
                {
                    frequencies.Add(occurances[value], 1);
                }
                else
                {
                    frequencies[occurances[value]]++;
                }
                if (frequencies[occurances[value] - 1] != 0) frequencies[occurances[value] - 1]--;
            }
            if (command == 2)
            {

                if (occurances.ContainsKey(value) && occurances[value] != 0)
                {
                    if (frequencies[occurances[value]] != 0) frequencies[occurances[value]]--;
                    occurances[value]--;
                    frequencies[occurances[value]]++;
                }

            }
            if (command == 3)
            {
                if (frequencies.ContainsKey(value) && frequencies[value] != 0) result.Add(1);
                else result.Add(0);
            }
        }
        return result;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
