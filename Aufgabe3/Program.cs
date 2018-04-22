using System;
using System.Collections.Generic;

namespace Aufgabe3
{
    class Program
    {

        static int subtotalCollector;
        static int summedUpSubtotals;
        static int input;
        static int _toBase;
        static int _fromBase;
        static void Main(string[] args)
        {
            //ToDezimal(1023);
            //ToHexal(231);
            int result = ConvertNumberToBaseFromBase(231, 6, 10);
            Console.WriteLine("If you convert " + input + " from the numeral system of " + _fromBase + " to the numeral system of " + _toBase + ", you'll get " + result+".");
        }

        public static int ToHexal(int dec) //welche einen beliebigen Integer-Wert zwischen 0 und 1023 entgegen nimmt
        {
            List<int> colletingResiduals = new List<int>();

            if (dec >= 0 && dec <= 1023)
            {
                do
                {
                    int residualClass = dec%6;
                    colletingResiduals.Add(residualClass);
                    int subtractResidual = dec-residualClass;
                    dec = subtractResidual/6;
                }
                while (dec != 0);
            }

            colletingResiduals.Reverse();
            int sumUpResiduals = 0;
            for (int i = 0; i <= colletingResiduals.Count-1; i++)
            {
                sumUpResiduals += colletingResiduals[i] * Convert.ToInt32(Math.Pow(10, colletingResiduals.Count-i-1));
            }

            //ToDezimal(sumUpResiduals);
            //Console.WriteLine(sumUpResiduals);
            return sumUpResiduals; //und eine Zahl im Sechser-System zurückliefert
        }
        public static int ToDezimal(int hex) // welche eine solche Hexalzahl entgegen nimmt 
        {
            summedUpSubtotals = 0;
            int[] digits = new int[1 + (int)Math.Log10(hex)];
            for (int i = digits.Length-1; i >= 0; i--)
            {
                int digit;
                hex = Math.DivRem(hex, 10, out digit);
                digits[i] = digit;
            }

            List<int> subtotalCollector = new List<int>();
            Array.Reverse(digits);
            for (int i = 0; i <= digits.Length-1; i++)
            {
                int subtotal = digits[i] * (int)Math.Pow(6, i);
                subtotalCollector.Add(subtotal);
            }

            for (int i = 0; i <= subtotalCollector.Count-1; i++)
            {
                summedUpSubtotals = summedUpSubtotals + subtotalCollector[i];
            }

            return summedUpSubtotals;
        }

        public static int ConvertToBaseFromDecimal(int toBase, int dec)
        {
            List<int> colletingResiduals = new List<int>();

            if (dec >= 0 && dec <= 1023)
            {
                do
                {
                    int residualClass = dec%toBase;
                    colletingResiduals.Add(residualClass);
                    int subtractResidual = dec-residualClass;
                    dec = subtractResidual/toBase;
                }
                while (dec != 0);
            }

            subtotalCollector = 0;
            colletingResiduals.Reverse();
            for (int i = 0; i <= colletingResiduals.Count-1; i++)
            {
                subtotalCollector += colletingResiduals[i] * Convert.ToInt32(Math.Pow(10, colletingResiduals.Count-i-1));
            }

            return subtotalCollector;
        }

        public static int ConvertToDecimalFromBase(int fromBase, int number)
        {

            summedUpSubtotals = 0;
            if (number >= 0 && number <= 1023)
            {
                int[] digits = new int[1 + (int)Math.Log10(number)];
                for (int i = digits.Length-1; i >= 0; i--)
                {
                    int digit;
                    number = Math.DivRem(number, 10, out digit);
                    digits[i] = digit;
                }

                List<int> subtotalCollector = new List<int>();
                Array.Reverse(digits);
                for (int i = 0; i <= digits.Length - 1; i++)
                {
                    int subtotal = digits[i]*(int)Math.Pow(fromBase, i);
                    subtotalCollector.Add(subtotal);
                }

                for (int i = 0; i <= subtotalCollector.Count-1; i++)
                {
                    summedUpSubtotals = summedUpSubtotals + subtotalCollector[i];

                }

            }

            return summedUpSubtotals;
        }

        public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {
            input = number;
            _toBase = toBase;
            _fromBase = fromBase;

            if (toBase>=2 && toBase<=10 && fromBase<=10 && fromBase>=2)
            {
                ConvertToDecimalFromBase(fromBase, number);
                ConvertToBaseFromDecimal(toBase, summedUpSubtotals);
            }
            return subtotalCollector;
        }

    }

}
