namespace KnowSysTest.PL.WebUI.Helpers.Utilities
{
    using System;
    using System.Security.Cryptography;

    internal class InvalidHashException : Exception
    {
        public InvalidHashException()
        {
        }

        public InvalidHashException(string message)
            : base(message) { }

        public InvalidHashException(string message, Exception inner)
            : base(message, inner) { }
    }

    internal class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException()
        {
        }

        public CannotPerformOperationException(string message)
            : base(message) { }

        public CannotPerformOperationException(string message, Exception inner)
            : base(message, inner) { }
    }

    public class EncryptPassword
    {
        // These constants may be changed without breaking existing hashes.
        private const int SaltBytes = 24;

        private const int HashBytes = 18;
        public const int SALT_BYTES = 24;
        public const int HASH_BYTES = 18;
        public const int Pbkdf2Iterations = 64000;

        // These constants define the encoding and may not be changed.
        public const int HashSections = 5;

        public const int HashAlgorithmIndex = 0;
        public const int IterationIndex = 1;
        public const int HashSizeIndex = 2;
        public const int SaltIndex = 3;
        public const int Pbkdf2Index = 4;

        private static byte[] GenerateRandomSalt()
        {
            var salt = new byte[SaltBytes];
            try
            {
                using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(salt);
                }
            }
            catch (CryptographicException ex)
            {
                throw new CannotPerformOperationException(
                    "Random number generator not available.",
                    ex
                );
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to random number generator.",
                    ex
                );
            }

            return salt;
        }

        private static string GenerateUserSpecificSalt(string username)
        {
            var appSalt = username + "abc";
            return appSalt.GetHashCode().ToString();
        }

        public static string[] CreateHash(string password, string username)
        {
            var saltedPassword = GenerateUserSpecificSalt(username) + password;
            var salt = GenerateRandomSalt();
            var hash = Pbkdf2(saltedPassword, salt, SaltBytes, HashBytes);
            return new[] { Convert.ToBase64String(hash), Convert.ToBase64String(salt) };
        }

        //public static string CreateHash(string password)
        //{
        //    // Generate a random salt
        //    byte[] salt = new byte[SALT_BYTES];
        //    try
        //    {
        //        using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
        //        {
        //            csprng.GetBytes(salt);
        //        }
        //    }
        //    catch (CryptographicException ex)
        //    {
        //        throw new CannotPerformOperationException(
        //            "Random number generator not available.",
        //            ex
        //        );
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        throw new CannotPerformOperationException(
        //            "Invalid argument given to random number generator.",
        //            ex
        //        );
        //    }

        //    byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);

        //    // format: algorithm:iterations:hashSize:salt:hash
        //    String parts = "sha1:" +
        //        PBKDF2_ITERATIONS +
        //        ":" +
        //        hash.Length +
        //        ":" +
        //        Convert.ToBase64String(salt) +
        //        ":" +
        //        Convert.ToBase64String(hash);
        //    return parts;
        //}
        public static bool VerifyPassword(string password, string username, string storedSalt, string storedHash)
        {
            byte[] salt = null;
            try
            {
                salt = Convert.FromBase64String(storedSalt);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Convert.FromBase64String",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Base64 decoding of salt failed.",
                    ex
                );
            }

            byte[] hash = null;
            try
            {
                hash = Convert.FromBase64String(storedHash);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Convert.FromBase64String",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Base64 decoding of pbkdf2 output failed.",
                    ex
                );
            }

            var saltedPassword = GenerateUserSpecificSalt(username) + password;

            byte[] testHash = Pbkdf2(saltedPassword, salt, SaltBytes, hash.Length);
            return SlowEquals(hash, testHash);
        }

        //public static bool VerifyPassword(string password, string goodHash)
        //{
        //    char[] delimiter = { ':' };
        //    string[] split = goodHash.Split(delimiter);

        //    if (split.Length != HASH_SECTIONS)
        //    {
        //        throw new InvalidHashException(
        //            "Fields are missing from the password hash."
        //        );
        //    }

        //    // We only support SHA1 with C#.
        //    if (split[HASH_ALGORITHM_INDEX] != "sha1")
        //    {
        //        throw new CannotPerformOperationException(
        //            "Unsupported hash type."
        //        );
        //    }

        //    int iterations = 0;
        //    try
        //    {
        //        iterations = Int32.Parse(split[ITERATION_INDEX]);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        throw new CannotPerformOperationException(
        //            "Invalid argument given to Int32.Parse",
        //            ex
        //        );
        //    }
        //    catch (FormatException ex)
        //    {
        //        throw new InvalidHashException(
        //            "Could not parse the iteration count as an integer.",
        //            ex
        //        );
        //    }
        //    catch (OverflowException ex)
        //    {
        //        throw new InvalidHashException(
        //            "The iteration count is too large to be represented.",
        //            ex
        //        );
        //    }

        //    if (iterations < 1)
        //    {
        //        throw new InvalidHashException(
        //            "Invalid number of iterations. Must be >= 1."
        //        );
        //    }

        //    byte[] salt = null;
        //    try
        //    {
        //        salt = Convert.FromBase64String(split[SALT_INDEX]);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        throw new CannotPerformOperationException(
        //            "Invalid argument given to Convert.FromBase64String",
        //            ex
        //        );
        //    }
        //    catch (FormatException ex)
        //    {
        //        throw new InvalidHashException(
        //            "Base64 decoding of salt failed.",
        //            ex
        //        );
        //    }

        //    byte[] hash = null;
        //    try
        //    {
        //        hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        throw new CannotPerformOperationException(
        //            "Invalid argument given to Convert.FromBase64String",
        //            ex
        //        );
        //    }
        //    catch (FormatException ex)
        //    {
        //        throw new InvalidHashException(
        //            "Base64 decoding of pbkdf2 output failed.",
        //            ex
        //        );
        //    }

        //    int storedHashSize = 0;
        //    try
        //    {
        //        storedHashSize = Int32.Parse(split[HASH_SIZE_INDEX]);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        throw new CannotPerformOperationException(
        //            "Invalid argument given to Int32.Parse",
        //            ex
        //        );
        //    }
        //    catch (FormatException ex)
        //    {
        //        throw new InvalidHashException(
        //            "Could not parse the hash size as an integer.",
        //            ex
        //        );
        //    }
        //    catch (OverflowException ex)
        //    {
        //        throw new InvalidHashException(
        //            "The hash size is too large to be represented.",
        //            ex
        //        );
        //    }

        //    if (storedHashSize != hash.Length)
        //    {
        //        throw new InvalidHashException(
        //            "Hash length doesn't match stored hash length."
        //        );
        //    }

        //    byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
        //    return SlowEquals(hash, testHash);
        //}

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt))
            {
                pbkdf2.IterationCount = iterations;
                return pbkdf2.GetBytes(outputBytes);
            }
        }
    }
}