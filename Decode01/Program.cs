using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text;

Console.WriteLine("Hex to Text Decode With Keyword Ex. and Hex Ex. (By OhmFn X2)");

Console.WriteLine("--------- Input -----------");

Console.Write("Keyword Ex.: ");
byte[] ba = Encoding.Default.GetBytes(Console.ReadLine());
Console.Write("Hex Ex.: ");
BigInteger bi2 = BigInteger.Parse(Console.ReadLine().ToLower(), NumberStyles.HexNumber);
Console.Write("Hex to text: ");
string inputA = Console.ReadLine().ToLower();

Console.WriteLine("--------- Result -----------");

static byte[] HexStringToBytes(string hexString)
{
    if (hexString == null)
        throw new ArgumentNullException("hexString");
    if (hexString.Length % 2 != 0)
        throw new ArgumentException("hexString must have an even length", "hexString");
    var bytes = new byte[hexString.Length / 2];
    for (int i = 0; i < bytes.Length; i++)
    {
        string currentHex = hexString.Substring(i * 2, 2);
        bytes[i] = Convert.ToByte(currentHex, 16);
    }
    return bytes;
}


var hexString = BitConverter.ToString(ba);

hexString = hexString.Replace("-", "");

BigInteger bi1 = BigInteger.Parse(hexString, NumberStyles.HexNumber);
BigInteger sum = BigInteger.Subtract(bi1, bi2);

int decValue = int.Parse(string.Format("{0:x}", sum), System.Globalization.NumberStyles.HexNumber);

BigInteger br1 = BigInteger.Parse(inputA, NumberStyles.HexNumber);

BigInteger sum2 = BigInteger.Add(br1, sum);

Console.WriteLine($"Ex. Text to Hex: {string.Format("{0:x}", bi1)}");

Console.WriteLine($"Subtract Decimal: {decValue}");

Console.WriteLine($"Subtract Hex: {string.Format("{0:x}", sum)}");

Console.WriteLine($"Result Hex: {string.Format("{0:x}", sum2)}");
Console.WriteLine($"Result Text: {Encoding.GetEncoding("UTF-8").GetString(HexStringToBytes(string.Format("{0:x}", sum2)))}");

File.WriteAllText("output.txt", Encoding.GetEncoding("UTF-8").GetString(HexStringToBytes(string.Format("{0:x}", sum2))));

//Console.WriteLine("ไทยเทส");

Console.WriteLine("------------------------");

Console.Write("--------- press any key ---------");
Console.ReadKey();

//By OhmFn X2