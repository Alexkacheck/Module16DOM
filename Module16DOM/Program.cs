using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Module16DOM
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Простой Файловый Менеджер");
                Console.WriteLine("1. Просмотр содержимого директории");
                Console.WriteLine("2. Создание файла/директории");
                Console.WriteLine("3. Удаление файла/директории");
                Console.WriteLine("4. Копирование и перемещение файлов/директорий");
                Console.WriteLine("5. Чтение и запись в файл");
                Console.WriteLine("6. Логирование действий");
                Console.WriteLine("0. Выход");

                Console.Write("Выберите действие (введите номер): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите путь к директории: ");
                        string directoryPath = Console.ReadLine();
                        FileManager.ViewDirectoryContents(directoryPath);
                        break;
                    case "2":
                        Console.Write("Введите полный путь для создания файла/директории: ");
                        string path = Console.ReadLine();
                        Console.Write("Выберите тип (файл - F, директория - D): ");
                        string type = Console.ReadLine().ToUpper();
                        FileManager.CreateFileOrDirectory(path, type);
                        break;
                    case "3":
                        Console.Write("Введите полный путь к файлу/директории для удаления: ");
                        string deletePath = Console.ReadLine();
                        FileManager.DeleteFileOrDirectory(deletePath);
                        break;
                    case "4":
                        Console.Write("Введите полный путь к файлу/директории для копирования/перемещения: ");
                        string sourcePath = Console.ReadLine();
                        Console.Write("Введите полный путь назначения: ");
                        string destinationPath = Console.ReadLine();
                        Console.Write("Выберите действие (копирование - C, перемещение - M): ");
                        string action = Console.ReadLine().ToUpper();
                        FileManager.CopyOrMoveFileOrDirectory(sourcePath, destinationPath, action);
                        break;
                    case "5":
                        Console.Write("Введите полный путь к файлу для чтения/записи: ");
                        string filePath = Console.ReadLine();
                        Console.WriteLine("1. Чтение из файла");
                        Console.WriteLine("2. Запись в файл");
                        Console.Write("Выберите действие (введите номер): ");
                        string fileAction = Console.ReadLine();
                        FileManager.ReadWriteToFile(filePath, fileAction);
                        break;
                    case "6":
                        Console.WriteLine("Лог действий:");
                        Console.WriteLine(File.ReadAllText(@"C:\Users\RepublikONE\source\repos\Module16DOM\ffff.txt"));
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, выберите действие снова.");
                        break;
                }
            }
        }
    }
    
}
