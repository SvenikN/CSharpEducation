using System;
using System.Runtime.CompilerServices;
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

            validInput = int.TryParse(input, out int steps) && steps >= 1 && steps <= 9 && pole[steps - 1] != "X" && pole[steps - 1] != "O";
            if (validInput)
            {
                pole[steps - 1] = (player == 1) ? "X" : "O";
                top = ++top;
                DrawPole();
                if (IsChampion(player)) break;
                if (top == 9)
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

    /// <summary>
    /// Отрисовка поля
    /// </summary>
    static void DrawPole()
    {
        const string s = "|";
        const string p = "----------";

        Console.WriteLine();
        Console.WriteLine($"\t {pole[0]} {s} {pole[1]} {s} {pole[2]} \n\t {p}");
        Console.WriteLine($"\t {pole[3]} {s} {pole[4]} {s} {pole[5]} \n\t {p}");
        Console.WriteLine($"\t {pole[6]} {s} {pole[7]} {s} {pole[8]}");
        Console.WriteLine();
    }

    /// <summary>
    /// Проверка победной комбинации
    /// </summary>
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
