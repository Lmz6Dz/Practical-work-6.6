using System;
using System.IO;
using System.Text;

namespace Practical_work_6._6
{
    internal class Program
    {
        /// <summary>
        /// Чтение файла
        /// </summary>
        static void Read()
        {
            if (File.Exists(@"db.csv"))
            {
                using (StreamReader sr = new StreamReader("db.csv", Encoding.Unicode))
                {
                    string line;
                    Console.WriteLine($"{"ID",3} {"Дата и время добавления",24} {"Ф.И.О",30} {"Возраст",7} {"Рост",4} {"Дата рождения",13} {"Место рорждения",25}");

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('#');
                        Console.WriteLine($"{data[0],3} {data[1],24} {data[2],30} {data[3],7} {data[4],4} {data[5],13} {data[6],25}");
                    }
                }
            }
            else Console.WriteLine("Файл не существует, заполните данные");
        }

        /// <summary>
        /// Запись в файл
        /// </summary>
        static void Write()
        {
            using (StreamWriter sw = new StreamWriter("db.csv", true, Encoding.Unicode))
            {
                char key = 'д';

                do
                {
                    string note = string.Empty;
                    Console.Write("\nВведите ID: ");
                    note += $"{Console.ReadLine()}#";

                    DateTime now = DateTime.Now;
                    Console.WriteLine($"Дата и время добавления заметки: {now:g}");
                    note += $"{now:g}#";

                    Console.Write("Введите Ф.И.О.: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите Возраст: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите Рост: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write($"Введите Дату рождения в формате {DateTime.Today:d}: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите Место рождения: ");
                    note += $"{Console.ReadLine()}";

                    sw.WriteLine(note);

                    Console.WriteLine("Продожить н/д"); key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }
        }

        /// <summary>
        /// Справочник «Сотрудники»
        /// </summary>
        static void Main()
        {
            do
            {
                Console.WriteLine("\nВведите 1 - вывести данные на экран;");
                Console.WriteLine("Введите 2 — заполнить данные и добавить новую запись в конец файла.");
                Console.WriteLine("Введите 3 - Выход из программы");

                var n = Console.ReadLine();

                switch (n)
                {
                    case "1": Read(); break;

                    case "2": Write(); break;

                    case "3": return;

                    default: continue;
                }
            }
            while (true);
        }
    }
}