using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Practic_6
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла, который нужно прочесть");
            string pathtofile = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Нажмите F1 чтобы сохранить файл");
            Console.WriteLine(Preobrazovanie.ConvertToText(pathtofile));
            while (true) {
                if (Console.ReadKey().Key == ConsoleKey.F1)
                {
                    break;
                };
            }
            Console.Clear();
            Console.WriteLine("Введите путь для файла, который вы хотите сохранить");
            string waytovisit = Console.ReadLine();
            Preobrazovanie.SaveFile(pathtofile, waytovisit);
            Console.Clear();
            Console.WriteLine("Сохранено!");

        }
    }
}