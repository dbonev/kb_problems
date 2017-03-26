using System;
using System.Diagnostics;

namespace palindromes {
    public class Program {
        static void Main(string[] args) {
            int n = 0;
            // взимаме числото N, така че да е 
            // между 1 и 1000
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

            // пробваме всички възможни комбинации 
            // от произведенията на естествените числа до N (limit)
            for (int i = limit; i >= 0; i--) {
                for (int j = limit; j >= 0; j--) {
                    // изчисляваме произведението
                    int product = i * j;
                    // проверяваме дали е палиндром
                    if (is_palindrome(product)) {
                        // по условие ни е важно да знаем
                        // кое е по-малкото и кое е по-голямото число
                        // между i & j
                        int smaller = Math.Min(i, j);
                        int larger = Math.Max(i, j);

                        // ако намереният палиндром е по-голям от най-големия досега
                        if (product > max_palindrome 
                            // или са равни, но с по-малък множител (това търсим по условие)
                            || (product == max_palindrome && smaller < smaller_number)) {
                            // запомняме максималния палиндром и двата множителя
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

        // определя дали едно число е палиндром
        // има доста по-лесен начин, но е специфичен за c#
        // затова съм разписал по-общ подход
        private static bool is_palindrome(int number) {
            // обръщаме числото в string
            string number_as_string = number.ToString();
            int left = 0;
            int right = number_as_string.Length - 1;
            // тръгваме от двата края -- отпред и отзад, докато 
            // индексите се срещнат
            while (left < right) {
                // сравняваме двата символа на съответните места
                // те винаги трябва да са еднакви
                // ако не са еднакви, числото не е палиндром
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