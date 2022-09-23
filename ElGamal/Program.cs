/// <summary>
/// Entry point for the ElGamal encryption algorithm. Alice wants to send
/// 2000 to Bob thourgh a confidential message. 
/// </summary>

ElGamal elGamal;
elGamal = new ElGamal();

int message = 2000;

// Encrypting Bob's message '2000'.
var encryption = elGamal.Encryption(message);

Console.WriteLine(encryption);

// Decrypting Bob's message.
var decryption = elGamal.Decryption();

Console.WriteLine(decryption);