using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MomIsComing.Scripts.UsefulExtensions.Runtime
{
    public static class FloatExtensions
    {
        public static string AbbreviateNumber(this float number)
        {
            for (int i = Abbrevations.Count - 1; i >= 0; i--)
            {
                KeyValuePair<int, string> pair = Abbrevations.ElementAt(i);
                if (Mathf.Abs(number) >= pair.Key)
                {
                    string roundedNumber = (number / pair.Key).ToString("0.0");
                    return roundedNumber + pair.Value;
                }
            }
            return number.ToString();
        }
        
        public static string FormatTime(this float number)
        {
            int minutes = Mathf.FloorToInt(number / 60f);
            int seconds = Mathf.FloorToInt(number % 60f);
            return $"{minutes:00}:{seconds:00}";
        }

        private static readonly SortedDictionary<int, string> Abbrevations = new()
        {
            {1000,"k"},
            {1000000, "m" },
            {1000000000, "b" }
        };
    }
}