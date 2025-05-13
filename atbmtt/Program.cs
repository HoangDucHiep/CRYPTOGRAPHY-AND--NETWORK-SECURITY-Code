using System;
using System.Text;
using Atbmtt.ClassicalEncription;
using Atbmtt.ModernCipher;
using Atbmtt.MyMath;
using Atbmtt.PublicKeyCryptography;
using Atbmtt.DigitalSignature;

namespace Atbmtt
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 5)
            {
                Console.Clear();
                DisplayMenu();
                Console.Write("Enter your choice (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ClassicalCipherSession();
                        break;
                    case 2:
                        ModernCipherSession();
                        break;
                    case 3:
                        PublicKeyCipherSession();
                        break;
                    case 4:
                        ModulusSession();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine(
                            "Invalid choice. Please select a number between 1 and 5."
                        );
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ModulusSession()
        {
            int choice = 0;
            while (choice != 11)
            {
                Console.Clear();
                Console.WriteLine("========================================================");
                Console.WriteLine("Modulus Menu");
                Console.WriteLine("1. Calculate Modular Exponentiation (a^m mod n)");
                Console.WriteLine("2. Find Modular Inverse (a^-1 mod n)");
                Console.WriteLine("3. Calculate Modular Exponentiation using Fermat's Theorem");
                Console.WriteLine("4. Calculate Euler's Totient Function φ(n)");
                Console.WriteLine("5. Calculate Modular Exponentiation using Euler's Theorem");
                Console.WriteLine(
                    "6. Calculate Modular Exponentiation using Chinese Remainder Theorem"
                );
                Console.WriteLine(
                    "7. Solve System of Modular Equations using Chinese Remainder Theorem"
                );
                Console.WriteLine("8. Check if a is a Primitive Root of n");
                Console.WriteLine("9. Calculate Discrete Logarithm (log_a b mod n)");
                Console.WriteLine("10. Calculate Basic Modular Expressions");
                Console.WriteLine("11. Back to Main Menu");
                Console.Write("Enter your choice (1-11): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter base (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long a1))
                                throw new ArgumentException("Invalid input for base.");
                            Console.Write("Enter exponent (m): ");
                            if (!long.TryParse(Console.ReadLine(), out long m1))
                                throw new ArgumentException("Invalid input for exponent.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n1))
                                throw new ArgumentException("Invalid input for modulus.");
                            long result1 = ModulusMath.ModExp(a1, m1, n1);
                            Console.WriteLine($"Result: {a1}^{m1} mod {n1} = {result1}");
                            break;

                        case 2:
                            Console.Write("Enter number (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long a2))
                                throw new ArgumentException("Invalid input for number.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n2))
                                throw new ArgumentException("Invalid input for modulus.");
                            var (gcd, inverse) = ModulusMath.ExtendedEuclidean(a2, n2);
                            if (inverse == null)
                                Console.WriteLine($"No modular inverse exists for {a2} mod {n2}.");
                            else
                                Console.WriteLine(
                                    $"Modular inverse: {a2}^(-1) mod {n2} = {inverse.Value}"
                                );
                            break;

                        case 3:
                            Console.Write("Enter base (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long a3))
                                throw new ArgumentException("Invalid input for base.");
                            Console.Write("Enter exponent (m): ");
                            if (!long.TryParse(Console.ReadLine(), out long m3))
                                throw new ArgumentException("Invalid input for exponent.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n3))
                                throw new ArgumentException("Invalid input for modulus.");
                            long? result3 = ModulusMath.Ferma(a3, m3, n3);
                            if (result3 == null)
                                Console.WriteLine("Fermat's theorem not applicable.");
                            else
                                Console.WriteLine(
                                    $"Result using Fermat: {a3}^{m3} mod {n3} = {result3.Value}"
                                );
                            break;

                        case 4:
                            Console.Write("Enter number (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n4))
                                throw new ArgumentException("Invalid input for number.");
                            long result4 = ModulusMath.EulerTotient(n4);
                            Console.WriteLine($"Euler's Totient φ({n4}) = {result4}");
                            break;

                        case 5:
                            Console.Write("Enter base (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long a5))
                                throw new ArgumentException("Invalid input for base.");
                            Console.Write("Enter exponent (m): ");
                            if (!long.TryParse(Console.ReadLine(), out long m5))
                                throw new ArgumentException("Invalid input for exponent.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n5))
                                throw new ArgumentException("Invalid input for modulus.");
                            long? result5 = ModulusMath.Euler(a5, m5, n5);
                            if (result5 == null)
                                Console.WriteLine("Euler's theorem not applicable.");
                            else
                                Console.WriteLine(
                                    $"Result using Euler: {a5}^{m5} mod {n5} = {result5.Value}"
                                );
                            break;

                        case 6:
                            Console.Write("Enter base (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long a6))
                                throw new ArgumentException("Invalid input for base.");
                            Console.Write("Enter exponent (k): ");
                            if (!long.TryParse(Console.ReadLine(), out long k6))
                                throw new ArgumentException("Invalid input for exponent.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n6))
                                throw new ArgumentException("Invalid input for modulus.");
                            long result6 = ModulusMath.ModExpChineseRemainder(a6, k6, n6);
                            Console.WriteLine($"Result using CRT: {a6}^{k6} mod {n6} = {result6}");
                            break;

                        case 7:
                            Console.Write("Enter m1: ");
                            if (!long.TryParse(Console.ReadLine(), out long m1_7))
                                throw new ArgumentException("Invalid input for m1.");
                            Console.Write("Enter a1: ");
                            if (!long.TryParse(Console.ReadLine(), out long a7_1))
                                throw new ArgumentException("Invalid input for a1.");
                            Console.Write("Enter m2: ");
                            if (!long.TryParse(Console.ReadLine(), out long m2_7))
                                throw new ArgumentException("Invalid input for m2.");
                            Console.Write("Enter a2: ");
                            if (!long.TryParse(Console.ReadLine(), out long a7_2))
                                throw new ArgumentException("Invalid input for a2.");
                            Console.Write("Enter m3: ");
                            if (!long.TryParse(Console.ReadLine(), out long m3_7))
                                throw new ArgumentException("Invalid input for m3.");
                            Console.Write("Enter a3: ");
                            if (!long.TryParse(Console.ReadLine(), out long a7_3))
                                throw new ArgumentException("Invalid input for a3.");
                            long[] ms = { m1_7, m2_7, m3_7 };
                            long[] asValues = { a7_1, a7_2, a7_3 };
                            long result7 = ModulusMath.ChineseRemainderTheorem(ms, asValues);
                            Console.WriteLine($"Solution x = {result7}");
                            break;

                        case 8:
                            Console.Write("Enter number (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long a8))
                                throw new ArgumentException("Invalid input for number.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n8))
                                throw new ArgumentException("Invalid input for modulus.");
                            bool isPrimitive = ModulusMath.IsPrimitiveRoot(a8, n8);
                            Console.WriteLine(
                                $"{a8} {(isPrimitive ? "is" : "is not")} a primitive root of {n8}."
                            );
                            break;

                        case 9:
                            Console.Write("Enter base (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long a9))
                                throw new ArgumentException("Invalid input for base.");
                            Console.Write("Enter element (b): ");
                            if (!long.TryParse(Console.ReadLine(), out long b9))
                                throw new ArgumentException("Invalid input for element.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n9))
                                throw new ArgumentException("Invalid input for modulus.");
                            long result9 = ModulusMath.DiscreteLogarithm(a9, b9, n9);
                            Console.WriteLine(
                                $"Discrete logarithm: log_{a9} {b9} mod {n9} = {result9}"
                            );
                            break;

                        case 10:
                            Console.Write("Enter a: ");
                            if (!long.TryParse(Console.ReadLine(), out long a10))
                                throw new ArgumentException("Invalid input for a.");
                            Console.Write("Enter b: ");
                            if (!long.TryParse(Console.ReadLine(), out long b10))
                                throw new ArgumentException("Invalid input for b.");
                            Console.Write("Enter x: ");
                            if (!long.TryParse(Console.ReadLine(), out long x10))
                                throw new ArgumentException("Invalid input for x.");
                            Console.Write("Enter y: ");
                            if (!long.TryParse(Console.ReadLine(), out long y10))
                                throw new ArgumentException("Invalid input for y.");
                            Console.Write("Enter modulus (n): ");
                            if (!long.TryParse(Console.ReadLine(), out long n10))
                                throw new ArgumentException("Invalid input for modulus.");
                            Console.WriteLine(
                                $"A1 = (a^x + b^y) mod n = {ModulusMath.A1(a10, b10, x10, y10, n10)}"
                            );
                            Console.WriteLine(
                                $"A2 = (a^x - b^y) mod n = {ModulusMath.A2(a10, b10, x10, y10, n10)}"
                            );
                            Console.WriteLine(
                                $"A3 = (a^x * b^y) mod n = {ModulusMath.A3(a10, b10, x10, y10, n10)}"
                            );
                            Console.WriteLine(
                                $"A4 = (b^y)^(-1) mod n = {ModulusMath.A4(b10, y10, n10)}"
                            );
                            Console.WriteLine(
                                $"A5 = (a^x / b^y) mod n = {ModulusMath.A5(a10, b10, x10, y10, n10)}"
                            );
                            break;

                        case 11:
                            Console.WriteLine("Returning to Main Menu...");
                            return;

                        default:
                            Console.WriteLine(
                                "Invalid choice. Please select a number between 1 and 11."
                            );
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ClassicalCipherSession()
        {
            int choice = 0;
            while (choice != 7)
            {
                Console.Clear();
                Console.WriteLine("========================================================");
                Console.WriteLine("Classical Cipher Menu");
                Console.WriteLine("1. Caesar Cipher");
                Console.WriteLine("2. Vigenere Cipher");
                Console.WriteLine("3. MonoAlphabetic Cipher");
                Console.WriteLine("4. Playfair Cipher");
                Console.WriteLine("5. Columnar Transposition");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice (1-7): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        EncriptOrDecrypt("Caesar Cipher");
                        break;
                    case 2:
                        EncriptOrDecrypt("Vigenere Cipher");
                        break;
                    case 3:
                        EncriptOrDecrypt("MonoAlphabetic Cipher");
                        break;
                    case 4:
                        EncriptOrDecrypt("Playfair Cipher");
                        break;
                    case 5:
                        EncriptOrDecrypt("Columnar Transposition");
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        return;
                    default:
                        Console.WriteLine(
                            "Invalid choice. Please select a number between 1 and 7."
                        );
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ModernCipherSession()
        {
            int choice = 0;
            while (choice != 3)
            {
                Console.Clear();
                Console.WriteLine("========================================================");
                Console.WriteLine("Modern Cipher Menu");
                Console.WriteLine("1. DES");
                Console.WriteLine("2. AES");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice (1-3): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        EncriptOrDecrypt("DES");
                        break;
                    case 2:
                        EncriptOrDecrypt("AES");
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu...");
                        return;
                    default:
                        Console.WriteLine(
                            "Invalid choice. Please select a number between 1 and 3."
                        );
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void PublicKeyCipherSession()
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.Clear();
                Console.WriteLine("========================================================");
                Console.WriteLine("Public Key Cipher Menu");
                Console.WriteLine("1. Diffie-Hellman Key Exchange");
                Console.WriteLine("2. RSA - Digital Signature");
                Console.WriteLine("3. RSA - Encrypt");
                Console.WriteLine("4. ElGamal");
                Console.WriteLine("5. DSA");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice (1-6): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1: // Diffie-Hellman
                            Console.Write("Enter prime number (q): ");
                            if (!long.TryParse(Console.ReadLine(), out long qDH))
                                throw new ArgumentException("Invalid input for q.");
                            Console.Write("Enter primitive root (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long aDH))
                                throw new ArgumentException("Invalid input for a.");
                            Console.Write("Enter Alice's private key (xA): ");
                            if (!long.TryParse(Console.ReadLine(), out long xA))
                                throw new ArgumentException("Invalid input for xA.");
                            Console.Write("Enter Bob's private key (xB): ");
                            if (!long.TryParse(Console.ReadLine(), out long xB))
                                throw new ArgumentException("Invalid input for xB.");

                            long yA = DiffieHellman.GetPublicKey(xA, qDH, aDH);
                            long yB = DiffieHellman.GetPublicKey(xB, qDH, aDH);
                            long kA = DiffieHellman.GetSharedKey(xA, yB, qDH);
                            long kB = DiffieHellman.GetSharedKey(xB, yA, qDH);

                            if (kA != kB)
                                throw new ArgumentException("Shared keys do not match.");

                            Console.WriteLine($"Alice's public key (yA): {yA}");
                            Console.WriteLine($"Bob's public key (yB): {yB}");
                            Console.WriteLine($"Shared key (K): {kA}");
                            break;

                        case 2:
                            Console.Write("Enter first prime number (p): ");
                            if (!long.TryParse(Console.ReadLine(), out long pRSA))
                                throw new ArgumentException("Invalid input for p.");
                            Console.Write("Enter second prime number (q): ");
                            if (!long.TryParse(Console.ReadLine(), out long qRSA))
                                throw new ArgumentException("Invalid input for q.");
                            Console.Write("Enter public exponent (e): ");
                            if (!long.TryParse(Console.ReadLine(), out long eRSA))
                                throw new ArgumentException("Invalid input for e.");
                            Console.Write("Enter plaintext (M): ");
                            if (!long.TryParse(Console.ReadLine(), out long M_RSA))
                                throw new ArgumentException("Invalid input for M.");

                            var publicKeyRSA = RSA.GetPublicKey(pRSA, qRSA, eRSA);
                            var privateKeyRSA = RSA.GetPrivateKey(pRSA, qRSA, eRSA);
                            long C_RSA = RSA.Encript(M_RSA, privateKeyRSA);
                            long M_prime = RSA.Decrypt(C_RSA, publicKeyRSA);

                            Console.WriteLine($"Public key (PU): {{e={publicKeyRSA.e}, n={publicKeyRSA.n}}}");
                            Console.WriteLine($"Private key (PR): {{d={privateKeyRSA.d}, n={privateKeyRSA.n}}}");
                            Console.WriteLine($"Ciphertext - Sign (C): {C_RSA}");
                            Console.WriteLine($"Decrypted plaintext (M'): {M_prime}");
                            break;

                        case 3:
                            Console.Write("Enter first prime number (p): ");
                            if (!long.TryParse(Console.ReadLine(), out pRSA))
                                throw new ArgumentException("Invalid input for p.");
                            Console.Write("Enter second prime number (q): ");
                            if (!long.TryParse(Console.ReadLine(), out qRSA))
                                throw new ArgumentException("Invalid input for q.");
                            Console.Write("Enter public exponent (e): ");
                            if (!long.TryParse(Console.ReadLine(), out eRSA))
                                throw new ArgumentException("Invalid input for e.");
                            Console.Write("Enter plaintext (M): ");
                            if (!long.TryParse(Console.ReadLine(), out M_RSA))
                                throw new ArgumentException("Invalid input for M.");

                            publicKeyRSA = RSA.GetPublicKey(pRSA, qRSA, eRSA);
                            privateKeyRSA = RSA.GetPrivateKey(pRSA, qRSA, eRSA);
                            C_RSA = RSA.Encript(M_RSA, publicKeyRSA);
                            M_prime = RSA.Decrypt(C_RSA, privateKeyRSA);

                            Console.WriteLine($"Public key (PU): {{e={publicKeyRSA.e}, n={publicKeyRSA.n}}}");
                            Console.WriteLine($"Private key (PR): {{d={privateKeyRSA.d}, n={privateKeyRSA.n}}}");
                            Console.WriteLine($"Ciphertext - Cipher (C): {C_RSA}");
                            Console.WriteLine($"Decrypted plaintext (M'): {M_prime}");
                            break;

                        case 4: // ElGamal
                            Console.Write("Enter prime number (q): ");
                            if (!long.TryParse(Console.ReadLine(), out long qEG))
                                throw new ArgumentException("Invalid input for q.");
                            Console.Write("Enter primitive root (a): ");
                            if (!long.TryParse(Console.ReadLine(), out long aEG))
                                throw new ArgumentException("Invalid input for a.");
                            Console.Write("Enter private key (xA): ");
                            if (!long.TryParse(Console.ReadLine(), out long xA_EG))
                                throw new ArgumentException("Invalid input for xA.");
                            Console.Write("Enter random number (k): ");
                            if (!long.TryParse(Console.ReadLine(), out long kEG))
                                throw new ArgumentException("Invalid input for k.");
                            Console.Write("Enter plaintext (M): ");
                            if (!long.TryParse(Console.ReadLine(), out long M_EG))
                                throw new ArgumentException("Invalid input for M.");

                            var publicKeyEG = ElGamal.GetPublicKey(qEG, aEG, xA_EG);
                            var ciphertextEG = ElGamal.Encript(M_EG, kEG, publicKeyEG);
                            long decryptedM_EG = ElGamal.Decrypt(ciphertextEG, qEG, xA_EG);

                            Console.WriteLine($"Public key (PU): {{q={publicKeyEG.q}, a={publicKeyEG.a}, YA={publicKeyEG.Y}}}");
                            Console.WriteLine($"Ciphertext: (C1={ciphertextEG.C1}, C2={ciphertextEG.C2})");
                            Console.WriteLine($"Decrypted plaintext (M): {decryptedM_EG}");
                            break;

                        case 5: // DSA
                            Console.Write("Enter hash of message (H(M)): ");
                            if (!long.TryParse(Console.ReadLine(), out long H_DSA))
                                throw new ArgumentException("Invalid input for H(M).");
                            Console.Write("Enter large prime (p): ");
                            if (!long.TryParse(Console.ReadLine(), out long pDSA))
                                throw new ArgumentException("Invalid input for p.");
                            Console.Write("Enter small prime (q): ");
                            if (!long.TryParse(Console.ReadLine(), out long qDSA))
                                throw new ArgumentException("Invalid input for q.");
                            Console.Write("Enter number (h): ");
                            if (!long.TryParse(Console.ReadLine(), out long hDSA))
                                throw new ArgumentException("Invalid input for h.");
                            Console.Write("Enter private key (xA): ");
                            if (!long.TryParse(Console.ReadLine(), out long xA_DSA))
                                throw new ArgumentException("Invalid input for xA.");
                            Console.Write("Enter random number (k): ");
                            if (!long.TryParse(Console.ReadLine(), out long kDSA))
                                throw new ArgumentException("Invalid input for k.");

                            var (gDSA, yDSA) = DSA.GetPublicKey(pDSA, qDSA, hDSA, xA_DSA);
                            var signatureDSA = DSA.Sign(pDSA, qDSA, xA_DSA, gDSA, kDSA, H_DSA);
                            bool isValidDSA = DSA.Verify(pDSA, qDSA, gDSA, yDSA, H_DSA, signatureDSA);

                            Console.WriteLine($"Public key (yA): {yDSA}");
                            Console.WriteLine($"Signature: {{r={signatureDSA.r}, s={signatureDSA.s}}}");
                            Console.WriteLine($"Signature verification: {(isValidDSA ? "Valid" : "Invalid")}");
                            break;

                        case 6:
                            Console.WriteLine("Returning to Main Menu...");
                            return;

                        default:
                            Console.WriteLine(
                                "Invalid choice. Please select a number between 1 and 5."
                            );
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void EncriptOrDecrypt(string algo)
        {
            int choice = 0;
            while (choice != 3)
            {
                Console.Clear();
                Console.WriteLine("========================================================");
                Console.WriteLine($"You have selected {algo}.");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Encrypt");
                Console.WriteLine("2. Decrypt");
                Console.WriteLine("3. Back to Previous Menu");
                Console.Write("Enter your choice (1-3): ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (algo == "Caesar Cipher")
                            {
                                Console.Write("Enter the plaintext: ");
                                string plainText = Console.ReadLine();

                                Console.Write("Enter the key (0-255): ");
                                if (!byte.TryParse(Console.ReadLine(), out byte key))
                                {
                                    Console.WriteLine(
                                        "Invalid key. Please enter a number between 0 and 255."
                                    );
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                Console.WriteLine(
                                    "Custom Alphabet (optional, default is English alphabet: ABCDEFGHIJKLMNOPQRSTUVWXYZ): "
                                );
                                string customAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(customAlphabet))
                                {
                                    customAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                var caesarCipher = new ExtendedCaesarCipher(customAlphabet);
                                string encryptedText = caesarCipher.Encode(key, plainText);
                                Console.WriteLine($"Encrypted Text: {encryptedText}");
                            }
                            else if (algo == "Vigenere Cipher")
                            {
                                Console.Write("Enter the plaintext: ");
                                string plainText = Console.ReadLine();

                                Console.Write("Enter the key: ");
                                string key = Console.ReadLine();

                                Console.WriteLine(
                                    "Custom Alphabet (optional, default is English alphabet: ABCDEFGHIJKLMNOPQRSTUVWXYZ): "
                                );
                                string customAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(customAlphabet))
                                {
                                    customAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                Console.WriteLine(
                                    "Auto Key (y/n - optional, default is Repeat Key): "
                                );
                                string autoKey = Console.ReadLine();
                                bool isAutoKey = autoKey?.ToLower() == "y";

                                var vigenereCipher = new ExtendedVinegereCipher(
                                    key,
                                    customAlphabet
                                );
                                string encryptedText = vigenereCipher.Encode(
                                    plainText,
                                    isAutoKey ? VigenereMode.AUTOKEY : VigenereMode.REPEAT_KEY
                                );
                                Console.WriteLine($"Encrypted Text: {encryptedText}");
                            }
                            else if (algo == "MonoAlphabetic Cipher")
                            {
                                Console.Write("Enter the plaintext: ");
                                string plainText = Console.ReadLine();

                                Console.WriteLine(
                                    "Custom Alphabet (optional, default is English alphabet: ABCDEFGHIJKLMNOPQRSTUVWXYZ): "
                                );
                                string customAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(customAlphabet))
                                {
                                    customAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                Console.Write(
                                    "Enter the cipher alphabet (must be a permutation of the custom alphabet): "
                                );
                                string cipherAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(cipherAlphabet))
                                {
                                    cipherAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                var monoAlphabetic = new MonoAlphabetic(
                                    customAlphabet,
                                    cipherAlphabet
                                );
                                string encryptedText = monoAlphabetic.Encrypt(plainText);
                                Console.WriteLine($"Encrypted Text: {encryptedText}");
                            }
                            else if (algo == "Playfair Cipher")
                            {
                                Console.Write("Enter the plaintext: ");
                                string plainText = Console.ReadLine();

                                Console.Write("Enter the key: ");
                                string key = Console.ReadLine();

                                var playfairCipher = new Playfair(key);
                                string encryptedText = playfairCipher.Encrypt(plainText);
                                Console.WriteLine($"Encrypted Text: {encryptedText}");
                            }
                            else if (algo == "Columnar Transposition")
                            {
                                Console.Write("Enter the plaintext: ");
                                string plainText = Console.ReadLine();

                                Console.Write("Enter the key (numeric, e.g., 231): ");
                                string key = Console.ReadLine();

                                string encryptedText = ColumnarTransposition.Encrypt(
                                    plainText,
                                    key
                                );
                                Console.WriteLine($"Encrypted Text: {encryptedText}");
                            }
                            else if (algo == "DES")
                            {
                                Console.Write("Enter the plaintext (16-character hexadecimal): ");
                                string plainText = Console.ReadLine();

                                Console.Write("Enter the key (16-character hexadecimal): ");
                                string key = Console.ReadLine();

                                string encryptedText = Des.Encrypt(plainText, key);
                                Console.WriteLine($"Encrypted Text: {encryptedText}");
                            }
                            else if (algo == "AES")
                            {
                                Console.Write("Enter the plaintext (32-character hexadecimal): ");
                                string plainText = Console.ReadLine();

                                Console.Write("Enter the key (32-character hexadecimal): ");
                                string key = Console.ReadLine();

                                // Validate input lengths
                                if (plainText.Replace(" ", "").Length != 32)
                                    throw new ArgumentException(
                                        "Plaintext must be 32 hexadecimal characters."
                                    );
                                if (key.Replace(" ", "").Length != 32)
                                    throw new ArgumentException(
                                        "Key must be 32 hexadecimal characters."
                                    );

                                string encryptedText = AES.Encrypt(key, plainText);
                                Console.WriteLine($"Encrypted Text: {encryptedText}");
                            }

                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        case 2:
                            if (algo == "Caesar Cipher")
                            {
                                Console.Write("Enter the ciphertext: ");
                                string cipherText = Console.ReadLine();

                                Console.Write("Enter the key (0-255): ");
                                if (!byte.TryParse(Console.ReadLine(), out byte key))
                                {
                                    Console.WriteLine(
                                        "Invalid key. Please enter a number between 0 and 255."
                                    );
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                Console.WriteLine(
                                    "Custom Alphabet (optional, default is English alphabet: ABCDEFGHIJKLMNOPQRSTUVWXYZ): "
                                );
                                string customAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(customAlphabet))
                                {
                                    customAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                var caesarCipher = new ExtendedCaesarCipher(customAlphabet);
                                string decryptedText = caesarCipher.Decode(key, cipherText);
                                Console.WriteLine($"Decrypted Text: {decryptedText}");
                            }
                            else if (algo == "Vigenere Cipher")
                            {
                                Console.Write("Enter the ciphertext: ");
                                string cipherText = Console.ReadLine();

                                Console.Write("Enter the key: ");
                                string key = Console.ReadLine();

                                Console.WriteLine(
                                    "Custom Alphabet (optional, default is English alphabet: ABCDEFGHIJKLMNOPQRSTUVWXYZ): "
                                );
                                string customAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(customAlphabet))
                                {
                                    customAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                Console.WriteLine(
                                    "Auto Key (y/n - optional, default is Repeat Key): "
                                );
                                string autoKey = Console.ReadLine();
                                bool isAutoKey = autoKey?.ToLower() == "y";

                                var vigenereCipher = new ExtendedVinegereCipher(
                                    key,
                                    customAlphabet
                                );
                                string decryptedText = vigenereCipher.Decode(
                                    cipherText,
                                    isAutoKey ? VigenereMode.AUTOKEY : VigenereMode.REPEAT_KEY
                                );
                                Console.WriteLine($"Decrypted Text: {decryptedText}");
                            }
                            else if (algo == "MonoAlphabetic Cipher")
                            {
                                Console.Write("Enter the ciphertext: ");
                                string cipherText = Console.ReadLine();

                                Console.WriteLine(
                                    "Custom Alphabet (optional, default is English alphabet: ABCDEFGHIJKLMNOPQRSTUVWXYZ): "
                                );
                                string customAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(customAlphabet))
                                {
                                    customAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                Console.Write(
                                    "Enter the cipher alphabet (must be a permutation of the custom alphabet): "
                                );
                                string cipherAlphabet = Console.ReadLine();
                                if (string.IsNullOrEmpty(cipherAlphabet))
                                {
                                    cipherAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                }

                                var monoAlphabetic = new MonoAlphabetic(
                                    customAlphabet,
                                    cipherAlphabet
                                );
                                string decryptedText = monoAlphabetic.Decrypt(cipherText);
                                Console.WriteLine($"Decrypted Text: {decryptedText}");
                            }
                            else if (algo == "Playfair Cipher")
                            {
                                Console.Write("Enter the ciphertext: ");
                                string cipherText = Console.ReadLine();

                                Console.Write("Enter the key: ");
                                string key = Console.ReadLine();

                                var playfairCipher = new Playfair(key);
                                string decryptedText = playfairCipher.Decrypt(cipherText);
                                Console.WriteLine($"Decrypted Text: {decryptedText}");
                            }
                            else if (algo == "Columnar Transposition")
                            {
                                Console.Write("Enter the ciphertext: ");
                                string cipherText = Console.ReadLine();

                                Console.Write("Enter the key (numeric, e.g., 231): ");
                                string key = Console.ReadLine();

                                string decryptedText = ColumnarTransposition.Decrypt(
                                    cipherText,
                                    key
                                );
                                Console.WriteLine($"Decrypted Text: {decryptedText}");
                            }
                            else if (algo == "DES")
                            {
                                Console.Write("Enter the ciphertext (16-character hexadecimal): ");
                                string cipherText = Console.ReadLine();

                                Console.Write("Enter the key (16-character hexadecimal): ");
                                string key = Console.ReadLine();

                                string decryptedText = Des.Decrypt(cipherText, key);
                                Console.WriteLine($"Decrypted Text: {decryptedText}");
                            }
                            else if (algo == "AES")
                            {
                                Console.Write("Enter the ciphertext (32-character hexadecimal): ");
                                string cipherText = Console.ReadLine();

                                Console.Write("Enter the key (32-character hexadecimal): ");
                                string key = Console.ReadLine();

                                // Validate input lengths
                                if (cipherText.Replace(" ", "").Length != 32)
                                    throw new ArgumentException(
                                        "Ciphertext must be 32 hexadecimal characters."
                                    );
                                if (key.Replace(" ", "").Length != 32)
                                    throw new ArgumentException(
                                        "Key must be 32 hexadecimal characters."
                                    );

                                string decryptedText = AES.Decrypt(key, cipherText);
                                Console.WriteLine($"Decrypted Text: {decryptedText}");
                            }

                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        case 3:
                            return;

                        default:
                            Console.WriteLine(
                                "Invalid choice. Please select a number between 1 and 3."
                            );
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Classical Cipher");
            Console.WriteLine("2. Modern Cipher");
            Console.WriteLine("3. Public Key Cipher");
            Console.WriteLine("4. Modulus");
            Console.WriteLine("5. Exit");
        }
    }
}