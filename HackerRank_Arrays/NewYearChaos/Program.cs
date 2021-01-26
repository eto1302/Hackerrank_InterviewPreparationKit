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
    static void minimumBribes(int[] q)
    {
        int n = q.Count();
        int[] possibleSwitches = new int[3];
        possibleSwitches[0] = 1;
        possibleSwitches[1] = 2;
        possibleSwitches[2] = 3;
        int result = 0;
        for (int i = 0; i < n; ++i)
        {
            if (possibleSwitches[0] == q[i])
            {
                if (i < n - 2)
                {
                    possibleSwitches[0] = i + 4;
                }
                else
                {
                    possibleSwitches[0] = int.MaxValue;
                }
            }
            else if (possibleSwitches[1] == q[i])
            {
                if (i < n - 2)
                {
                    possibleSwitches[1] = i + 4;
                }
                else
                {
                    possibleSwitches[1] = int.MaxValue;
                }
                result++;
            }
            else if (possibleSwitches[2] == q[i])
            {
                if (i < n - 2)
                {
                    possibleSwitches[2] = i + 4;
                }
                else
                {
                    possibleSwitches[2] = int.MaxValue;
                }
                result += 2;
            }
            else
            {
                Console.WriteLine($"Too chaotic");
                return;
            }
            possibleSwitches = possibleSwitches.OrderBy(e => e).ToArray();
        }
        Console.WriteLine(result);
        return;

    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
            ;
            minimumBribes(q);
        }
    }
}
