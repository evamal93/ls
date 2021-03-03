using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        // Захар Каледин.

        #region Методы к задаче 1
        static int minDetectMath(int a, int b, int c) // через Math
        {
            int x = Math.Min(a, b);
            int z = Math.Min(b, c);

            return Math.Min(x, z);
        }

        static int minDetectIf(int a, int b, int c) // через If
        {

            if (a < b && a < c)
                return a;
            else if (b < a && b < c)
                return b;
            else return c;
        }

        static int minDetectTern(int a, int b, int c) // через тернарный оператор
        {
            int min = a < b ? (a < c ? a : c) : (b < c ? b : c);
            return min;

        }

        #endregion

        #region Метод к задаче 2
        static int figCount(int n)
        {
            int count = 0;

            while (n != 0)
            {
                count++;
                n = n / 10;
            }

            return count;
        }
        #endregion

        #region Метод к задаче 4 (рекурсия)
        static void accountCheck(string login, string password, int count)
        {

            string correctLogin = "root";
            string correctPassword = "GeekBrains";

            if ((login == correctLogin || password == correctPassword) && count > 0)
            {
                Console.WriteLine("Все верно. Добро пожаловать!");
                Console.ReadLine();
            }

            else if ((login != correctLogin || password != correctPassword) && count > 0)
            {
                Console.WriteLine("Вы ввели неправильный логин или пароль. Введите логин");
                login = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите пароль");
                password = Convert.ToString(Console.ReadLine());
                accountCheck(login, password, count - 1);
            }
            else if (count == 0)
            {
                Console.WriteLine("Вход заблокирован.");
                Console.ReadLine();
            }

        }
        #endregion

        #region Метод к задаче 4 (do while)
        static void accountCheck2()
        {
            int count2 = 0;
            do
            {
                Console.WriteLine("Введите логин");
                string login2 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите пароль");
                string password2 = Convert.ToString(Console.ReadLine());
                string correctLogin = "root";
                string correctPassword = "GeekBrains";

                if (login2 == correctLogin || password2 == correctPassword)
                {
                    Console.WriteLine("Добро пожаловать!");
                    break;
                }
                else if (count2 < 2)
                {
                    Console.WriteLine("Неправильно, попробуйте еще раз.");
                    count2++;
                }
                else if (count2 == 2)
                {
                    Console.WriteLine("Неправильный логин или пароль. Доступ запрещен.");
                    break;
                }
            }
            while (count2 <= 2);
        }
        #endregion

        #region Метод к задаче 5
        static void bmiAdvice(double bmi, double weight, double height)
        {
            if (bmi < 18.50)
            {
                Console.WriteLine("Вы весите меньше нормы. Вам нужно набрать {0:F2} кг.", 18.50 * Math.Pow(height, 2) - weight);
                Console.ReadLine();
            }
            else if (bmi > 24.99)
            {
                Console.WriteLine("Вы весите больше нормы. Вам нужно сбросить {0:F2} кг.", weight - 24.99 * Math.Pow(height, 2));
                Console.ReadLine();
            }
            else if (bmi > 18.50 && bmi < 24.99)
            {
                Console.WriteLine("Ваш ИМТ соответствует норме.");
                Console.ReadLine();
            }
        }
        #endregion

        #region Методы к задаче 6
        static int NumSumm(int number) // вычисляем сумму цифр числа
        {
            int s = 0;
            while (number != 0)
            {
                s = s + number % 10;
                number = number / 10;
            }
            return s;
        }

        static int check(int i, int numberSumm) // проверяем, делится ли число на сумму своих цифр
        {
            int count = 0;
            if (i % numberSumm == 0)
                count++;
            return count;
        }

        static int goodNumCount(int goodNumCount) // считаем хорошие числа
        {
            for (int i = 1; i <= 1000000000; i++)
            {
                int numberSumm = NumSumm(i);
                goodNumCount = goodNumCount + check(i, numberSumm);
            }
            return goodNumCount;
        }
        #endregion

        #region Методы к задаче 7
        static void numbersDisplay(int firstNumber, int count)
        {
            if (count > 0)
            {
                Console.WriteLine($"{firstNumber}");
                firstNumber++;
                numbersDisplay(firstNumber, count - 1);
            }
            
        }
              static void allNumbersSum(int firstNumber, int numbersSumm, int count2)
        {
            /* метод работает некорректно, сначала выводит множество промежуточных значений, 
             * а потом уже правильное. В отладчике видно, что когда i достигает нуля, метод выводит на 
             * экран значение, и, несмотря на return и 0 в счетчике, снова запускает сам себя. */
            for (int i = count2; i > 0; i--)
                {
                    numbersSumm = numbersSumm + firstNumber;
                    firstNumber++;
                    allNumbersSum(numbersSumm, numbersSumm, count2 - 1);
                }
            Console.WriteLine($"Сумма всех чисел равна {numbersSumm}.");
            return;
        }
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Title = "Выбор задания";
                Console.Write("Введите номер задания (0 - выход): ");
                int taskNum = int.Parse(Console.ReadLine());

                switch (taskNum)
                {
                    case 0:
                        return;

                    /*1. Написать метод, возвращающий минимальное из трех чисел.*/
                    #region Задание 1
                    case 1:

                        Console.Title = "Определение минимального числа";

                        Console.WriteLine("Введите первое число:");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите второе число:");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите третье число:");
                        int c = int.Parse(Console.ReadLine());

                        int minIf = minDetectIf(a, b, c);
                        int minTern = minDetectTern(a, b, c);

                        Console.WriteLine("Минимальное число - {0}", minDetectMath(a, b, c));
                        Console.WriteLine("Минимальное число - {0}", minIf);
                        Console.WriteLine("Минимальное число - {0}", minTern);
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    #endregion
                    /*2. Написать метод подсчета количества цифр числа.*/
                    #region Задание 2
                    case 2:

                        Console.Title = "Подсчет количества цифр в числе";

                        Console.WriteLine("Введите число:");
                        int n = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Количество цифр в числе {n} - {figCount(n)}");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    #endregion
                    /*3. С клавиатуры вводятся числа, пока не будет введен 0. 
                     * Подсчитать сумму всех нечетных положительных чисел.*/
                    #region Задание 3
                    case 3:

                        Console.Title = "Подсчет суммы нечетных чисел";

                        Console.WriteLine("Введите число:");
                        int enteredNum = int.Parse(Console.ReadLine());

                        int sum = 0;

                        while (enteredNum != 0)
                        {
                            if (enteredNum % 2 != 0)
                            {
                                sum = sum + enteredNum;
                            }
                            Console.WriteLine($"Сумма всех нечетных чисел в вводимой вами последовательности равна {sum}");
                            Console.WriteLine("Введите следующее число. Введите 0 для вывода результата и выхода из программы.");
                            enteredNum = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine($"Сумма всех нечетных чисел в вводимой вами последовательности равна {sum}");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    #endregion
                    /*4. Реализовать метод проверки логина и пароля. На вход подается логин и пароль. 
                     * На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
                     * Используя метод проверки логина и пароля, написать программу: 
                     * пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
                     * С помощью цикла do while ограничить ввод пароля тремя попытками.*/
                    #region Задание 4
                    case 4:

                        Console.Title = "Авторизация";

                        // сначала не разобрался, как сделать через do while, и сделал громоздко через рекурсию.
                        Console.WriteLine("Введите логин");
                        string login = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Введите пароль");
                        string password = Convert.ToString(Console.ReadLine());

                        accountCheck(login, password, 2);
                        Console.Clear();

                        // здесь я понял, как выполнить задание через do while, целиком засунул задачу в метод.
                        accountCheck2();

                        Console.ReadLine();
                        Console.Clear();

                        break;

                    #endregion
                    /*5. а) Написать программу, которая запрашивает массу и рост человека, 
                     * вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
                     * б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.*/
                    #region Задание 5
                    case 5:

                        Console.Title = "ИМТ";

                        Console.WriteLine("Введите ваш вес в кг:");
                        int weight = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите ваш рост в метрах (в виде десятичной дроби, через запятую):");
                        double height = Convert.ToDouble(Console.ReadLine());

                        double bmi = (weight / (height * height));

                        Console.WriteLine("Ваш ИМТ равен {0:F2}", bmi);
                        bmiAdvice(bmi, weight, height);
                        Console.Clear();

                        break;
                    #endregion
                    /**6. Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. 
                     * Хорошим называется число, которое делится на сумму своих цифр. 
                     * Реализовать подсчет времени выполнения программы, используя структуру DateTime.*/
                    #region Задание 6
                    case 6:

                        Console.Title = "Подсчет хороших чисел";

                        DateTime start = DateTime.Now;
                        int goodNCount = 0;
                        Console.WriteLine($"Всего хороших чисел - {goodNumCount(goodNCount)}");
                        DateTime finish = DateTime.Now;
                        Console.WriteLine(finish - start);
                        Console.ReadLine();

                        break;
                    #endregion
                    
                    #region Задание 7
                    case 7:
                        // a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);

                        Console.Title = "Вывод чисел от a до b и подсчет их суммы";

                        Console.WriteLine("Введите первое число:");
                        int firstNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите второе число:");
                        int secondNumber = Convert.ToInt32(Console.ReadLine());

                        if (firstNumber < secondNumber)
                        {
                            int count = secondNumber - firstNumber + 1;
                            numbersDisplay(firstNumber, count);
                        }
                        else Console.WriteLine("Первое число должно быть больше второго.");

                        Console.ReadLine();
                        Console.Clear();
                        //*Разработать рекурсивный метод, который считает сумму чисел от a до b.
                        Console.WriteLine("Введите первое число:");
                        int firstNumber2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите второе число:");
                        int secondNumber2 = Convert.ToInt32(Console.ReadLine());

                        int count2 = secondNumber - firstNumber + 1;
                        int numbersSumm = 0;
                        allNumbersSum(firstNumber2, numbersSumm, count2);
                        
                        Console.ReadLine();
                        Console.Clear();

                        break;
                        #endregion
                }
            }
        }
    }
}
