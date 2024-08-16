# Password Hashing with Salting

* SaltSize = 16
* HashSize = 32
* Iterations = 100000
* HashAlgorithm = SHA512

<pre>
  hashBytes = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithmName, hashSize);
  
  hashString = Convert.ToHexString(hash);
</pre>
