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
    static int activityNotifications(int[] expenditure, int d)
    {
        ;

        int notificationCount = 0;

        int[] data = new int[201];
        for (int i = 0; i < d; i++)
        {
            data[expenditure[i]]++;
        }

        for (int i = d; i < expenditure.Count(); i++)
        {

            double median = getMedian(d, data);

            if (expenditure[i] >= 2 * median)
            {
                notificationCount++;

            }

            data[expenditure[i]]++;
            data[expenditure[i - d]]--;

        }

        return notificationCount;

    }

    private static double getMedian(int d, int[] data)
    {
        double median = 0;
        if (d % 2 == 0)
        {
            int m1 = -1;
            int m2 = -1;
            int count = 0;
            for (int j = 0; j < data.Count(); j++)
            {
                count += data[j];
                if (m1 == -1 && count >= d / 2)
                {
                    m1 = j;
                }
                if (m2 == -1 && count >= d / 2 + 1)
                {
                    m2 = j;
                    break;
                }
            }
            median = (m1 + m2) / 2.0;
        }
        else
        {
            int count = 0;
            for (int j = 0; j < data.Count(); j++)
            {
                count += data[j];
                if (count > d / 2)
                {
                    median = j;
                    break;
                }
            }
        }
        return median;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
        ;
        int result = activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
