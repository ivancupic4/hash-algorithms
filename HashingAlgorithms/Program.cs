using System;
using System.Collections.Generic;

namespace HashingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! \n\nEnter the value you want to hash: ");
            string inputValue = Console.ReadLine();

            //GetSingleAlgorithmValue(inputValue);
            GetAllAlgorithmValues(inputValue);

            Console.ReadKey();
        }

        static void GetAllAlgorithmValues(string inputValue)
        {
            foreach (var algorithm in GetAlgorithms())
            {
                string hash = algorithm.Value.Invoke(inputValue);
                PrintValue(algorithm.Key, hash);
            }
        }

        static void GetSingleAlgorithmValue(string inputValue)
        {
            var algorithms = GetAlgorithms();

            Console.WriteLine("\nPlease enter the algorithm name: MD5 | SHA1 | SHA256 | SHA512");
            string algorithmName = Console.ReadLine().ToUpper();

            while (!algorithms.ContainsKey(algorithmName))
            {
                Console.WriteLine("\nEnter a valid algorithm name: ");
                algorithmName = Console.ReadLine().ToUpper();
            }

            string hash = algorithms[algorithmName].Invoke(inputValue);
            PrintValue(algorithmName, hash);
        }

        static void PrintValue(string algorithmName, string hash)
        {
            Console.Write($"\nHash value ({algorithmName}):\n{hash} \n");
            Console.Write($"- Length: {hash.Length}\n");
        }

        static Dictionary<string, Func<string, string>> GetAlgorithms()
        {
            return new Dictionary<string, Func<string, string>>
            {
                { nameof(Hasher.MD5).ToUpper(), Hasher.MD5 },
                { nameof(Hasher.SHA1).ToUpper(), Hasher.SHA1 },
                { nameof(Hasher.SHA256).ToUpper(), Hasher.SHA256 },
                { nameof(Hasher.SHA512).ToUpper(), Hasher.SHA512 }
            };
        }
    }
}
