using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HashingAlgorithms
{
    public static class Hasher
    {
        private static string GenerateHashString(HashAlgorithm algorithm, string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            algorithm.ComputeHash(bytes);

            var hash = algorithm.Hash;

            var result = string.Join(string.Empty, hash.Select(x => x.ToString("x2")));
            return result;
        }

        public static string MD5(string text)
        {
            var result = default(string);

            using (var algorithm = new MD5CryptoServiceProvider())
            {
                result = GenerateHashString(algorithm, text);
            }

            return result;
        }

        public static string SHA1(string text)
        {
            var result = default(string);

            using (var algorithm = new SHA1Managed())
            {
                result = GenerateHashString(algorithm, text);
            }

            return result;
        }

        public static string SHA256(string text)
        {
            var result = default(string);

            using (var algorithm = new SHA256Managed())
            {
                result = GenerateHashString(algorithm, text);
            }

            return result;
        }

        public static string SHA512(string text)
        {
            var result = default(string);

            using (var algorithm = new SHA512Managed())
            {
                result = GenerateHashString(algorithm, text);
            }

            return result;
        }
    }
}
