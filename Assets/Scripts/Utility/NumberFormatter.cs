using System.Numerics;
using UnityEngine;

namespace Utility
{
    public class NumberFormatter : MonoBehaviour
    {
        public static string FormatNumber(BigInteger number)
        {
            string[] suffixes = {
            "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No",
            "Dc", "UDc", "DDc", "TDc", "QaDc", "QiDc", "SxDc", "SpDc", "ODc", "NDc",
            "Vg", "UVg", "DVg", "TVg", "QaVg", "QiVg", "SxVg", "SpVg", "OVg", "NVg"
        };
            int index = 0;
            int divisor = 1000;

            while (BigInteger.Abs(number) >= divisor && index < suffixes.Length - 1)
            {
                number /= divisor;
                index++;
            }
            return $"{number:F0}{suffixes[index]}";
        }
    }
}