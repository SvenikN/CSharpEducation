using System;

class TicTacToe
{
    static string[] pole = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    static void Main(string[] args)
    {
        bool validInput;
        int player = 1;
        int top = 0;

        ConsoleColor originalColor = Console.ForegroundColor;

        DrawPole();

        while (true)
        {
            Console.Write($"Ход {player} игрока. Введите число ячейки - ");
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ForegroundColor = originalColor;

            // Проверка корректности хода
            validInput = int.TryParse(input, out int steps) && steps >= 1 && steps <= 9 && pole[steps - 1] != "X" && pole[steps - 1] != "O";
            if (validInput)
            {
                pole[steps - 1] = (player == 1) ? "X" : "O";
                top = ++top;
                DrawPole();
                if (IsChampion(player)) break; // Проверка победной комбинации хода
                if (top == 9) // Проверка на ничью
                {
                    Console.WriteLine($"У вас ничья!");
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Смотри, что вводишь!");
                break;
            }

            player = (player == 1) ? 2 : 1;
        }
    }

    // Отрисовка поля
    static void DrawPole()
    {
        Console.WriteLine();
        Console.WriteLine($"{pole[0]} | {pole[1]} | {pole[2]}");
        Console.WriteLine($"----------");
        Console.WriteLine($"{pole[3]} | {pole[4]} | {pole[5]}");
        Console.WriteLine($"----------");
        Console.WriteLine($"{pole[6]} | {pole[7]} | {pole[8]}");
        Console.WriteLine();
    }

    // Проверка победной комбинации хода
    static bool IsChampion(int player)
    {
        if (((pole[0] == pole[1]) && (pole[1] == pole[2])) ||
            ((pole[3] == pole[4]) && (pole[4] == pole[5])) ||
            ((pole[6] == pole[7]) && (pole[7] == pole[8])) ||
            ((pole[0] == pole[3]) && (pole[3] == pole[6])) ||
            ((pole[1] == pole[4]) && (pole[4] == pole[7])) ||
            ((pole[2] == pole[5]) && (pole[5] == pole[8])) ||
            ((pole[0] == pole[4]) && (pole[4] == pole[8])) ||
            ((pole[2] == pole[4]) && (pole[4] == pole[6])))
        {
            Console.WriteLine($"Победил игрок {player}");
            return true;
        }
        return false;
    }
}
