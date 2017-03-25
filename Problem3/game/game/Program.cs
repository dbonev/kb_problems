using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game {
    class Program {
        static int k, m;
        static void Main(string[] args) {
            get_secret_numbers();
            game();
            Console.ReadLine();
        }

        private static void game() {
            int n;
            int sum = 0;
            int smallest_diff = Int32.MaxValue;
            int turn = 0;
            int turn_of_closest = 0;
            bool game_over = false;

            do {
                turn++;
                n = int.Parse(Console.ReadLine());
                if (n % 2 == 0) {
                    sum += n;
                }
                int diff = Math.Abs(k - n);
                if (diff <= smallest_diff) {
                    turn_of_closest = turn;
                    smallest_diff = diff;
                }

                game_over = sum > m || turn >= 200;
            } while (!game_over);

            Console.WriteLine(String.Format("{0} {1}", turn_of_closest, sum));
        }

        private static void get_secret_numbers() {
            Console.Write("Secret numbers = ");
            string numbers_string = Console.ReadLine();
            string[] split = numbers_string.Split(' ');
            k = int.Parse(split[0]);
            m = int.Parse(split[1]);
        }
    }
}
