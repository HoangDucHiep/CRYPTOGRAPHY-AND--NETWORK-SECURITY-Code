using System.Text;

namespace Atbmtt.ModernCipher;

public class Aes
{
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

    public static Dictionary<char, byte> HexToDec = new Dictionary<char, byte>()
    {
        { '0', 0 },
        { '1', 1 },
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'A', 10 },
        { 'B', 11 },
        { 'C', 12 },
        { 'D', 13 },
        { 'E', 14 },
        { 'F', 15 },
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
    public static readonly byte[][][] SBoxBits = new byte[][][]
    {
        [
            new byte[] { 0, 1, 1, 0, 0, 0, 1, 1 },
            new byte[] { 0, 1, 1, 1, 1, 1, 0, 0 },
            new byte[] { 0, 1, 1, 1, 0, 1, 1, 1 },
            new byte[] { 0, 1, 1, 1, 1, 0, 1, 1 },
            new byte[] { 1, 1, 1, 1, 0, 0, 1, 0 },
            new byte[] { 0, 1, 1, 0, 1, 0, 1, 1 },
            new byte[] { 0, 1, 1, 0, 1, 1, 1, 1 },
            new byte[] { 1, 1, 0, 0, 0, 1, 0, 1 },
            new byte[] { 0, 0, 1, 1, 0, 0, 0, 0 },
            new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 },
            new byte[] { 0, 1, 1, 0, 0, 1, 1, 1 },
            new byte[] { 0, 0, 1, 0, 1, 0, 1, 1 },
            new byte[] { 1, 1, 1, 1, 1, 1, 1, 0 },
            new byte[] { 1, 1, 0, 1, 0, 1, 1, 1 },
            new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 },
            new byte[] { 0, 1, 1, 1, 0, 1, 1, 0 },
        ],
        new byte[][]
        {
            new byte[] { 1, 1, 0, 0, 1, 0, 1, 0 },
            new byte[] { 1, 0, 0, 0, 0, 0, 1, 0 },
            new byte[] { 1, 1, 0, 0, 1, 0, 0, 1 },
            new byte[] { 0, 1, 1, 1, 1, 1, 0, 1 },
            new byte[] { 1, 1, 1, 1, 1, 0, 1, 0 },
            new byte[] { 0, 1, 0, 1, 1, 0, 0, 1 },
            new byte[] { 0, 1, 0, 0, 0, 1, 1, 1 },
            new byte[] { 1, 1, 1, 1, 0, 0, 0, 0 },
            new byte[] { 1, 0, 1, 0, 1, 1, 0, 1 },
            new byte[] { 1, 1, 0, 1, 0, 1, 0, 0 },
            new byte[] { 1, 0, 1, 0, 0, 0, 1, 0 },
            new byte[] { 1, 0, 1, 0, 1, 1, 1, 1 },
            new byte[] { 1, 0, 0, 1, 1, 1, 0, 0 },
            new byte[] { 1, 0, 1, 0, 0, 1, 0, 0 },
            new byte[] { 0, 1, 1, 1, 0, 0, 1, 0 },
            new byte[] { 1, 1, 0, 0, 0, 0, 0, 0 },
        },
        new byte[][]
        {
            new byte[] { 1, 0, 1, 1, 0, 1, 1, 1 },
            new byte[] { 1, 1, 1, 1, 1, 1, 0, 1 },
            new byte[] { 1, 0, 0, 1, 0, 0, 1, 1 },
            new byte[] { 0, 0, 1, 0, 0, 1, 1, 0 },
            new byte[] { 0, 0, 1, 1, 0, 1, 1, 0 },
            new byte[] { 0, 0, 1, 1, 1, 1, 1, 1 },
            new byte[] { 1, 1, 1, 1, 0, 1, 1, 1 },
            new byte[] { 1, 1, 0, 0, 1, 1, 0, 0 },
            new byte[] { 0, 0, 1, 1, 0, 1, 0, 0 },
            new byte[] { 1, 0, 1, 0, 0, 1, 0, 1 },
            new byte[] { 1, 1, 1, 0, 0, 1, 0, 1 },
            new byte[] { 1, 1, 1, 1, 0, 0, 0, 1 },
            new byte[] { 0, 1, 1, 1, 0, 0, 0, 1 },
            new byte[] { 1, 1, 0, 1, 1, 0, 0, 0 },
            new byte[] { 0, 0, 1, 1, 0, 0, 0, 1 },
            new byte[] { 0, 0, 0, 1, 0, 1, 0, 1 },
        },
        new byte[][]
        {
            new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 },
            new byte[] { 1, 1, 0, 0, 0, 1, 1, 1 },
            new byte[] { 0, 0, 1, 0, 0, 0, 1, 1 },
            new byte[] { 1, 1, 0, 0, 0, 0, 1, 1 },
            new byte[] { 0, 0, 0, 1, 1, 0, 0, 0 },
            new byte[] { 1, 0, 0, 1, 0, 1, 1, 0 },
            new byte[] { 0, 0, 0, 0, 0, 1, 0, 1 },
            new byte[] { 1, 0, 0, 1, 1, 0, 1, 0 },
            new byte[] { 0, 0, 0, 0, 0, 1, 1, 1 },
            new byte[] { 0, 0, 0, 1, 0, 0, 1, 0 },
            new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 },
            new byte[] { 1, 1, 1, 0, 0, 0, 1, 0 },
            new byte[] { 1, 1, 1, 0, 1, 0, 1, 1 },
            new byte[] { 0, 0, 1, 0, 0, 1, 1, 1 },
            new byte[] { 1, 0, 1, 1, 0, 0, 1, 0 },
            new byte[] { 0, 1, 1, 1, 0, 1, 0, 1 },
        },
        new byte[][]
        {
            new byte[] { 0, 0, 0, 0, 1, 0, 0, 1 },
            new byte[] { 1, 0, 0, 0, 0, 0, 1, 1 },
            new byte[] { 0, 0, 1, 0, 1, 1, 0, 0 },
            new byte[] { 0, 0, 0, 1, 1, 0, 1, 0 },
            new byte[] { 0, 0, 0, 1, 1, 0, 1, 1 },
            new byte[] { 0, 1, 1, 0, 1, 1, 1, 0 },
            new byte[] { 0, 1, 0, 1, 1, 0, 1, 0 },
            new byte[] { 1, 0, 1, 0, 0, 0, 0, 0 },
            new byte[] { 0, 1, 0, 1, 0, 0, 1, 0 },
            new byte[] { 0, 0, 1, 1, 1, 0, 1, 1 },
            new byte[] { 1, 1, 0, 1, 0, 1, 1, 0 },
            new byte[] { 1, 0, 1, 1, 0, 0, 1, 1 },
            new byte[] { 0, 0, 1, 0, 1, 0, 0, 1 },
            new byte[] { 1, 1, 1, 0, 0, 0, 1, 1 },
            new byte[] { 0, 0, 1, 0, 1, 1, 1, 1 },
            new byte[] { 1, 0, 0, 0, 0, 1, 0, 0 },
        },
        new byte[][]
        {
            new byte[] { 0, 1, 0, 1, 0, 0, 1, 1 },
            new byte[] { 1, 1, 0, 1, 0, 0, 0, 1 },
            new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
            new byte[] { 1, 1, 1, 0, 1, 1, 0, 1 },
            new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 },
            new byte[] { 1, 1, 1, 1, 1, 1, 0, 0 },
            new byte[] { 1, 0, 1, 1, 0, 0, 0, 1 },
            new byte[] { 0, 1, 0, 1, 1, 0, 1, 1 },
            new byte[] { 0, 1, 1, 0, 1, 0, 1, 0 },
            new byte[] { 1, 1, 0, 0, 1, 0, 1, 1 },
            new byte[] { 1, 0, 1, 1, 1, 1, 1, 0 },
            new byte[] { 0, 0, 1, 1, 1, 0, 0, 1 },
            new byte[] { 0, 1, 0, 0, 1, 0, 1, 0 },
            new byte[] { 0, 1, 0, 0, 1, 1, 0, 0 },
            new byte[] { 0, 1, 0, 1, 1, 0, 0, 0 },
            new byte[] { 1, 1, 0, 0, 1, 1, 1, 1 },
        },
        new byte[][]
        {
            new byte[] { 1, 1, 0, 1, 0, 0, 0, 0 },
            new byte[] { 1, 1, 1, 0, 1, 1, 1, 1 },
            new byte[] { 1, 0, 1, 0, 1, 0, 1, 0 },
            new byte[] { 1, 1, 1, 1, 1, 0, 1, 1 },
            new byte[] { 0, 1, 0, 0, 0, 0, 1, 1 },
            new byte[] { 0, 1, 0, 0, 1, 1, 0, 1 },
            new byte[] { 0, 0, 1, 1, 0, 0, 1, 1 },
            new byte[] { 1, 0, 0, 0, 0, 1, 0, 1 },
            new byte[] { 0, 1, 0, 0, 0, 1, 0, 1 },
            new byte[] { 1, 1, 1, 1, 1, 0, 0, 1 },
            new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 },
            new byte[] { 0, 1, 1, 1, 1, 1, 1, 1 },
            new byte[] { 0, 1, 0, 1, 0, 0, 0, 0 },
            new byte[] { 0, 0, 1, 1, 1, 1, 0, 0 },
            new byte[] { 1, 0, 0, 1, 1, 1, 1, 1 },
            new byte[] { 1, 0, 1, 0, 1, 0, 0, 0 },
        },
        new byte[][]
        {
            new byte[] { 0, 1, 0, 1, 0, 0, 0, 1 },
            new byte[] { 1, 0, 1, 0, 0, 0, 1, 1 },
            new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 },
            new byte[] { 1, 0, 0, 0, 1, 1, 1, 1 },
            new byte[] { 1, 0, 0, 1, 0, 0, 1, 0 },
            new byte[] { 1, 0, 0, 1, 1, 1, 0, 1 },
            new byte[] { 0, 0, 1, 1, 1, 0, 0, 0 },
            new byte[] { 1, 1, 1, 1, 0, 1, 0, 1 },
            new byte[] { 1, 0, 1, 1, 1, 1, 0, 0 },
            new byte[] { 1, 0, 1, 1, 0, 1, 1, 0 },
            new byte[] { 1, 1, 0, 1, 1, 0, 1, 0 },
            new byte[] { 0, 0, 1, 0, 0, 0, 0, 1 },
            new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 },
            new byte[] { 1, 1, 1, 1, 1, 1, 1, 1 },
            new byte[] { 1, 1, 1, 1, 0, 0, 1, 1 },
            new byte[] { 1, 1, 0, 1, 0, 0, 1, 0 },
        },
        new byte[][]
        {
            new byte[] { 1, 1, 0, 0, 1, 1, 0, 1 },
            new byte[] { 0, 0, 0, 0, 1, 1, 0, 0 },
            new byte[] { 0, 0, 0, 1, 0, 0, 1, 1 },
            new byte[] { 1, 1, 1, 0, 1, 1, 0, 0 },
            new byte[] { 0, 1, 0, 1, 1, 1, 1, 1 },
            new byte[] { 1, 0, 0, 1, 0, 1, 1, 1 },
            new byte[] { 0, 1, 0, 0, 0, 1, 0, 0 },
            new byte[] { 0, 0, 0, 1, 0, 1, 1, 1 },
            new byte[] { 1, 1, 0, 0, 0, 1, 0, 0 },
            new byte[] { 1, 0, 1, 0, 0, 1, 1, 1 },
            new byte[] { 0, 1, 1, 1, 1, 1, 1, 0 },
            new byte[] { 0, 0, 1, 1, 1, 1, 0, 1 },
            new byte[] { 0, 1, 1, 0, 0, 1, 0, 0 },
            new byte[] { 0, 1, 0, 1, 1, 1, 0, 1 },
            new byte[] { 0, 0, 0, 1, 1, 0, 0, 1 },
            new byte[] { 0, 1, 1, 1, 0, 0, 1, 1 },
        },
        new byte[][]
        {
            new byte[] { 0, 1, 1, 0, 0, 0, 0, 0 },
            new byte[] { 1, 0, 0, 0, 0, 0, 0, 1 },
            new byte[] { 0, 1, 0, 0, 1, 1, 1, 1 },
            new byte[] { 1, 1, 0, 1, 1, 1, 0, 0 },
            new byte[] { 0, 0, 1, 0, 0, 0, 1, 0 },
            new byte[] { 0, 0, 1, 0, 1, 0, 1, 0 },
            new byte[] { 1, 0, 0, 1, 0, 0, 0, 0 },
            new byte[] { 1, 0, 0, 0, 1, 0, 0, 0 },
            new byte[] { 0, 1, 0, 0, 0, 1, 1, 0 },
            new byte[] { 1, 1, 1, 0, 1, 1, 1, 0 },
            new byte[] { 1, 0, 1, 1, 1, 0, 0, 0 },
            new byte[] { 0, 0, 0, 1, 0, 1, 0, 0 },
            new byte[] { 1, 1, 0, 1, 1, 1, 1, 0 },
            new byte[] { 0, 1, 0, 1, 1, 1, 1, 0 },
            new byte[] { 0, 0, 0, 0, 1, 0, 1, 1 },
            new byte[] { 1, 1, 0, 1, 1, 0, 1, 1 },
        },
        new byte[][]
        {
            new byte[] { 1, 1, 1, 0, 0, 0, 0, 0 },
            new byte[] { 0, 0, 1, 1, 0, 0, 1, 0 },
            new byte[] { 0, 0, 1, 1, 1, 0, 1, 0 },
            new byte[] { 0, 0, 0, 0, 1, 0, 1, 0 },
            new byte[] { 0, 1, 0, 0, 1, 0, 0, 1 },
            new byte[] { 0, 0, 0, 0, 0, 1, 1, 0 },
            new byte[] { 0, 0, 1, 0, 0, 1, 0, 0 },
            new byte[] { 0, 1, 0, 1, 1, 1, 0, 0 },
            new byte[] { 1, 1, 0, 0, 0, 0, 1, 0 },
            new byte[] { 1, 1, 0, 1, 0, 0, 1, 1 },
            new byte[] { 1, 0, 1, 0, 1, 1, 0, 0 },
            new byte[] { 0, 1, 1, 0, 0, 0, 1, 0 },
            new byte[] { 1, 0, 0, 1, 0, 0, 0, 1 },
            new byte[] { 1, 0, 0, 1, 0, 1, 0, 1 },
            new byte[] { 1, 1, 1, 0, 0, 1, 0, 0 },
            new byte[] { 0, 1, 1, 1, 1, 0, 0, 1 },
        },
        new byte[][]
        {
            new byte[] { 1, 1, 1, 0, 0, 1, 1, 1 },
            new byte[] { 1, 1, 0, 0, 1, 0, 0, 0 },
            new byte[] { 0, 0, 1, 1, 0, 1, 1, 1 },
            new byte[] { 0, 1, 1, 0, 1, 1, 0, 1 },
            new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 },
            new byte[] { 1, 1, 0, 1, 0, 1, 0, 1 },
            new byte[] { 0, 1, 0, 0, 1, 1, 1, 0 },
            new byte[] { 1, 0, 1, 0, 1, 0, 0, 1 },
            new byte[] { 0, 1, 1, 0, 1, 1, 0, 0 },
            new byte[] { 0, 1, 0, 1, 0, 1, 1, 0 },
            new byte[] { 1, 1, 1, 1, 0, 1, 0, 0 },
            new byte[] { 1, 1, 1, 0, 1, 0, 1, 0 },
            new byte[] { 0, 1, 1, 0, 0, 1, 0, 1 },
            new byte[] { 0, 1, 1, 1, 1, 0, 1, 0 },
            new byte[] { 1, 0, 1, 0, 1, 1, 1, 0 },
            new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 },
        },
        new byte[][]
        {
            new byte[] { 1, 0, 1, 1, 1, 0, 1, 0 },
            new byte[] { 0, 1, 1, 1, 1, 0, 0, 0 },
            new byte[] { 0, 0, 1, 0, 0, 1, 0, 1 },
            new byte[] { 0, 0, 1, 0, 1, 1, 1, 0 },
            new byte[] { 0, 0, 0, 1, 1, 1, 0, 0 },
            new byte[] { 1, 0, 1, 0, 0, 1, 1, 0 },
            new byte[] { 1, 0, 1, 1, 0, 1, 0, 0 },
            new byte[] { 1, 1, 0, 0, 0, 1, 1, 0 },
            new byte[] { 1, 1, 1, 0, 1, 0, 0, 0 },
            new byte[] { 1, 1, 0, 1, 1, 1, 0, 1 },
            new byte[] { 0, 1, 1, 1, 0, 1, 0, 0 },
            new byte[] { 0, 0, 0, 1, 1, 1, 1, 1 },
            new byte[] { 0, 1, 0, 0, 1, 0, 1, 1 },
            new byte[] { 1, 0, 1, 1, 1, 1, 0, 1 },
            new byte[] { 1, 0, 0, 0, 1, 0, 1, 1 },
            new byte[] { 1, 0, 0, 0, 1, 0, 1, 0 },
        },
        new byte[][]
        {
            new byte[] { 0, 1, 1, 1, 0, 0, 0, 0 },
            new byte[] { 0, 0, 1, 1, 1, 1, 1, 0 },
            new byte[] { 1, 0, 1, 1, 0, 1, 0, 1 },
            new byte[] { 0, 1, 1, 0, 0, 1, 1, 0 },
            new byte[] { 0, 1, 0, 0, 1, 0, 0, 0 },
            new byte[] { 0, 0, 0, 0, 0, 0, 1, 1 },
            new byte[] { 1, 1, 1, 1, 0, 1, 1, 0 },
            new byte[] { 0, 0, 0, 0, 1, 1, 1, 0 },
            new byte[] { 0, 1, 1, 0, 0, 0, 0, 1 },
            new byte[] { 0, 0, 1, 1, 0, 1, 0, 1 },
            new byte[] { 0, 1, 0, 1, 0, 1, 1, 1 },
            new byte[] { 1, 0, 1, 1, 1, 0, 0, 1 },
            new byte[] { 1, 0, 0, 0, 0, 1, 1, 0 },
            new byte[] { 1, 1, 0, 0, 0, 0, 0, 1 },
            new byte[] { 0, 0, 0, 1, 1, 1, 0, 1 },
            new byte[] { 1, 0, 0, 1, 1, 1, 1, 0 },
        },
        new byte[][]
        {
            new byte[] { 1, 1, 1, 0, 0, 0, 0, 1 },
            new byte[] { 1, 1, 1, 1, 1, 0, 0, 0 },
            new byte[] { 1, 0, 0, 1, 1, 0, 0, 0 },
            new byte[] { 0, 0, 0, 1, 0, 0, 0, 1 },
            new byte[] { 0, 1, 1, 0, 1, 0, 0, 1 },
            new byte[] { 1, 1, 0, 1, 1, 0, 0, 1 },
            new byte[] { 1, 0, 0, 0, 1, 1, 1, 0 },
            new byte[] { 1, 0, 0, 1, 0, 1, 0, 0 },
            new byte[] { 1, 0, 0, 1, 1, 0, 1, 1 },
            new byte[] { 0, 0, 0, 1, 1, 1, 1, 0 },
            new byte[] { 1, 0, 0, 0, 0, 1, 1, 1 },
            new byte[] { 1, 1, 1, 0, 1, 0, 0, 1 },
            new byte[] { 1, 1, 0, 0, 1, 1, 1, 0 },
            new byte[] { 0, 1, 0, 1, 0, 1, 0, 1 },
            new byte[] { 0, 0, 1, 0, 1, 0, 0, 0 },
            new byte[] { 1, 1, 0, 1, 1, 1, 1, 1 },
        },
        new byte[][]
        {
            new byte[] { 1, 0, 0, 0, 1, 1, 0, 0 },
            new byte[] { 1, 0, 1, 0, 0, 0, 0, 1 },
            new byte[] { 1, 0, 0, 0, 1, 0, 0, 1 },
            new byte[] { 0, 0, 0, 0, 1, 1, 0, 1 },
            new byte[] { 1, 0, 1, 1, 1, 1, 1, 1 },
            new byte[] { 1, 1, 1, 0, 0, 1, 1, 0 },
            new byte[] { 0, 1, 0, 0, 0, 0, 1, 0 },
            new byte[] { 0, 1, 1, 0, 1, 0, 0, 0 },
            new byte[] { 0, 1, 0, 0, 0, 0, 0, 1 },
            new byte[] { 1, 0, 0, 1, 1, 0, 0, 1 },
            new byte[] { 0, 0, 1, 0, 1, 1, 0, 1 },
            new byte[] { 0, 0, 0, 0, 1, 1, 1, 1 },
            new byte[] { 1, 0, 1, 1, 0, 0, 0, 0 },
            new byte[] { 0, 1, 0, 1, 0, 1, 0, 0 },
            new byte[] { 1, 0, 1, 1, 1, 0, 1, 1 },
            new byte[] { 0, 0, 0, 1, 0, 1, 1, 0 },
        },
    };
    public static Dictionary<string, int> BinToDec = new Dictionary<string, int>()
    {
        { "0000", 0 },
        { "0001", 1 },
        { "0010", 2 },
        { "0011", 3 },
        { "0100", 4 },
        { "0101", 5 },
        { "0110", 6 },
        { "0111", 7 },
        { "1000", 8 },
        { "1001", 9 },
        { "1010", 10 },
        { "1011", 11 },
        { "1100", 12 },
        { "1101", 13 },
        { "1110", 14 },
        { "1111", 15 },
    };

    public static byte[][] MIX_COLUMN_MATRIX = new byte[][]
    {
        [2, 3, 1, 1],
        [1, 2, 3, 1],
        [1, 1, 2, 3],
        [3, 1, 1, 2],
    };

    private static byte[][] RC = new byte[][]
    {
        [0, 0, 0, 0, 0, 0, 0, 1],
        [0, 0, 0, 0, 0, 0, 1, 0],
        [0, 0, 0, 0, 0, 1, 0, 0],
        [0, 0, 0, 0, 1, 0, 0, 0],
        [0, 0, 0, 1, 0, 0, 0, 0],
        [0, 0, 1, 0, 0, 0, 0, 0],
        [0, 1, 0, 0, 0, 0, 0, 0],
        [1, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 1, 1, 0, 1, 1],
        [0, 0, 1, 1, 0, 1, 1, 0],
    };

    public static string? Encript(string input, string key)
    {
        if (input.Length != 32)
        {
            throw new ArgumentException("Input length must be 32.");
        }

        if (key.Length != 32)
        {
            throw new ArgumentException("Key length must be 32.");
        }

        string[] inputBytes = new string[16];
        string[] keyBytes = new string[16];

        for (int i = 0; i < 16; i++)
        {
            inputBytes[i] = input.Substring(i * 2, 2);
            keyBytes[i] = key.Substring(i * 2, 2);
        }

        byte[][] state = new byte[16][];
        byte[][] binaryKey = new byte[16][];

        for (int i = 0; i < 16; i++)
        {
            state[i] = HexByteToBin(inputBytes[i]);
            binaryKey[i] = HexByteToBin(keyBytes[i]);
        }

        byte[][][] keys = KeyExpansion(binaryKey);

        state = AddRoundKey(state, keys[0]);
        byte[][][] matrixState;

        for (int i = 1; i < 10; i++)
        {
            state = SubByte(state);

            matrixState = ArrayToMatrix(state);
            matrixState = ShiftRow(matrixState);
            matrixState = MixColumns(matrixState);
            string[][] temp = BinMatrixStateToHexState(matrixState);
            state = MatrixToArray(matrixState);
            state = AddRoundKey(state, keys[i]);
        }

        state = SubByte(state);
        matrixState = ArrayToMatrix(state);
        matrixState = ShiftRow(matrixState);
        state = MatrixToArray(matrixState);
        state = AddRoundKey(state, keys[10]);
        return BinArrToString(state);
    }

    private static byte[][][] MixColumns(byte[][][] state)
    {
        byte[][][] res = new byte[4][][];
        for (int row = 0; row < 4; row++)
        {
            res[row] = new byte[4][];
            for (int col = 0; col < 4; col++)
            {
                res[row][col] = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int i = 0; i < 4; i++)
                {
                    if (MIX_COLUMN_MATRIX[row][i] == 1)
                    {
                        res[row][col] = XOR(res[row][col], state[i][col]);
                    }
                    else
                    {
                        byte extraBit;
                        byte[] temp;

                        (temp, extraBit) = DoubleBinary(state[i][col]);

                        if (extraBit == 1)
                        {
                            temp = XOR(temp, [0, 0, 0, 1, 1, 0, 1, 1]);
                        }

                        for (int k = 0; k < MIX_COLUMN_MATRIX[row][i] - 2; k++)
                        {
                            temp = XOR(temp, state[i][col]);
                        }
                        res[row][col] = XOR(res[row][col], temp);
                    }
                }
            }
        }

        return res;
    }

    private static byte[][][] ShiftRow(byte[][][] state)
    {
        state[0] = state[0];
        state[1] = CircularLeftShift(state[1], 1);
        state[2] = CircularLeftShift(state[2], 2);
        state[3] = CircularLeftShift(state[3], 3);

        return state;
    }

    private static byte[][][] ArrayToMatrix(byte[][] state)
    {
        byte[][][] matrixState = new byte[4][][];
        matrixState[0] = new byte[4][];
        matrixState[1] = new byte[4][];
        matrixState[2] = new byte[4][];
        matrixState[3] = new byte[4][];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrixState[j][i] = state[i * 4 + j];
            }
        }

        return matrixState;
    }

    private static byte[][] MatrixToArray(byte[][][] state)
    {
        byte[][] res = new byte[16][];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                res[i * 4 + j] = state[j][i];
            }
        }
        return res;
    }

    private static (byte[] res, byte extra) DoubleBinary(byte[] input)
    {
        byte extraBit = input[0];
        byte[] res = new byte[input.Length];

        for (int i = 0; i < input.Length - 1; i++)
        {
            res[i] = input[i + 1];
        }

        res[input.Length - 1] = 0;

        return (res, extraBit);
    }

    private static byte[][] AddRoundKey(byte[][] state, byte[][] key)
    {
        byte[][] res = new byte[16][];
        for (int i = 0; i < 16; i++)
        {
            res[i] = XOR(state[i], key[i]);
        }
        return res;
    }

    private static byte[][][] KeyExpansion(byte[][] key)
    {
        if (key.Length != 16)
        {
            throw new ArgumentException("Key length must be 16 bytes.");
        }

        byte[][][] Keys = new byte[11][][];
        Keys[0] = key;
        var temp = Split(key, 4);
        byte[][][] Ws = new byte[44][][];
        Ws[0] = temp[0];
        Ws[1] = temp[1];
        Ws[2] = temp[2];
        Ws[3] = temp[3];

        for (byte i = 1; i <= 10; i++)
        {
            byte[][] g = G(Ws[i * 4 - 1], i);
            Ws[i * 4] = XorWord(Ws[(i - 1) * 4], g);
            Ws[i * 4 + 1] = XorWord(Ws[i * 4], Ws[(i - 1) * 4 + 1]);
            Ws[i * 4 + 2] = XorWord(Ws[i * 4 + 1], Ws[(i - 1) * 4 + 2]);
            Ws[i * 4 + 3] = XorWord(Ws[i * 4 + 2], Ws[(i - 1) * 4 + 3]);

            List<byte[]> tempList = new List<byte[]>();
            for (int j = 0; j < 4; j++)
            {
                tempList.AddRange(Ws[i * 4 + j]);
            }
            Keys[i] = tempList.ToArray();
        }

        return Keys;
    }

    private static byte[][] XorWord(byte[][] word1, byte[][] word2)
    {
        byte[][] result = new byte[word1.Length][];
        for (int i = 0; i < word1.Length; i++)
        {
            result[i] = XOR(word1[i], word2[i]);
        }
        return result;
    }

    private static byte[][] G(byte[][] word, byte round)
    {
        byte[][] result = new byte[word.Length][];
        result[0] = word[0];
        result[1] = word[1];
        result[2] = word[2];
        result[3] = word[3];

        result = CircularLeftShift(result, 1);
        result = SubByte(result);
        result = RCon(result, round);

        return result;
    }

    private static byte[][] CircularLeftShift(byte[][] word, int shift)
    {
        int len = word.Length;
        byte[][] result = new byte[len][];
        for (int i = 0; i < len; i++)
        {
            result[i] = word[(i + shift) % len];
        }
        return result;
    }

    private static byte[][] SubByte(byte[][] word)
    {
        byte[][] result = new byte[word.Length][];
        for (int i = 0; i < word.Length; i++)
        {
            string bin = string.Join("", word[i]);
            int row = BinToDec[bin.Substring(0, 4)];
            int col = BinToDec[bin.Substring(4, 4)];
            result[i] = SBoxBits[row][col];
        }
        return result;
    }

    private static byte[][] RCon(byte[][] word, byte round)
    {
        byte[] firstByte = word[0];
        byte[] rcon = RC[round - 1];
        byte[] XorEd = XOR(firstByte, rcon);
        byte[][] result = new byte[word.Length][];
        result[0] = XorEd;
        result[1] = word[1];
        result[2] = word[2];
        result[3] = word[3];

        return result;
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

    private static byte[][][] Split(byte[][] input, int chunkNo)
    {
        int inputSize = input.Length;

        if (inputSize % chunkNo != 0)
        {
            throw new ArgumentException("Input size must be divisible by chunk number.");
        }

        int chunkSize = inputSize / chunkNo;

        byte[][][] result = new byte[chunkNo][][];

        for (int i = 0; i < chunkNo; i++)
        {
            result[i] = new byte[chunkSize][];
            Array.Copy(input, i * chunkSize, result[i], 0, chunkSize);
        }

        return result;
    }

    public static byte[] HexByteToBin(string input)
    {
        input = input.ToUpperInvariant();
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }

        if (input.Length != 2)
        {
            throw new ArgumentException("Input string length must be 2.");
        }

        List<byte> result = new List<byte>();

        result.AddRange(HexToBin[input[0]]);
        result.AddRange(HexToBin[input[1]]);

        return result.ToArray();
    }

    public static string BinByteToHex(byte[] input)
    {
        if (input.Length != 8)
        {
            throw new ArgumentException("Input length must be 8.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < 8; i += 4)
        {
            string bin = string.Join("", input.Skip(i).Take(4).ToArray());
            result.Append(BinToHex[bin].ToString());
        }
        return result.ToString();
    }

    public static string BinArrToString(byte[][] input)
    {
        if (input.Length != 16)
        {
            throw new ArgumentException("Input length must be 16.");
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            sb.Append(BinByteToHex(input[i]) + " ");
        }
        return sb.ToString().TrimEnd();
    }

    private static string[][] BinMatrixStateToHexState(byte[][][] state)
    {
        string[][] hexState = new string[4][];
        for (int i = 0; i < 4; i++)
        {
            hexState[i] = new string[4];
            for (int j = 0; j < 4; j++)
            {
                hexState[i][j] = BinByteToHex(state[i][j]);
            }
        }
        return hexState;
    }
}
