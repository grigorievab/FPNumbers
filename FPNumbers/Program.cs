using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FPNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float f, f2;
            double d, d2;

            Console.WriteLine("Equality of double and float");
            f = 0.109344482421875f;
            d = 0.109344482421875;
            Console.WriteLine($"f == d for 0.109344482421875: {f == d}");
            f = 0.1f;
            d = 0.1;
            Console.WriteLine($"f == d for 0.1: {f == d}");
            Console.WriteLine();

            Console.WriteLine("NaN comparison");
            f = float.NaN;
            Console.WriteLine($"f == f: {f == f}");
            Console.WriteLine($"f != f: {f != f}");
            d = double.NaN;
            Console.WriteLine($"d == d: { d == d}");
            Console.WriteLine($"d != d: {d != d}");
            Console.WriteLine();

            Console.WriteLine("1 to power of NaN");
            Console.WriteLine($"1^NaN={Math.Pow(1, double.NaN)}");
            Console.WriteLine();

            Console.WriteLine("Plus and minus");
            d = 1e200;
            d *= 1e200;
            Console.WriteLine($"1e200 * 1e200 = {d}");
            d = -1e200;
            d *= 1e200;
            Console.WriteLine($"-1e200 * 1e200 = {d}");
            d = 1e-200;
            d *= 1e-200;
            Console.WriteLine($"1e-200 * 1e-200 = {d}");
            d = -1e-200;
            d *= 1e-200;
            Console.WriteLine($"-1e-200 * 1e-200 = {d}");
            Console.WriteLine($"-0 == 0: {d == 0}");
            Console.WriteLine();

            Console.WriteLine("Float and double 0.1");
            d = 0.1f;
            Console.WriteLine($"0.1f = {d}");
            d2 = 0.1;
            Console.WriteLine($"0.1d = {d2}");
            Console.WriteLine($"0.1f > 0.1d: {d > d2}");
            Console.WriteLine();

            Console.WriteLine("0.1*10");
            f = 0.1f;
            f = 1 - 10 * f;
            Console.WriteLine($"1 - 0.1f*10: {f}");
            d = 0.1;
            d = 1 - 10 * d;
            Console.WriteLine($"1 - 0.1d*10: {d}");
            Console.WriteLine();

            Console.WriteLine("n*(1/n) != 1");
            f = 1.0f / 47;
            f = 1 - f * 47;
            Console.WriteLine($"1 - 47 * (1 / 47) Float: {f}");
            d = 1.0d / 47;
            d = 1 - d * 47;
            Console.WriteLine($"1 - 47 * (1 / 47) Double: {d}");
            f = 1.0f / 49;
            f = 1 - f * 49;
            Console.WriteLine($"1 - 49 * (1 / 49) Float: {f}");
            d = 1.0d / 49;
            d = 1 - d * 49;
            Console.WriteLine($"1 - 49 * (1 / 49) Double: {d}");
            Console.WriteLine();

            Console.WriteLine("Subtraction in cycle");
            f = 1;
            for (int i = 0; i < 10; i++)
                f -= 0.1f;
            Console.WriteLine($"1.0f - 0.1f (10 times): {f}");
            d = 1;
            for (int i = 0; i < 10; i++)
                d -= 0.1;
            Console.WriteLine($"1.0d - 0.1d (10 times): {d}");
            Console.WriteLine();

            Console.WriteLine("Subtraction 10 times");
            f2 = 0.1f;
            f = 1 - f2 - f2 - f2 - f2 - f2 - f2 - f2 - f2 - f2 - f2;
            Console.WriteLine($"1.0f - 0.1f (10 times): {f}");
            d2 = 0.1;
            d = 1 - d2 - d2 - d2 - d2 - d2 - d2 - d2 - d2 - d2 - d2;
            Console.WriteLine($"1.0d - 0.1d (10 times): {d}");
            Console.WriteLine();

            Console.WriteLine("Simple epsilon search");
            f = 1;
            while (1 + f / 2 > 1)
                f /= 2;
            Console.WriteLine($"Float epsilon: {f}");
            d = 1;
            while (1 + d / 2 > 1)
                d /= 2;
            Console.WriteLine($"Double epsilon: {d}");
            Console.WriteLine();

            Console.WriteLine("Epsilon search by steps");
            f = 1;
            while (true)
            {
                f2 = f / 2;
                f2 = 1 + f2;
                if (f2 == 1)
                    break;
                f /= 2;
            }
            Console.WriteLine($"Float epsilon: {f}");
            d = 1;
            while (true)
            {
                d2 = d / 2;
                d2 = 1 + d2;
                if (d2 == 1)
                    break;
                d /= 2;
            }
            Console.WriteLine($"Double epsilon: {d}");
            Console.WriteLine();

            Console.WriteLine("Terms rearrangement");
            double[] da = new double[1000000];
            for (int i = 1; i < da.Length; i++)
                da[i] = 100;
            da[0] = 1e19;
            d = 0;
            for (int i = 0; i < da.Length; i++)
                d += da[i];
            Console.WriteLine($"Direct sum: {d}");
            d = 0;
            for (int i = da.Length - 1; i >= 0; i--)
                d += da[i];
            Console.WriteLine($"Reverse sum: {d}");
            Console.WriteLine();

            Console.WriteLine("Terms rearrangement (with 1e18)");
            da[0] = 1e18;
            d = 0;
            for (int i = 0; i < da.Length; i++)
                d += da[i];
            Console.WriteLine($"Direct sum: {d}");
            d = 0;
            for (int i = da.Length - 1; i >= 0; i--)
                d += da[i];
            Console.WriteLine($"Reverse sum: {d}");
            Console.WriteLine();

            Console.WriteLine("1e18 and 100");
            d = 1e18 + 100 - 1e18;
            Console.WriteLine($"1e18 + 100 - 1e18: {d}");
            Console.WriteLine();

            Console.WriteLine("Factors rearrangement");
            d = 1e200;
            d = d * d * 1e-300;
            Console.WriteLine($"1e200*1e200*1e-300: {d}");
            d = 1e200;
            d = d * 1e-300 * d;
            Console.WriteLine($"1e200*1e-300*1e200: {d}");
            d = 1e-200;
            d = d * d * 1e300;
            Console.WriteLine($"1e-200*1e-200*1e300: {d}");
            d = 1e-200;
            d = d * 1e300 * d;
            Console.WriteLine($"1e-200*1e300*1e-200: {d}");
            Console.WriteLine();

            Console.WriteLine("Rounding");
            Console.WriteLine($"[2.5] - [1.5]: {Math.Round(2.5) - Math.Round(1.5)}");
            Console.WriteLine($"[3.5] - [2.5]: {Math.Round(3.5) - Math.Round(2.5)}");
            Console.WriteLine();

            Console.WriteLine("Arithmetic rounding");
            Console.WriteLine($"[2.5] - [1.5]: {Math.Round(2.5, MidpointRounding.AwayFromZero) - Math.Round(1.5, MidpointRounding.AwayFromZero)}");
            Console.WriteLine($"[3.5] - [2.5]: {Math.Round(3.5, MidpointRounding.AwayFromZero) - Math.Round(2.5, MidpointRounding.AwayFromZero)}");
            Console.WriteLine();

            Console.WriteLine("Floor and ceiling");
            Console.WriteLine($"Floor [2.5]: {Math.Floor(2.5)}");
            Console.WriteLine($"Floor [-2.5]: {Math.Floor(-2.5)}");
            Console.WriteLine($"Ceiling [2.5]: {Math.Ceiling(2.5)}");
            Console.WriteLine($"Ceiling [-2.5]: {Math.Ceiling(-2.5)}");
            Console.WriteLine();

            Console.WriteLine("Rounding to hundredths");
            for (int i = 0; i <= 9; i++)
            {
                d = double.Parse($"2.1{i}5");
                Console.WriteLine($"{d}: {Math.Round(d, 2, MidpointRounding.AwayFromZero)}");
            }
            Console.WriteLine();

            Console.WriteLine("Ceiling rounding to hundredths");
            for (int i = 0; i <= 9; i++)
            {
                d = double.Parse($"2.1{i}");
                Console.WriteLine($"{d}: {Math.Round(d, 2, MidpointRounding.ToPositiveInfinity)}");
            }
            Console.WriteLine();

            Console.WriteLine("Decimal subtraction");
            decimal m = 1;
            decimal m2 = 0.1m;
            for (int i = 0; i < 10; i++)
                m -= m2;
            Console.WriteLine($"1 - 0.1m (10 times): {m}");
            Console.WriteLine();

            Console.WriteLine("Performance measurement");
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                d = 0.5;
                d *= 10;
            }
            sw.Stop();
            Console.WriteLine($"Time for double: {sw.ElapsedMilliseconds}");
            sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                m = 0.5m;
                m *= 10;
            }
            sw.Stop();
            Console.WriteLine($"Time for decimal: {sw.ElapsedMilliseconds}");
        }

        private static int FloatToInt(float f)
        {
            byte[] buf = new byte[4];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buf);
            System.IO.BinaryWriter w = new(ms);
            w.Write(f);
            System.IO.BinaryReader r = new System.IO.BinaryReader(ms);
            ms.Position = 0;
            return r.ReadInt32();
        }

        private static float IntToFloat(int f)
        {
            byte[] buf = new byte[4];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buf);
            System.IO.BinaryWriter w = new(ms);
            w.Write(f);
            System.IO.BinaryReader r = new System.IO.BinaryReader(ms);
            ms.Position = 0;
            return r.ReadSingle();
        }

        private static long DoubleToLong(double f)
        {
            byte[] buf = new byte[8];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buf);
            System.IO.BinaryWriter w = new System.IO.BinaryWriter(ms);
            w.Write(f);
            System.IO.BinaryReader r = new System.IO.BinaryReader(ms);
            ms.Position = 0;
            return r.ReadInt64();
        }
    }
}