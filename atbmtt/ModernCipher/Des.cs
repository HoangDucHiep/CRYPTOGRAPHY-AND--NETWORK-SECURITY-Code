using System.Text;
using Atbmtt.Utils;

namespace Atbmtt.ModernCipher;

public class Des
{
    private static readonly byte[] PC1 = new byte[56]
    {
        57,
        49,
        41,
        33,
        25,
        17,
        9,
        1,
        58,
        50,
        42,
        34,
        26,
        18,
        10,
        2,
        59,
        51,
        43,
        35,
        27,
        19,
        11,
        3,
        60,
        52,
        44,
        36,
        63,
        55,
        47,
        39,
        31,
        23,
        15,
        7,
        62,
        54,
        46,
        38,
        30,
        22,
        14,
        6,
        61,
        53,
        45,
        37,
        29,
        21,
        13,
        5,
        28,
        20,
        12,
        4,
    };

    private static readonly byte[] PC2 = new byte[48]
    {
        14,
        17,
        11,
        24,
        1,
        5,
        3,
        28,
        15,
        6,
        21,
        10,
        23,
        19,
        12,
        4,
        26,
        8,
        16,
        7,
        27,
        20,
        13,
        2,
        41,
        52,
        31,
        37,
        47,
        55,
        30,
        40,
        51,
        45,
        33,
        48,
        44,
        49,
        39,
        56,
        34,
        53,
        46,
        42,
        50,
        36,
        29,
        32,
    };

    private static readonly byte[] NumberOfLeftShifts = new byte[16]
    {
        1,
        1,
        2,
        2,
        2,
        2,
        2,
        2,
        1,
        2,
        2,
        2,
        2,
        2,
        2,
        1,
    };

    private static readonly byte[] IP = new byte[64]
    {
        58,
        50,
        42,
        34,
        26,
        18,
        10,
        2,
        60,
        52,
        44,
        36,
        28,
        20,
        12,
        4,
        62,
        54,
        46,
        38,
        30,
        22,
        14,
        6,
        64,
        56,
        48,
        40,
        32,
        24,
        16,
        8,
        57,
        49,
        41,
        33,
        25,
        17,
        9,
        1,
        59,
        51,
        43,
        35,
        27,
        19,
        11,
        3,
        61,
        53,
        45,
        37,
        29,
        21,
        13,
        5,
        63,
        55,
        47,
        39,
        31,
        23,
        15,
        7,
    };

    private static readonly byte[] E = new byte[48]
    {
        32,
        1,
        2,
        3,
        4,
        5,
        4,
        5,
        6,
        7,
        8,
        9,
        8,
        9,
        10,
        11,
        12,
        13,
        12,
        13,
        14,
        15,
        16,
        17,
        16,
        17,
        18,
        19,
        20,
        21,
        20,
        21,
        22,
        23,
        24,
        25,
        24,
        25,
        26,
        27,
        28,
        29,
        28,
        29,
        30,
        31,
        32,
        1,
    };

    private static readonly byte[] P = new byte[32]
    {
        16,
        7,
        20,
        21,
        29,
        12,
        28,
        17,
        1,
        15,
        23,
        26,
        5,
        18,
        31,
        10,
        2,
        8,
        24,
        14,
        32,
        27,
        3,
        9,
        19,
        13,
        30,
        6,
        22,
        11,
        4,
        25,
    };

    private static readonly byte[] IPInverse = new byte[64]
    {
        40,
        8,
        48,
        16,
        56,
        24,
        64,
        32,
        39,
        7,
        47,
        15,
        55,
        23,
        63,
        31,
        38,
        6,
        46,
        14,
        54,
        22,
        62,
        30,
        37,
        5,
        45,
        13,
        53,
        21,
        61,
        29,
        36,
        4,
        44,
        12,
        52,
        20,
        60,
        28,
        35,
        3,
        43,
        11,
        51,
        19,
        59,
        27,
        34,
        2,
        42,
        10,
        50,
        18,
        58,
        26,
        33,
        1,
        41,
        9,
        49,
        17,
        57,
        25,
    };

