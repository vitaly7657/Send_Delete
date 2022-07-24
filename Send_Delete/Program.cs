using System;
using System.Threading;
using System.IO;

namespace Send_Delete
{
    internal class Program
    {
        static void Delete(int sleepTime)
        {            
            string[] deletePath = Directory.GetFiles(@"C:\700_Console\RemoteServer\send\");
            int countFiles = deletePath.Length;
            foreach (string filePath in deletePath)
                File.Delete(filePath);

            string deleteLine = $"дата удаления: {DateTime.Now.ToString()} | количество удалённых файлов: {countFiles}";
            Console.WriteLine(deleteLine);

            FileInfo info = new FileInfo(@"C:\700_Console\RemoteServer\delete_log.txt");
            if (!info.Exists)
            {
                File.WriteAllText(@"C:\700_Console\RemoteServer\delete_log.txt", deleteLine);
            }

            else if (info.Exists)
            {
                File.AppendAllText(@"C:\700_Console\RemoteServer\delete_log.txt", $"\n{deleteLine}");
            }
            Thread.Sleep(sleepTime);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(">>>ЗАПУЩЕА ПРОГРАММА УДАЛЕНИЯ БУФЕРА ПАКЕТОВ<<<");

            //Console.WriteLine("Моменты удаления содержимого папки send:" +
            //    "\n1 число, 12 часов, 00 минут" +
            //    "\n7 число, 12 часов, 00 минут" +
            //    "\n13 число, 12 часов, 00 минут" +
            //    "\n19 число, 12 часов, 00 минут" +
            //    "\n25 число, 12 часов, 00 минут");

            int sleepTime = 40000; //40000 = 40 секунд

            ////на месяц
            //string deleteMoment1 = "011200";
            //string deleteMoment2 = "071200";
            //string deleteMoment3 = "131200";
            //string deleteMoment4 = "191200";
            //string deleteMoment5 = "251200";

            //на день
            string deleteMoment1 = "2345";
            string deleteMoment2 = "2347";
            string deleteMoment3 = "2350";
            string deleteMoment4 = "1500";
            string deleteMoment5 = "1700";

            while (true)
            {
                ////на месяц
                //string nowMoment = DateTime.Now.ToString("ddHHmm");

                //на день
                string nowMoment = DateTime.Now.ToString("HHmm");
                
                if (nowMoment == deleteMoment1)
                {
                    Delete(sleepTime);                    
                }

                if (nowMoment == deleteMoment2)
                {
                    Delete(sleepTime);
                }

                if (nowMoment == deleteMoment3)
                {
                    Delete(sleepTime);
                }

                if (nowMoment == deleteMoment4)
                {
                    Delete(sleepTime);
                }

                if (nowMoment == deleteMoment5)
                {
                    Delete(sleepTime);
                }
                else
                {
                    Thread.Sleep(sleepTime);
                }
            }
            Console.ReadKey();
        }
    }
}
