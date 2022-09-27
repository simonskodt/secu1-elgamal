# ElGamal public key method

**Mandatory exercise 1 in Security 1. The goal is to implement the ElGamal public key method. The assignment is the following:**

- [x] You are Alice and want to send 2000 kr. to Bob through a confidential message. You decide to use the ElGamal public key method. The keying material you should use to send the message to Bob is as follows:
   * The shared base g=666
   * The shared prime p=6661
   * Bob’s public key PK = gx mod p =2227

   Send the message ’2000’ to Bob.

- [x] You are now Eve and intercept Alice’s encrypted message. Find Bob’s private key and reconstruct Alice’s message.
- [x] You are now Mallory and intercept Alice’s encrypted message. However, you run on a constrained device and are unable to find Bob’s private key. Modify Alice’s encrypted message so that when Bob decrypts it, he will get the message ’6000’.
