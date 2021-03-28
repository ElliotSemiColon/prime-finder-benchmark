using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace optimised_primes
{
    static class Program
    {
        
        static void OutputList<T>(this List<T> list)
        {
            foreach (T item in list) { Console.Write($"{item} "); }
        }

        static List<int> InvertedSieve(int limit) //sieve without the populate method
        {
            bool[] isntPrime = new bool[limit]; //array of falses
            //Populate(isPrime, true); //does not set all values to true, as this takes time we will instead invert the logic
            //foregoing this method allows for an extra 150 odd iterations in benchmark

            List<int> primes = new List<int>();

            if (limit <= 2) { return primes; }
            isntPrime[0] = isntPrime[1] = true;

            for (int i = 2; i <= (int)Math.Sqrt(limit); i++) //starts at number 2
            {
                if (!isntPrime[i]) //if prime 
                {
                    for (int j = i * i; j < limit; j += i) //can start at i^2 since all multiples lower will have been removed by previous iterations
                    {
                        isntPrime[j] = true; //sets all multiples of i in list to false excluding the prime
                    }
                }
            }
            for (int i = 0; i < limit; i++) { if (!isntPrime[i]) { primes.Add(i); } }
            return primes;
        }

        static List<int> Benchmark(int limit)
        {
            Stopwatch stopwatch = new Stopwatch();

            int count = 0;
            List<int> primes = new List<int>();

            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 5000)
            {
                primes = InvertedSieve(limit);
                count++;
            }
            stopwatch.Stop();
            Console.WriteLine($"found {primes.Count} primes {count} times in {stopwatch.ElapsedMilliseconds}ms\napprox. {stopwatch.ElapsedMilliseconds / count}ms per test");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"scored {count}pts");
            Console.ForegroundColor = ConsoleColor.White;
            //OutputList(Sieve(limit));
            return primes;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("prime number finding cpu/ram benchmark");
            int limit = 1000000;
            try 
            { 
                Console.WriteLine($"benchmarking with search limit {limit} (allow 5 seconds)");

                List<int> primes = Benchmark(limit);
                Console.WriteLine($"output the {primes.Count} primes in these searches? (y/n)");
                string response = Console.ReadLine().ToLower();
                if (response == "y") { OutputList(primes); }
            } 
            catch (FormatException e) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("could not benchmark");
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
