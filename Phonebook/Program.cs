using Phonebook;
using System.Text.Json;
namespace Phonebook;

class Program
{
    public static void Main(string[] args)
    {
        var phonebook = new Phonebook();
        List<Abonent> abonents = phonebook.ReadFile();
        bool prog = true;

        while (prog)
        {
            Bar();
            int bar = Convert.ToInt32(Console.ReadLine());

            switch (bar)
            {
                case 1: phonebook.PrintAbonent(abonents);
                    break;
                case 2: phonebook.CreateAbonent(abonents);
                    break;
                case 3: phonebook.DeleteAbonent(abonents);
                    break;
                case 4: phonebook.SearchName(abonents);
                    break;
                case 5: phonebook.SearhNumber(abonents);
                    break;
                case 6:
                    {
                        phonebook.WriteFile(abonents);
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
        1. Вывести все абоненты
        2. Создать абонента
        3. Удалить абонента
        4. Найти абонента по имени
        5. Найти абонента по номеру
        6. Выход из программы");
    }
    #endregion
}

