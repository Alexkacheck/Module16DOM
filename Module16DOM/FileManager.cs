using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module16DOM
{


    public class FileManager
    {
        public static void ViewDirectoryContents(string directoryPath)
        {
            try
            {
                string[] files = Directory.GetFiles(directoryPath);
                string[] directories = Directory.GetDirectories(directoryPath);

                Console.WriteLine("Файлы:");
                foreach (var file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }

                Console.WriteLine("\nДиректории:");
                foreach (var dir in directories)
                {
                    Console.WriteLine(Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void CreateFileOrDirectory(string path, string type)
        {
            try
            {
                if (type == "F")
                {
                    File.Create(path).Close();
                    Console.WriteLine("Файл успешно создан.");
                }
                else if (type == "D")
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine("Директория успешно создана.");
                }
                else
                {
                    Console.WriteLine("Некорректный выбор типа. Используйте F для файла и D для директории.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void DeleteFileOrDirectory(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("Файл успешно удален.");
                }
                else if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    Console.WriteLine("Директория успешно удалена.");
                }
                else
                {
                    Console.WriteLine("Указанный файл/директория не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void CopyOrMoveFileOrDirectory(string sourcePath, string destinationPath, string action)
        {
            try
            {
                if (action == "C")
                {
                    if (File.Exists(sourcePath))
                    {
                        File.Copy(sourcePath, destinationPath);
                        Console.WriteLine("Файл успешно скопирован.");
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        DirectoryCopy(sourcePath, destinationPath, true);
                        Console.WriteLine("Директория успешно скопирована.");
                    }
                    else
                    {
                        Console.WriteLine("Указанный файл/директория не существует.");
                    }
                }
                else if (action == "M")
                {
                    if (File.Exists(sourcePath))
                    {
                        File.Move(sourcePath, destinationPath);
                        Console.WriteLine("Файл успешно перемещен.");
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        Directory.Move(sourcePath, destinationPath);
                        Console.WriteLine("Директория успешно перемещена.");
                    }
                    else
                    {
                        Console.WriteLine("Указанный файл/директория не существует.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный выбор действия. Используйте C для копирования и M для перемещения.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void ReadWriteToFile(string filePath, string choice)
        {
            try
            {
                if (choice == "1")
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string content = sr.ReadToEnd();
                        Console.WriteLine($"Содержимое файла:\n{content}");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Введите текст для записи в файл: ");
                    string content = Console.ReadLine();

                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine(content);
                        Console.WriteLine("Текст успешно записан в файл.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный выбор действия. Введите 1 для чтения или 2 для записи.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDir, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
