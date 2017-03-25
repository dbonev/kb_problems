using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards {
    class Program {
        static void Main(string[] args) {
            int n = 0;
            while (n <= 1 || n > 1000) {
                n = get_limit();
            }
            int[] a = new int[n];
            int[] b = new int[n];
            if (get_card_sizes(a, b)) {
                find_longest_row(a, b);
            } else {
                Console.WriteLine("Incorrect sizes");
            }
            Console.ReadLine();
        }

        private static void find_longest_row(int[] a, int[] b) {
            int max_row_length, current_row_length;
            max_row_length = current_row_length = 1;

            for (int i = 1; i < a.Length; i++) {
                if (can_put_over_previous(a, b, i)) {
                    current_row_length++;
                    if (current_row_length > max_row_length) {
                        max_row_length = current_row_length;
                    }
                } else {
                    current_row_length = 1;
                }
            }
            Console.WriteLine(max_row_length);
        }

        private static bool can_put_over_previous(int[] a, int[] b, int index) {
            if (index <= 0){
                return false;
            }

            if (a[index] <= a[index - 1]) {
                return b[index] <= b[index - 1];
            }

            if (a[index] <= b[index - 1]) {
                return b[index] <= a[index - 1];
            }
            return false;
        }

        private static bool get_card_sizes(int[] a, int[] b) {
            Console.Write("Sizes=");
            string sizes_string = Console.ReadLine();
            string[] split = sizes_string.Split(' ');
            if (split.Length != a.Length * 2) {
                return false;
            }

            for (int i = 0; i < split.Length; i++) {
                int j = Int32.Parse(split[i]);
                if (i % 2 == 0) {
                    a[i / 2] = j;
                } else {
                    b[i / 2] = j;
                }
            }
            return true;
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
    }
}
