using Atbmtt.ClassicalEncription;
using Atbmtt.ModernCipher;


/* string MString = "1000000101111001001101000010011100001000000010110100100111001111";
byte[] M = MString.Select(c => byte.Parse(c.ToString())).ToArray();

string KString = "0111011010010011010011111001010111101001110111110010101011001010";
byte[] K = KString.Select(c => byte.Parse(c.ToString())).ToArray();

byte[] res = Des.Encript(M, K);
Des.Display(res, 4);
 */

Console.WriteLine(Aes.Encript("54776F204F6E65204E696E652054776F", "5468617473206D79204B756E67204675"));
Console.WriteLine(Aes.Encript("0123456789abcdeffedcba9876543210", "0f1571c947d9e8590cb7add6af7f6798"));
