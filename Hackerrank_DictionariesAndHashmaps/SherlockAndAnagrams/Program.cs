﻿using System.CodeDom.Compiler;
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
    static int sherlockAndAnagrams(string s)
    {
        Dictionary<string, int> occurances = new Dictionary<string, int>();

        int result = 0;

        for (int i = 0; i < s.Length; ++i)
        {
            for (int j = i + 1; j < s.Length + 1; ++j)
            {
                string temp = String.Concat(s.Substring(i, j - i).OrderBy(c => c));

                if (occurances.ContainsKey(temp))
                {
                    occurances[temp]++;
                    result += occurances[temp] - 1;
                }
                else
                {
                    occurances.Add(temp, 1);
                }
            }
        }
        return result;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}