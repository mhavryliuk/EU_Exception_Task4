using System;
using System.Net;
using System.Diagnostics;

/** <remark>
 * Write a program that downloads a file from Internet and stores it the current directory.
 * Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.
 * 
 * Напишите программу, загружающую файл из Интернета и сохраняет его в текущем каталоге. Найти в Google, как загрузить файлы в C#. 
 * Обязательно воспользуйтесь всеми исключениями и освободите любые использованные ресурсы в блоке finally.
 </remark> */

namespace _20180306_Task4_Exception
{
    internal class Program
    {
        private static void Main()
        {
            WebClient download = new WebClient();

            Console.Write("Paste URL: ");
            string fileUrl = Console.ReadLine();           // https://i.ytimg.com/vi/1P9hLB67YqE/maxresdefault.jpg

            Console.Write("Enter path and filename: ");
            string pathAndFilename = Console.ReadLine();   // D:\photo.jpg

            try
            {
                download.DownloadFile(
                    fileUrl ?? throw new InvalidOperationException(),
                    pathAndFilename ?? throw new InvalidOperationException()
                    );

                Console.WriteLine("File downloaded.");

                Process.Start(pathAndFilename);            // Open file
                Console.WriteLine("File opened.");
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                download.Dispose();
                Console.WriteLine("Resources released.");
            }

            Console.ReadKey();
        }
    }
}