    private static readonly byte[][] S1 = new byte[4][]
    {
        new byte[16] { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
        new byte[16] { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
        new byte[16] { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
        new byte[16] { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 },
    };

    private static readonly byte[][] S2 = new byte[4][]
    {
        new byte[16] { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
        new byte[16] { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
        new byte[16] { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
        new byte[16] { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 },
    };

    private static readonly byte[][] S3 = new byte[4][]
    {
        new byte[16] { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
        new byte[16] { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
        new byte[16] { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
        new byte[16] { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 },
    };

    private static readonly byte[][] S4 = new byte[4][]
    {
        new byte[16] { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
        new byte[16] { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
        new byte[16] { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
        new byte[16] { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 },
    };

    private static readonly byte[][] S5 = new byte[4][]
    {
        new byte[16] { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
        new byte[16] { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
        new byte[16] { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
        new byte[16] { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 },
    };

    private static readonly byte[][] S6 = new byte[4][]
    {
        new byte[16] { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
        new byte[16] { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
        new byte[16] { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
        new byte[16] { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 },
    };

    private static readonly byte[][] S7 = new byte[4][]
    {
        new byte[16] { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
        new byte[16] { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
        new byte[16] { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
        new byte[16] { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 },
    };

    private static readonly byte[][] S8 = new byte[4][]
    {
        new byte[16] { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
        new byte[16] { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
        new byte[16] { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
        new byte[16] { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 },
    };

    private static readonly byte[][][] SBoxes = new byte[8][][] { S1, S2, S3, S4, S5, S6, S7, S8 };

    public static Dictionary<char, byte[]> HexToBin = new Dictionary<char, byte[]>()
    {
        { '0', [0, 0, 0, 0] },
        { '1', [0, 0, 0, 1] },
        { '2', [0, 0, 1, 0] },
        { '3', [0, 0, 1, 1] },
        { '4', [0, 1, 0, 0] },
        { '5', [0, 1, 0, 1] },
        { '6', [0, 1, 1, 0] },
        { '7', [0, 1, 1, 1] },
        { '8', [1, 0, 0, 0] },
        { '9', [1, 0, 0, 1] },
        { 'A', [1, 0, 1, 0] },
        { 'B', [1, 0, 1, 1] },
        { 'C', [1, 1, 0, 0] },
        { 'D', [1, 1, 0, 1] },
        { 'E', [1, 1, 1, 0] },
        { 'F', [1, 1, 1, 1] },
    };

    public static Dictionary<string, char> BinToHex = new Dictionary<string, char>()
    {
        { "0000", '0' },
        { "0001", '1' },
        { "0010", '2' },
        { "0011", '3' },
        { "0100", '4' },
        { "0101", '5' },
        { "0110", '6' },
        { "0111", '7' },
        { "1000", '8' },
        { "1001", '9' },
        { "1010", 'A' },
        { "1011", 'B' },
        { "1100", 'C' },
        { "1101", 'D' },
        { "1110", 'E' },
        { "1111", 'F' },
    };

    public static string Encrypt(string MHex, string keyHex)
    {
        MHex.RemoveWhitespace();
        keyHex.RemoveWhitespace();

        if (MHex.Length != 16 || keyHex.Length != 16)
        {
            throw new ArgumentException("Message and key length must be 16 hex characters.");
        }

        byte[] message = new byte[64];
        byte[] key = new byte[64];

        for (int i = 0; i < 16; i++)
        {
            byte[] bin = HexToBin[MHex[i]];
            Array.Copy(bin, 0, message, i * 4, 4);
            bin = HexToBin[keyHex[i]];
            Array.Copy(bin, 0, key, i * 4, 4);
        }

        if (message.Length != 64)
        {
            throw new ArgumentException("Message length must be 64 bits.");
        }

        if (key.Length != 64)
        {
            throw new ArgumentException("Key length must be 64 bits.");
        }

        byte[] CnDn = GetPC1Permutation(key);
        Console.WriteLine("\n=======================\nCnDn");

        Display(CnDn, 7);
        byte[][] keys = GetAllShiftedKeys(CnDn);
        Console.WriteLine("\n=======================\nShifted Keys");
        DisplayAll(keys, 7);
        byte[][] permutedKeys = GetAllPC2Permutation(keys);
        Console.WriteLine("\n=======================\nPermuted Keys");
        DisplayAll(permutedKeys, 7);

        byte[] permutedMessage = GetInitialPermutation(message);
        Console.WriteLine("\n=======================\nPermuted Message");
        Display(permutedMessage, 6);
        byte[] leftHalf,
            rightHalf;
        (leftHalf, rightHalf) = SplitHalf(permutedMessage);
        Console.WriteLine("\n=======================\nLeft Half 0");
        Display(leftHalf, 6);
        Console.WriteLine("\nRight Half 0");
        Display(rightHalf, 6);

        for (int i = 0; i < 16; i++)
        {
            byte[] fFunctionResult = GetFFunction(rightHalf, permutedKeys[i]);
            byte[] xorResult = XOR(leftHalf, fFunctionResult);
            leftHalf = rightHalf;
            rightHalf = xorResult;

            Console.WriteLine("\n=======================\nLeft Half " + (i + 1));
            Display(leftHalf, 6);
            Console.WriteLine("\nRight Half " + (i + 1));
            Display(rightHalf, 6);
        }

        byte[] combinedResult = MergeHalves(rightHalf, leftHalf);
        Console.WriteLine("\n=======================\nCombined Result R16-L16");
        Display(combinedResult, 8);

        byte[] IpInverse = GetIPInverse(combinedResult);
        Console.WriteLine("\n=======================\nIP Inverse");
        Display(IpInverse, 8);
        Console.WriteLine("\n");

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 16; i++)
        {
            sb.Append(
                BinToHex[
                    IpInverse[i * 4]
                        + ""
                        + IpInverse[i * 4 + 1]
                        + ""
                        + IpInverse[i * 4 + 2]
                        + ""
                        + IpInverse[i * 4 + 3]
                ]
            );
        }
        return sb.ToString();
    }

    public static string Decrypt(string MHex, string keyHex)
    {
        MHex.RemoveWhitespace();
        keyHex.RemoveWhitespace();

        if (MHex.Length != 16 || keyHex.Length != 16)
        {
            throw new ArgumentException("Message and key length must be 16 hex characters.");
        }

        byte[] message = new byte[64];
        byte[] key = new byte[64];

        for (int i = 0; i < 16; i++)
        {
            byte[] bin = HexToBin[MHex[i]];
            Array.Copy(bin, 0, message, i * 4, 4);
            bin = HexToBin[keyHex[i]];
            Array.Copy(bin, 0, key, i * 4, 4);
        }

        if (message.Length != 64)
        {
            throw new ArgumentException("Message length must be 64 bits.");
        }

        if (key.Length != 64)
        {
            throw new ArgumentException("Key length must be 64 bits.");
        }

        byte[] CnDn = GetPC1Permutation(key);
        byte[][] keys = GetAllShiftedKeys(CnDn);
        byte[][] permutedKeys = GetAllPC2Permutation(keys);

        byte[] permutedMessage = GetInitialPermutation(message);
        byte[] leftHalf,
            rightHalf;
        (leftHalf, rightHalf) = SplitHalf(permutedMessage);

        for (int i = 0; i < 16; i++)
        {
            byte[] fFunctionResult = GetFFunction(rightHalf, permutedKeys[15 - i]);
            byte[] xorResult = XOR(leftHalf, fFunctionResult);
            leftHalf = rightHalf;
            rightHalf = xorResult;
        }

        byte[] combinedResult = MergeHalves(rightHalf, leftHalf);
        byte[] IpInverse = GetIPInverse(combinedResult);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 16; i++)
        {
            sb.Append(
                BinToHex[
                    IpInverse[i * 4]
                        + ""
                        + IpInverse[i * 4 + 1]
                        + ""
                        + IpInverse[i * 4 + 2]
                        + ""
                        + IpInverse[i * 4 + 3]
                ]
            );
        }
        return sb.ToString();
    }

    public static byte[] GetIPInverse(byte[] input)
    {
        if (input.Length != 64)
        {
            throw new ArgumentException("Input for IP inverse length must be 64 bits.");
        }

        byte[] result = new byte[64];
        for (int i = 0; i < 64; i++)
        {
            result[i] = input[IPInverse[i] - 1];
        }
        return result;
    }

    public static byte[] GetFFunction(byte[] rightHalf, byte[] key)
    {
        if (rightHalf.Length != 32 || key.Length != 48)
        {
            throw new ArgumentException(
                "Right half length must be 32 bits and key length must be 48 bits."
            );
        }

        byte[] expandedRightHalf = GetESelection(rightHalf);
        byte[] xorResult = XOR(expandedRightHalf, key);
        byte[] sBoxOutput = GetS(xorResult);
        byte[] pPermutation = GetPPermutation(sBoxOutput);

        return pPermutation;
    }

    public static byte[] GetPPermutation(byte[] input)
    {
        if (input.Length != 32)
        {
            throw new ArgumentException("Input for P length must be 32 bits.");
        }

        byte[] result = new byte[32];
        for (int i = 0; i < 32; i++)
        {
            result[i] = input[P[i] - 1];
        }
        return result;
    }

    public static byte[] GetS(byte[] input)
    {
        if (input.Length != 48)
        {
            throw new ArgumentException("Input for S length must be 48 bits.");
        }

        byte[] result = new byte[32];
        for (int i = 0; i < 8; i++)
        {
            byte[] sInput = new byte[6];
            Array.Copy(input, i * 6, sInput, 0, 6);
            byte[] sOutput = Si(sInput, i + 1);
            Array.Copy(sOutput, 0, result, i * 4, 4);
        }
        return result;
    }

    public static byte[] Si(byte[] input, int index)
    {
        if (input.Length != 6)
        {
            throw new ArgumentException("Input for Si length must be 6 bits.");
        }

        if (index < 1 || index > 8)
        {
            throw new ArgumentException("Index must be between 1 and 8.");
        }

        index -= 1;

        int row = input[0] * 2 + input[5];
        int column = input[1] * 8 + input[2] * 4 + input[3] * 2 + input[4];
        byte sValue = SBoxes[index][row][column];

        byte[] result = new byte[4];

        int i = 3;
        while (sValue > 0)
        {
            result[i] = (byte)(sValue % 2);
            sValue /= 2;
            i--;
        }
        while (i >= 0)
        {
            result[i] = 0;
            i--;
        }

        return result;
    }

    public static byte[] GetInitialPermutation(byte[] message)
    {
        if (message.Length != 64)
        {
            throw new ArgumentException("Message length must be 64 bits.");
        }

        byte[] permutedMessage = new byte[64];
        for (int i = 0; i < 64; i++)
        {
            permutedMessage[i] = message[IP[i] - 1];
        }
        return permutedMessage;
    }

    public static byte[] GetESelection(byte[] rightHalf)
    {
        if (rightHalf.Length != 32)
        {
            throw new ArgumentException("Right half length must be 32 bits.");
        }

        byte[] expanded = new byte[48];
        for (int i = 0; i < 48; i++)
        {
            expanded[i] = rightHalf[E[i] - 1];
        }
        return expanded;
    }

    public static byte[] XOR(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
        {
            throw new ArgumentException("Arrays must be of the same length.");
        }

        byte[] result = new byte[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] == b[i] ? (byte)0 : (byte)1;
        }
        return result;
    }

    public static byte[] GetPC1Permutation(byte[] key)
    {
        byte[] result = new byte[56];
        for (int i = 0; i < 56; i++)
        {
            result[i] = key[PC1[i] - 1];
        }
        return result;
    }

    public static byte[] GetLeftShiftedKey(byte[] key, int round)
    {
        byte[] leftHalf;
        byte[] rightHalf;

        (leftHalf, rightHalf) = SplitHalf(key);

        int numberOfShifts = NumberOfLeftShifts[round];
        for (int i = 0; i < numberOfShifts; i++)
        {
            // Left shift the left half
            byte temp = leftHalf[0];
            for (int j = 0; j < 27; j++)
            {
                leftHalf[j] = leftHalf[j + 1];
            }
            leftHalf[27] = temp;

            // Left shift the right half
            temp = rightHalf[0];
            for (int j = 0; j < 27; j++)
            {
                rightHalf[j] = rightHalf[j + 1];
            }
            rightHalf[27] = temp;
        }

        return MergeHalves(leftHalf, rightHalf);
    }

    public static byte[][] GetAllShiftedKeys(byte[] key)
    {
        byte[][] keys = new byte[16][];

        for (int i = 0; i < 16; i++)
        {
            byte[] shiftedKey = GetLeftShiftedKey(key, i);
            keys[i] = shiftedKey;
            key = shiftedKey;
        }

        return keys;
    }

    public static byte[][] GetAllPC2Permutation(byte[][] CnDn)
    {
        byte[][] keys = new byte[16][];
        for (int i = 0; i < 16; i++)
        {
            keys[i] = GetPC2Permutation(CnDn[i]);
        }
        return keys;
    }

    public static void DisplayAll(byte[][] keys, byte splitAt = 7)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            Console.Write($"Key {i + 1}: ");
            for (int j = 0; j < keys[i].Length; j++)
            {
                Console.Write(keys[i][j] + " ");
                if ((j + 1) % splitAt == 0)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();
        }
    }

    public static void Display(byte[] keys, byte splitAt = 7)
    {
        for (int j = 0; j < keys.Length; j++)
        {
            Console.Write(keys[j] + " ");
            if ((j + 1) % splitAt == 0)
            {
                Console.Write(" | ");
            }
        }
    }

    public static byte[] GetPC2Permutation(byte[] CnDn)
    {
        byte[] result = new byte[48];
        for (int i = 0; i < 48; i++)
        {
            result[i] = CnDn[PC2[i] - 1];
        }
        return result;
    }

    public static (byte[], byte[]) SplitHalf(byte[] key)
    {
        int length = key.Length;
        if (length % 2 != 0)
        {
            throw new ArgumentException("Key length must be even.");
        }
        int halfLength = length / 2;

        byte[] leftHalf = new byte[halfLength];
        byte[] rightHalf = new byte[halfLength];

        Array.Copy(key, 0, leftHalf, 0, halfLength);

        Array.Copy(key, halfLength, rightHalf, 0, halfLength);
        return (leftHalf, rightHalf);
    }

    public static byte[] MergeHalves(byte[] leftHalf, byte[] rightHalf)
    {
        int length = leftHalf.Length + rightHalf.Length;
        byte[] merged = new byte[length];
        Array.Copy(leftHalf, 0, merged, 0, leftHalf.Length);
        Array.Copy(rightHalf, 0, merged, leftHalf.Length, rightHalf.Length);
        return merged;
    }
}
