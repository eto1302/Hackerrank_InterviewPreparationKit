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
    static string reverseShuffleMerge(string s)
    {
        int[] occurances = new int[26];
        int[] required = new int[26];

        foreach (var symbol in s)
        {
            occurances[symbol - 'a']++;
            required[symbol - 'a'] = occurances[symbol - 'a'] / 2;
        }


        string result = "";
        int resultCount = s.Length / 2;

        char minChar = char.MaxValue;
        int minCharIndex = -1;

        for (int i = s.Length - 1; i >= 0; --i)
        {
            if (minChar > s[i] && required[s[i] - 'a'] > 0)
            {
                minChar = s[i];
                minCharIndex = i;
            }

            occurances[s[i] - 'a']--;

            if (occurances[s[i] - 'a'] < required[s[i] - 'a'])
            {
                result += minChar;
                required[minChar - 'a']--;
                for (; i < minCharIndex; ++i) ++occurances[s[i] - 'a'];
                minChar = char.MaxValue;
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = reverseShuffleMerge(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}