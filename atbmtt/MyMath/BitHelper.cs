namespace Atbmtt.MyMath;

public static class BinHexHelper
{
    public static Dictionary<string, string> BinToHexMap = new Dictionary<string, string>
    {
        { "0000", "0" },
        { "0001", "1" },
        { "0010", "2" },
        { "0011", "3" },
        { "0100", "4" },
        { "0101", "5" },
        { "0110", "6" },
        { "0111", "7" },
        { "1000", "8" },
        { "1001", "9" },
        { "1010", "A" },
        { "1011", "B" },
        { "1100", "C" },
        { "1101", "D" },
        { "1110", "E" },
        { "1111", "F" },
    };

    public static Dictionary<string, string> HexToBinMap = BinToHexMap.ToDictionary(
        kvp => kvp.Value,
        kvp => kvp.Key
    );

    public static string BinToHex(string binary)
    {
        if (binary.Length % 4 != 0)
        {
            throw new ArgumentException("Binary string length must be a multiple of 4.");
        }

        string hex = string.Empty;
        for (int i = 0; i < binary.Length; i += 4)
        {
            string binSegment = binary.Substring(i, 4);
            hex += BinToHexMap[binSegment];
        }
        return hex;
    }

    public static string HexToBin(string hex)
    {
        string binary = string.Empty;
        foreach (char c in hex)
        {
            if (HexToBinMap.ContainsKey(c.ToString()))
            {
                binary += HexToBinMap[c.ToString()];
            }
            else
            {
                throw new ArgumentException($"Invalid hex character: {c}");
            }
        }
        return binary;
    }




}
