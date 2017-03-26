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
            int n; // числото, въведено от потребителя -- казано от Ева
            int sum = 0; // сумата от четните числа
            int smallest_diff = Int32.MaxValue; // най-малката разлика до намисленото от Крис число 
            int turn = 0; // тук следим поредния номер на числото, казано от Ева
            int turn_of_closest = 0; // тук пазим поредния номер на най-близкото число
            bool game_over = false; // условие за завършване на играта

            do {
                // увеличаваме брояча на поредните номера
                turn++;
                // прочитаме входа от потребителя
                n = int.Parse(Console.ReadLine()); 
                // ако е четно число, натрупваме в сумата
                if (n % 2 == 0) {
                    sum += n;
                }
                // проверяваме дали въведеното число е най-близкото до числото на Крис
                // от числата досега
                // първо изчисляваме разликата
                int diff = Math.Abs(k - n);
                // след това гледаме дали е по-малка от досегашната -- ако е така
                // значи имаме ново най-близко число. Условието е <= защото по условие 
                // трябва да запомним по-късно въведеното
                if (diff <= smallest_diff) {
                    turn_of_closest = turn;
                    smallest_diff = diff;
                }
                // играта завършва когато или сумата от четните числа надхвърли числото на
                // Крис, или когато поредния номер е 200
                game_over = sum > m || turn == 200;
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
