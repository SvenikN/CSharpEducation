using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Phonebook
    {
        private static Phonebook instance;
        public static string path = @"D:\CSharpEducation\phonebook.txt";

        public Phonebook()
        { }

        public static Phonebook GetInstance()
        {
            if (instance == null)
                instance = new Phonebook();
            return instance;
        }

        #region
        /// <summary>
        /// Вывести из файла всех абонентов при запуске программы
        /// </summary>
        public List<Abonent> ReadFile()
        {
            string line;
            using (StreamReader read = new StreamReader(path))
            {
                line = read.ReadToEnd();

            }
            List<Abonent>? abonents = JsonSerializer.Deserialize<List<Abonent>>(line);

            foreach (Abonent abonent in abonents)
                Console.WriteLine($"Name: {abonent.Name}, Number: {abonent.Number}");

            return abonents;
        }
        #endregion

        #region
        /// <summary>
        /// Вывести список абонентов
        /// </summary>
        /// <param name="abonents">Список всех абонентов</param>
        public void PrintAbonent(List<Abonent> abonents)
        {
            foreach (var abonent in abonents)
                Console.WriteLine($"Name: {abonent.Name}, Number: {abonent.Number}");
        }
        #endregion

        #region
        /// <summary>
        /// Добавить в список нового абонента
        /// </summary>
        public void CreateAbonent(List<Abonent> abonents)
        {
            Console.Write($"Name - ");
            string name = Console.ReadLine();

            Console.Write($"Number - ");
            string number = Console.ReadLine();

            if ((abonents.Any(ab => ab.Name == name)) && (abonents.Any(ab => ab.Number == number)))
                Console.WriteLine("Абонент с таким именем и номером уже существует");
            else abonents.Add(new Abonent(name, number));
        }
        #endregion

        #region
        /// <summary>
        /// Удаление абонента
        /// </summary>
        /// <param name="abonents"></param>
        public void DeleteAbonent(List<Abonent> abonents)
        {
            Console.Write("Введите имя которое нужно удалить - ");
            string nameDel = Console.ReadLine();

            abonents.RemoveAll(a => a.Name == nameDel);
            Console.WriteLine("Абонент удален");
        }
        #endregion

        #region
        /// <summary>
        /// Поиск по имени
        /// </summary>
        /// <param name="abonents">Список всех абонентов</param>
        public void SearchName(List<Abonent> abonents)
        {
            Console.Write(@"Введите имя для поиска - ");
            string names = Console.ReadLine();
            bool search = false;

            foreach (Abonent abonent in abonents)
                if (abonent.Name.Contains(names))
                {
                    Console.WriteLine($"{abonent.Name} {abonent.Number}");
                    search = true;
                }
            if (!search)
                Console.WriteLine("Имя не найдено");
        }
        #endregion

        #region
        /// <summary>
        /// Поиск по номеру
        /// </summary>
        /// <param name="abonents">Список всех абонентов</param>
        public void SearhNumber(List<Abonent> abonents)
        {
            Console.Write(@"Введите номер для поиска - ");
            string numbers = Console.ReadLine();
            bool search = false;

            foreach (Abonent abonent in abonents)
                if (abonent.Number == numbers)
                { 
                    Console.WriteLine($"{abonent.Name} {abonent.Number}");
                    search = true;
                }
            if (!search)
                Console.WriteLine("Номер не найден");
            
        }
        #endregion

        #region
        /// <summary>
        /// Запись всех абонентов в файл, после закрытия программы
        /// </summary>
        /// <param name="abonents">список всех абонентов</param>
        public void WriteFile(List<Abonent> abonents)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
                fileInf.Delete();

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                string json = JsonSerializer.Serialize(abonents) + Environment.NewLine;
                writer.WriteLine(json);
            }
        }
        #endregion
    }
}
