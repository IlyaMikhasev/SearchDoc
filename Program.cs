using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDoc
{
    internal class Program
    {
        static (string[] arr, DateTime date) InputValidation() {
            string path = string.Empty;
            string[] strFile = new string[30];
            DateTime dateStart=DateTime.Now;
            bool correctIn = false;
            do
            {
                correctIn = false;
                Console.WriteLine("Введите дату, с которой начинать поиск в формате ГГГГ.ММ.ДД");
                try
                {
                    string dateInput = Console.ReadLine();
                    var tmp = dateInput.Split(',', '.', '\\', '/');
                    dateStart = new DateTime(int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2]));
                    correctIn = true;
                }
                catch
                {
                    Console.WriteLine("Неккоректный ввод даты");
                }
            } while (!correctIn);
            do
            {
                correctIn = false;
                Console.WriteLine("Введите путь к файлу с индификаторами");
                try
                {
                    path = Console.ReadLine();
                    StreamReader reader = new StreamReader(path);
                    strFile = reader.ReadToEnd().Split(' ', '\r', '\n', '\0');
                    correctIn = true;
                }
                catch
                {
                    Console.WriteLine("Неккоректный путь к файлу");
                }
            } while (!correctIn);
            return (strFile, dateStart);

        }
        static void Main(string[] args)
        {
            SearchFile searchFile = new SearchFile(InputValidation());
            string pathFile = searchFile.SearchFilePath();
            if (pathFile != string.Empty)
                Console.WriteLine($"путь к вашему файлу {pathFile}");
            else
                Console.WriteLine("файл не найден");
        }
    }
}
