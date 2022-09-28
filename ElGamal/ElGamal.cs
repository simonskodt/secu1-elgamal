using System.Numerics;

/// <summary>
/// This class contains the shared base and prime as well as the public key.
/// Also, the API of the encryption and decryption is placed in this class.
/// </summary>
public class ElGamal
{
    private Random _random;
    public BigInteger SharedBase { get; }
    public BigInteger SharedPrime { get; }
    public BigInteger PublicKey { get; private set; }
    public BigInteger C1 { get; set; }
    public BigInteger C2 { get; set; }

    public ElGamal(BigInteger generator, BigInteger sharedPrime, BigInteger publicKey)
    {
        _random          = new Random();
        this.SharedBase  = generator;
        this.SharedPrime = sharedPrime;
        this.PublicKey   = publicKey;
    }

    /// <summary>
    /// Initially, choosing a random r.
    /// Then compute C1 and C2, and output the respective values as a BigInteger tuple.
    /// </summary>
    public (BigInteger, BigInteger) Encryption(BigInteger plainText)
    {
        BigInteger randomVal = _random.Next(0, 6661);
        (C1, C2) = CalculateC(randomVal, plainText);
        return (C1, C2);
    }

    /// <summary>
    /// Set the numerator and denominator, and return the BigInteger fraction.
    /// </summary>
    public BigInteger Decryption(BigInteger secretKey)
    {
        BigInteger m = (C2 * ((BigInteger.ModPow(C1, (SharedPrime - 1 - secretKey) , SharedPrime)))) % SharedPrime;
        return m;
    }
    
    /// <summary>
    /// Calculate C1 and C2, and return as a BigInteger tuple.
    /// </summary>
    private (BigInteger, BigInteger) CalculateC(BigInteger randomVal, BigInteger plainText) 
    {
        BigInteger c1 = BigInteger.ModPow(SharedBase, randomVal, SharedPrime);
        BigInteger c2 = (plainText * BigInteger.Pow(PublicKey, (int) randomVal)) % SharedPrime;
        return (c1, c2);
    }
}

