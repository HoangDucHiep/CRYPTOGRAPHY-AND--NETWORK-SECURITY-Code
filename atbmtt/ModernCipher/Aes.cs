using System.Text;

namespace Atbmtt.ModernCipher;

using System;
using System.Linq;

public class AES
{
    private static readonly byte[] Sbox = new byte[256] {
        0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
        0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
        0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
        0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
        0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
        0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
        0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
        0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
        0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
        0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
        0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
        0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
        0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
        0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
        0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
        0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
    };

    private static readonly byte[] invSbox = new byte[256];

    private static readonly byte[] Rcon = {0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36};

    static AES()
    {
        for (int i = 0; i < 256; i++)
            invSbox[Sbox[i]] = (byte)i;
    }

    private static byte[] KeyExpansion(byte[] key)
    {
        int Nk = 4; // AES-128
        int Nr = 10;
        int keyScheduleSize = 16 * (Nr + 1);
        byte[] keySchedule = new byte[keyScheduleSize];
        Array.Copy(key, 0, keySchedule, 0, 16);
        for (int i = 4; i < 44; i++)
        {
            byte[] temp = new byte[4];
            Array.Copy(keySchedule, (i - 1) * 4, temp, 0, 4);
            if (i % 4 == 0)
            {
                byte t = temp[0];
                temp[0] = temp[1];
                temp[1] = temp[2];
                temp[2] = temp[3];
                temp[3] = t;
                for (int k = 0; k < 4; k++)
                    temp[k] = Sbox[temp[k]];
                int j = i / 4;
                temp[0] ^= Rcon[j - 1];
            }
            for (int k = 0; k < 4; k++)
                keySchedule[i * 4 + k] = (byte)(keySchedule[(i - 4) * 4 + k] ^ temp[k]);
        }
        return keySchedule;
    }

    private static void AddRoundKey(byte[] state, byte[] keySchedule, int round)
    {
        int offset = round * 16;
        for (int i = 0; i < 16; i++)
            state[i] ^= keySchedule[offset + i];
    }

    private static void SubBytes(byte[] state)
    {
        for (int i = 0; i < 16; i++)
            state[i] = Sbox[state[i]];
    }

    private static void InvSubBytes(byte[] state)
    {
        for (int i = 0; i < 16; i++)
            state[i] = invSbox[state[i]];
    }

    private static void ShiftRows(byte[] state)
    {
        byte[] temp = new byte[16];
        temp[0] = state[0];
        temp[1] = state[5];
        temp[2] = state[10];
        temp[3] = state[15];
        temp[4] = state[4];
        temp[5] = state[9];
        temp[6] = state[14];
        temp[7] = state[3];
        temp[8] = state[8];
        temp[9] = state[13];
        temp[10] = state[2];
        temp[11] = state[7];
        temp[12] = state[12];
        temp[13] = state[1];
        temp[14] = state[6];
        temp[15] = state[11];
        Array.Copy(temp, state, 16);
    }

    private static void InvShiftRows(byte[] state)
    {
        byte[] temp = new byte[16];
        temp[0] = state[0];
        temp[1] = state[13];
        temp[2] = state[10];
        temp[3] = state[7];
        temp[4] = state[4];
        temp[5] = state[1];
        temp[6] = state[14];
        temp[7] = state[11];
        temp[8] = state[8];
        temp[9] = state[5];
        temp[10] = state[2];
        temp[11] = state[15];
        temp[12] = state[12];
        temp[13] = state[9];
        temp[14] = state[6];
        temp[15] = state[3];
        Array.Copy(temp, state, 16);
    }

    private static byte Mul2(byte a)
    {
        return (byte)((a << 1) ^ ((a & 0x80) != 0 ? 0x1b : 0));
    }

    private static byte Mul3(byte a)
    {
        return (byte)(Mul2(a) ^ a);
    }

