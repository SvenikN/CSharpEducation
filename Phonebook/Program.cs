using System;
using System.Collections.Generic;
using Phonebook;
using System.Text.Json;
namespace Phonebook;

class Program
{
    public static void Main(string[] args)
    {
        Phonebook phonebook = Phonebook.GetInstance();
        bool prog = true;
        List<Abonent> abonent = new List<Abonent>();

        while (prog)
        {
            Bar();
            int bar = Convert.ToInt32(Console.ReadLine());

            switch (bar)
            {
                case 1:
                    { 
                        abonent = phonebook.PrintAbonent();
                        if (abonent.Count != 0)
                            foreach (Abonent ab in abonent)
                                Console.WriteLine($"Name: {ab.Name}, Number: {ab.Number}");
                        
                        else Console.WriteLine("Список абонентов пуст");
                    }
                    break;
                case 2:
                    {
                        Console.Write($"Name - ");
                        string name = Console.ReadLine();

                        Console.Write($"Number - ");
                        string number = Console.ReadLine();

                        phonebook.CreateAbonent(name, number);
                        Console.WriteLine("Абонент создан");
                    }
                    break;
                case 3:
                    {
                        Console.Write("Введите имя которое нужно удалить - ");
                        string nameDel = Console.ReadLine();
                        phonebook.DeleteAbonent(nameDel);
                        Console.WriteLine("Абонент удален");
                    }
                    break;
                case 4:
                    {
                        Console.Write("Введите имя для поиска - ");
                        string names = Console.ReadLine();
                        abonent = phonebook.SearchName(names);
                        foreach (Abonent ab in abonent)
                            Console.WriteLine($"{ab.Name} {ab.Number}");
                    }
                    break;
                case 5:
                    {
                        Console.Write("Введите номер для поиска - ");
                        string numbers = Console.ReadLine();
                        abonent = phonebook.SearhNumber(numbers);
                        foreach (Abonent ab in abonent)
                            Console.WriteLine($"{ab.Name} {ab.Number}");
                    }
                    break;
                case 6:
                    {
                        phonebook.WriteFile();
                        Console.WriteLine("Файл сохранен");
                        prog = false;
                    }
                    break;
                default: break;
            }
        } 
    }

    #region

    /// <summary>
    /// Вывести меню в консоль
    /// </summary>
    static void Bar()
    {
        Console.WriteLine(@" Меню:
        1. Вывести всех абонентов
        2. Создать абонента
        3. Удалить абонента
        4. Найти абонента по имени
        5. Найти абонента по номеру
        6. Выход из программы");
    }
    #endregion
}

