using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards {
    class Program {
        static void Main(string[] args) {
            // в n ще съхраняваме броя карти
            int n = 0;
            while (n <= 1 || n > 1000) {
                // прочитаме n от потребителя
                n = get_limit();
            }
            // в двата масива a и b ще съхраняваме размерите 
            // Aj и Bj на картончетата
            int[] a = new int[n];
            int[] b = new int[n];

            // прочитаме размерите на картончетата от потребителя
            if (get_card_sizes(a, b)) {
                // намираме решението на задачата
                find_longest_row(a, b);
            } else {
                Console.WriteLine("Incorrect sizes");
            }
            Console.ReadLine();
        }

        private static void find_longest_row(int[] a, int[] b) {
            int max_row_length, current_row_length;
            max_row_length = current_row_length = 1;

            // тръгваме по списъка с картончета, като пропускаме първото
            for (int i = 1; i < a.Length; i++) {
                // ако можем да поставим текущото върху предното
                if (can_put_over_previous(a, b, i)) {
                    // увеличаваме брояча на текущо намерената поредица
                    current_row_length++;
                    // ако текущо намерената поредица е по-дълга от 
                    // най-дългата досега
                    if (current_row_length > max_row_length) {
                        // текущата става най-дългата до момента
                        max_row_length = current_row_length;
                    }
                } else {
                    // ако текущото не може да се постави върху предното, значи
                    // поредицата е свършила и нулираме брояча
                    current_row_length = 1;
                }
            }
            Console.WriteLine(max_row_length);
        }

        // функция да установи дали картончето на позиция index може да се постави
        // върху предходното, както е по задание
        private static bool can_put_over_previous(int[] a, int[] b, int index) {
            // ако е първото картонче -- за него няма предходно, така че резултатът е false
            if (index <= 0){
                return false;
            }

            // първо проверяваме дали може да се постави без завъртане. Това ще е така, само ако 
            // страните a и b на текущото картонче са по-малки или равни на съответните им страни
            // на предходното
            if (a[index] <= a[index - 1] && b[index] <= b[index - 1]) {
                return true;
            }

            // ако проверката без завъртане не успее, проверяваме дали може да се завърти.
            // проверяваме отново страните, но този път в завъртяно състояние -- т.е. проверяваме
            // дали a от текущото е по-малка или равна на b на предходното и обратно
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
            // разделяме въведения стринг на числа и присвояваме четните числа в масива a,
            // а нечетните -- в масива b така a[i] и b[i] ще съхраняват размерите на 
            // картонче i
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