    private static void MixColumns(byte[] state)
    {
        for (int c = 0; c < 4; c++)
        {
            int offset = c * 4;
            byte s0 = state[offset];
            byte s1 = state[offset + 1];
            byte s2 = state[offset + 2];
            byte s3 = state[offset + 3];
            state[offset] = (byte)(Mul2(s0) ^ Mul3(s1) ^ s2 ^ s3);
            state[offset + 1] = (byte)(s0 ^ Mul2(s1) ^ Mul3(s2) ^ s3);
            state[offset + 2] = (byte)(s0 ^ s1 ^ Mul2(s2) ^ Mul3(s3));
            state[offset + 3] = (byte)(Mul3(s0) ^ s1 ^ s2 ^ Mul2(s3));
        }
    }

    private static byte GfMul(byte a, byte b)
    {
        byte p = 0;
        for (int i = 0; i < 8; i++)
        {
            if ((b & 1) != 0)
                p ^= a;
            bool hi_bit_set = (a & 0x80) != 0;
            a <<= 1;
            if (hi_bit_set)
                a ^= 0x1b;
            b >>= 1;
        }
        return p;
    }

    private static void InvMixColumns(byte[] state)
    {
        for (int c = 0; c < 4; c++)
        {
            int offset = c * 4;
            byte s0 = state[offset];
            byte s1 = state[offset + 1];
            byte s2 = state[offset + 2];
            byte s3 = state[offset + 3];
            state[offset] = (byte)(GfMul(0x0e, s0) ^ GfMul(0x0b, s1) ^ GfMul(0x0d, s2) ^ GfMul(0x09, s3));
            state[offset + 1] = (byte)(GfMul(0x09, s0) ^ GfMul(0x0e, s1) ^ GfMul(0x0b, s2) ^ GfMul(0x0d, s3));
            state[offset + 2] = (byte)(GfMul(0x0d, s0) ^ GfMul(0x09, s1) ^ GfMul(0x0e, s2) ^ GfMul(0x0b, s3));
            state[offset + 3] = (byte)(GfMul(0x0b, s0) ^ GfMul(0x0d, s1) ^ GfMul(0x09, s2) ^ GfMul(0x0e, s3));
        }
    }

    private static byte[] Encrypt(byte[] plaintext, byte[] keySchedule)
    {
        byte[] state = (byte[])plaintext.Clone();
        AddRoundKey(state, keySchedule, 0);
        for (int round = 1; round < 10; round++)
        {
            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            AddRoundKey(state, keySchedule, round);
        }
        SubBytes(state);
        ShiftRows(state);
        AddRoundKey(state, keySchedule, 10);
        return state;
    }

    private static byte[] Decrypt(byte[] ciphertext, byte[] keySchedule)
    {
        byte[] state = (byte[])ciphertext.Clone();
        AddRoundKey(state, keySchedule, 10);
        for (int round = 9; round >= 1; round--)
        {
            InvShiftRows(state);
            InvSubBytes(state);
            AddRoundKey(state, keySchedule, round);
            InvMixColumns(state);
        }
        InvShiftRows(state);
        InvSubBytes(state);
        AddRoundKey(state, keySchedule, 0);
        return state;
    }

    public static string Encrypt(string keyHex, string plaintextHex)
    {
        byte[] key = HexToBytes(keyHex);
        byte[] plaintext = HexToBytes(plaintextHex);
        byte[] keySchedule = KeyExpansion(key);
        byte[] ciphertext = Encrypt(plaintext, keySchedule);
        return BytesToHex(ciphertext);
    }

    public static string Decrypt(string keyHex, string ciphertextHex)
    {
        byte[] key = HexToBytes(keyHex);
        byte[] ciphertext = HexToBytes(ciphertextHex);
        byte[] keySchedule = KeyExpansion(key);
        byte[] plaintext = Decrypt(ciphertext, keySchedule);
        return BytesToHex(plaintext);
    }

    private static byte[] HexToBytes(string hex)
    {
        hex = hex.Replace(" ", "");
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        return bytes;
    }

    private static string BytesToHex(byte[] bytes)
    {
        return string.Join(" ", bytes.Select(b => b.ToString("X2")));
    }
}