/// <summary>
/// This class contains the shared base and prime as well as the public key.
/// Also, the API of the encryption and decryption is placed in this class.
/// </summary>  
public class ElGamal
{
    private Random _random;
    public int Generator { get; }
    public int SharedPrime { get; }
    public int PublicKey { get; private set; }
    private int _c1;
    private int _c2;

    public ElGamal(int geneator = 666, int sharedPrime = 6661, int publicKey = 227)
    {
        _random = new Random();
        this.Generator = geneator;
        this.SharedPrime = sharedPrime;
        this.PublicKey = publicKey;
    }

    /// <summary>
    /// Generating a public key.
    /// </summary>
    public void generatePK()
    {
        this.PublicKey = (int) _c1 % Generator;
    }

    /// <summary>
    /// First chossing a random r.
    /// Then compute c1 and c2 and output the respective values as a tuple.
    /// </summary>
    public (int, int) Encryption(int msg)
    {
        int r = _random.Next();
        _c1 = (int) Math.Pow(Generator, r);
        _c2 = (int) msg * (int) Math.Pow(PublicKey, r);
        return (_c1, _c2);
    }

    public int Decryption()
    {
        return 0;
    }
}

