using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int k = 1;
            int[] derp = {};
            List<int> herp = new List<int>();
            herp.Count();
            string[] inputStrings =
                "0 1 0 0 0 0 0 1 0 1 0 0 0 1 0 0 1 0 1 0 0 0 0 1 0 0 1 0 0 1 0 1 0 1 0 1 0 0 0 1 0 1 0 0 0 1 0 1 0 1 0 0 0 1 0 1 0 0 0 1 0 1 0 0 0 1 0 0 1 0 1 0 1 0 1 0 1 0 1 0 1 0 0 1 0 1 0 1 0 1 0 0 0 0 0 0 1 0 0 0"
                    .Split(' ');
            int[] sticks = {5, 4, 4, 2, 2, 8};
            int[] socks = { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            int[] input = Array.ConvertAll(inputStrings, Int32.Parse);
            int[] nonDivisPairs = { 1, 7, 2, 4 };
//            int[] c = Array.ConvertAll(inputStrings, Int32.Parse);
            int[] c = { 0, 0, 1, 0, 0, 1, 0 };
            int[] prices = {3, 10, 2, 9};
            int charged = 7;
            splitBill(n, k, prices, charged);
//            cloudJump(n, c);
//            countA("aba", 10);
//            nonDivPairs(nonDivisPairs, n, k);
//            divSumPairs(input, n, k);
//            cutSticks(sticks);
//            countSocks(socks, n);
            Console.ReadKey();
        }

        static long calculateAmount(int[] prices)
        {
            List<int> result = new List<int>();
            List<int> leftOf = new List<int>();
            result.Add(prices[0]);

            for(int i = 1; i < prices.Length; i++)
            {
                Console.WriteLine("Current Price " + prices[i]);
                leftOf.Add(prices[i-1]);
                int discount = leftOf.Min();
                int price = prices[i] - discount;
                if(discount > prices[i])
                    result.Add(0);
                else
                {
                    result.Add(prices[i]-discount);
                }
            }

            return result.Sum();
        }

        static void fractions(int[] arr, int n)
        {
            double neg = 0;
            double zero = 0;
            double pos = 0;
            for (int i = 0; i < n; i++)
            {
                neg += arr[i] > 0 ? 1 : 0;
                zero += arr[i] == 1 ? 1 : 0;
                pos += arr[i] < 0 ? 1 : 0;
            }

            Console.WriteLine((pos/n).ToString("f5"));
            Console.WriteLine((neg/n).ToString("f5"));
            Console.WriteLine((zero/n).ToString("f5"));
            Console.WriteLine($"{neg/n:0.#####}");
            Console.WriteLine($"{zero/n:0.#####}");

        }

        static void divSumPairs(int[] a, int n, int k)
        {
            int pairs = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i] < a[j])
                    {
                        int derp = (a[i] + a[j]) % k;

                        Console.WriteLine("{0} is less than {1}", a[i], a[j]);
                        Console.WriteLine("{0} mod {1} = {2}", a[i], a[j], derp);
                        if (derp == 0)
                        {
                            pairs += 1;
                        }
                    }
                }
            }
            Console.WriteLine(pairs);
        }

        static void cutSticks(int[] sticks)
        {
            int cut = sticks[0];
            int numCuts = 0;
            List<int> result = new List<int>();
            for (int i = 0; i < sticks.Length; i++)
            {
                if (sticks[i] < cut)
                    cut = sticks[i];
            }

            for (int i = 0; i < sticks.Length; i++)
            {
                if (sticks[i] - cut > 0)
                {
                    numCuts += 1;
                    result.Add(sticks[i]);
                }
            }
            Console.WriteLine(numCuts);
            if (result.Count() > 0)
                cutSticks(result.ToArray());
        }

        static void countSocks(int [] socks, int n)
        {
            int pairCount = 0;
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Sock {0}", socks[i]);
                if (pairs.ContainsKey(socks[i]))
                {
                    Console.WriteLine("Increment sock {0}", socks[i]);
                    pairs[socks[i]] += 1;
                }
                else
                {
                    Console.WriteLine("Adding sock {0}", socks[i]);
                    pairs.Add(socks[i], 1);
                }
            }

            foreach (KeyValuePair<int, int> item in pairs)
            {
                Console.WriteLine(item.Value);
                pairCount += item.Value/2;
            }
            Console.WriteLine("number of pairs {0}", pairCount);
        }

        static void nonDivPairs(int[] a, int n, int k)
        {
            int nonDivPairs = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((a[i] % k) + (a[j] % k) == k)
                    {
                        nonDivPairs += 1;
                    }
                }
            }

            Console.WriteLine(nonDivPairs);
        }

        static void countA(string s, int n)
        {
            int aCount = 0;

            foreach (char a in s)
            {
                if (a == 'a')
                    aCount++;
            }
            int totalChars = s.Length*n;
            Console.WriteLine("A in s: {0}", aCount);
            int notA = n/s.Length;
            Console.WriteLine("notA: {0}", notA);
            Console.WriteLine(s.Length%n);
            int relevantChars = s.Length + n%s.Length;

            long result = aCount*notA + n%s.Length;
            Console.WriteLine(result);
        }

        static void cloudJump(int n, int[] c)
        {
            int moves = 0;
            int position = 0;
            do
            {
                if (position+2 < n && c[position + 2] == 0)
                {
                    Console.WriteLine("Jump to position {0}", position);
                    moves++;
                    position += 2;
                }
                else
                {
                    if (c[position + 1] == 0)
                    {
                        Console.WriteLine("Jump to position {0}", position);
                        moves++;
                        position += 1;
                    }
                }

            } while (position <= n - 2);

            Console.WriteLine(moves);
        }

        static void splitBill(int n, int k, int[] prices, int charged)
        {
            int totalSplit = 0;
            int splitPrice = 0;
            int subTot = 0;

            for (int i = 0; i < n; i++)
            {
                subTot += prices[i];
                if (i != k)
                {
                    splitPrice += prices[i];
                    Console.WriteLine("i != k");
                }

            }
            totalSplit = subTot / 2;
            splitPrice = splitPrice/2;

            if (charged == splitPrice)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
                Console.WriteLine(totalSplit - splitPrice);
        }
    }
}
