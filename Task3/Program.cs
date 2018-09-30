using System;

// Исполнитель Калькулятор преобразует целое число, записанное на экране. У исполнителя две команды, каждой команде присвоен номер:
// Прибавь 1.
// Умножь на 2. Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.
// Сколько существует программ, которые число 3 преобразуют в число 20? 
// а) с использованием массива; б) с использованием рекурсии.

// Коновальцев Александр

namespace Task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var p = new MainClass();
            var number = p.GetRandomNumber();
            p.StartGame(number);

        }

        void StartGame(int number)
        {
            var countOfUser = 0;
            var minCount = GetMinCountOfSteps(number);
            var userNumberToStartGame = 1;
            Console.WriteLine($"Try to get number {number} by minimum count of steps by using only two commands: " +
                              "type 1 to increment number by one or type 2 to multiply number by two): ");

            Console.WriteLine($"Current start number is: {userNumberToStartGame}");

            while (userNumberToStartGame <= number)
            {
                if (userNumberToStartGame == number && countOfUser == minCount)
                {
                    Console.WriteLine("You are awesome! This is the best possible result!");
                    return;
                }
                if (userNumberToStartGame == number)
                {
                    Console.WriteLine($"Good job, but you could be better! The minimal count of steps for {number} is {minCount}");
                    return;
                }
                Console.WriteLine("Type 1 or 2 to perform operation...");
                try
                {
                    var operation = 0;
                    operation = int.TryParse(Console.ReadLine(), out operation) ? operation : throw new Exception("Please, enter integer value");

                    if(operation == 1)
                    {
                        countOfUser++;
                        Console.WriteLine($"{countOfUser} step");
                        userNumberToStartGame = PlusTwo(userNumberToStartGame);
                        Console.WriteLine($"Result: {userNumberToStartGame}");
                    }
                    if(operation == 2)
                    {
                        countOfUser++;
                        Console.WriteLine($"{countOfUser} step");
                        userNumberToStartGame = MultiplyTwo(userNumberToStartGame);
                        Console.WriteLine($"Result: {userNumberToStartGame}");
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

        }


        int PlusTwo(int n) // increment number by one
        {
            return ++n;
        }

        int MultiplyTwo(int n) // multiply number by two
        {
            return n * 2;
        }

        int GetRandomNumber() // set random number to start game
        {
            Random number = new Random();
            return number.Next(1, 100);
        }


        int GetMinCountOfSteps(int a) // estimate min count of steps to get necessary number
        {
            int count = 0;
            while (a != 1)
            {
                count++;
                a = a % 2 == 0 ? a / 2 : a - 1;
            }
            return count;
        }
    }
}