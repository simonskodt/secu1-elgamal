using System.Numerics;

/// <summary>
/// Entry point for the public-key ElGamal encryption algorithm.
/// </summary>
ElGamal e;
e = new ElGamal(666, 6661, 2227);

BigInteger message = 2000;

/// <summary>
/// EXERCISE 1
/// Encrypt Bob's initial plaintext message '2000'.
/// </summary>
var encryption = e.Encryption(message);

SetConsoleColorForExercise("1 :: Sending the encypted message '2000' to Bob.");
Console.WriteLine($"\tCYPHERTEXT :: {encryption}");

/// <summary>
/// EXERCISE 2
/// Eve intercepts Alice's encrypted message.
/// Eve has the same information as Alice; allowed to access SharedBase, SharedPrime, and PublicKey.
/// </summary>
BigInteger secretKey = -1; // initial value set to -1

for (BigInteger i = 0; i < 6661; i++)
{
    var temp = BigInteger.ModPow(e.SharedBase, i, e.SharedPrime);
    if (temp == e.PublicKey)
        secretKey = i;
}

var decryption = e.Decryption(secretKey);

SetConsoleColorForExercise("2 :: Eve brute forcing the secret key and decrypting the ciphertext.");
Console.WriteLine($"\tSECRET KEY :: {secretKey}");
Console.WriteLine($"\tPLAINTEXT  :: {decryption}");

/// <summary>
/// EXERCISE 3
/// Modify Alice's encrypted message, so Bob will get 6000.
/// Hence, multiply the numerator (C2) with 3.
/// </summary>
e.C2 = (BigInteger.Multiply(e.C2, 3));
decryption = e.Decryption(secretKey);

SetConsoleColorForExercise("3 :: Modifying Alice's message.");
Console.WriteLine($"\tPLAINTEXT  :: {decryption}\n");

static void SetConsoleColorForExercise(string description)
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.Write(description);
    Console.ResetColor();
    Console.WriteLine();
}