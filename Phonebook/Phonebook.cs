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
        private string path = (Directory.GetCurrentDirectory() + "\\phonebook.txt");

        private List<Abonent> abonents;

        private Phonebook()
        {
            abonents = new List<Abonent>();
            abonents = ReadFile();
        }

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
            ExistsFile();
            List<Abonent> abonents = null;
            string line;
            using (StreamReader read = new StreamReader(path))
            {
                line = read.ReadToEnd();
            }

            if (!string.IsNullOrEmpty(line))
            {
                abonents = JsonSerializer.Deserialize<List<Abonent>>(line);
            }

            return abonents ?? new List<Abonent>();
        }
        #endregion

        private void ExistsFile()
        {
            if (!Directory.Exists(path))
                using (FileStream file = new FileStream(path, FileMode.OpenOrCreate));
        }

        #region

        /// <summary>
        /// Вывести список абонентов
        /// </summary>
        public List<Abonent> PrintAbonent()
        {
            return abonents;
        }
        #endregion

        #region

        /// <summary>
        /// Добавить в список нового абонента
        /// </summary>
        public void CreateAbonent(string name, string number)
        {
            if ((abonents.Any(ab => ab.Name == name)) && (abonents.Any(ab => ab.Number == number)))
                throw new Exception("Абонент с таким именем и номером уже существует");
            else abonents.Add(new Abonent(name, number));
        }
        #endregion

        #region

        /// <summary>
        /// Удаление абонента
        /// </summary>
        public void DeleteAbonent(string nameDel)
        {
            abonents.RemoveAll(a => a.Name == nameDel);
        }
        #endregion

        #region

        /// <summary>
        /// Поиск по имени
        /// </summary>
        public List<Abonent> SearchName(string names)
        {
            var list = abonents.Where(a => a.Name.Contains(names)).ToList();

            if (list.Count == 0)
                throw new ArgumentException("Абонент не найден", nameof(names));
            return list;
        }
        #endregion

        #region

        /// <summary>
        /// Поиск по номеру
        /// </summary>
        public List<Abonent> SearhNumber(string numbers)
        {
            var list = abonents.Where(a => a.Number.Contains(numbers)).ToList();

            if (list.Count == 0)
                throw new ArgumentException("Абонент не найден", nameof(numbers));
            return list;
        }
        #endregion

        #region

        /// <summary>
        /// Запись всех абонентов в файл, после закрытия программы
        /// </summary>
        public void WriteFile()
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
