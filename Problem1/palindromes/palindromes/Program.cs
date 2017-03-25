using System;
using System.Diagnostics;

namespace palindromes {
    public class Program {
        static void Main(string[] args) {
            int n = 0;
            while (n <= 1 || n > 1000) {
                n = get_limit();
            }
            find_largest_palindrome(n);
            Console.ReadLine();
        }

        private static int get_limit() {
            Console.Write("N=");
            string input = Console.ReadLine();
            int result;
            if (Int32.TryParse(input, out result)) {
                return result;
            }
            return 0;
        }

        private static void find_largest_palindrome(int limit) {
            int max_palindrome, smaller_number, larger_number;
            max_palindrome = smaller_number = larger_number = 0;

            for (int i = limit; i >= 0; i--) {
                for (int j = limit; j >= 0; j--) {
                    int product = i * j;
                    if (is_palindrome(product)) {
                        int smaller = Math.Min(i, j);
                        int larger = Math.Max(i, j);

                        if (product > max_palindrome 
                            || (product == max_palindrome && smaller < smaller_number)) {
                            max_palindrome = product;
                            smaller_number = smaller;
                            larger_number = larger;
                        } 
                    }
                }
            }

            Console.WriteLine(String.Format("{0} {1}", smaller_number, larger_number));
            Console.WriteLine(max_palindrome);
        }

        private static bool is_palindrome(int number) {
            string number_as_string = number.ToString();
            int left = 0;
            int right = number_as_string.Length - 1;

            while (left < right) {
                if (number_as_string[left] != number_as_string[right]) {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}