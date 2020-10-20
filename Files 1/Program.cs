using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //глобальные переменные, которые будем использовать и в чтении, и в записи
            string Row1 = "";
            string Row2 = "";
            string Row3 = "";
            string ID1 = "";
            string ID2 = "";
            string ID3 = "";
            string PassportNumber1 = "";
            string PassportNumber2 = "";
            string PassportNumber3 = "";
            decimal Payment1 = 0;
            decimal Payment2 = 0;
            decimal Payment3 = 0;

            //читаем файл
            string ReadPath = @"C:\SomeDir\newdoc.txt";
            using (StreamReader sr = new StreamReader(ReadPath))
            {
                Row1 = sr.ReadLine();

                ID1 = Row1.Substring(0, Row1.IndexOf(";"));
                Console.WriteLine(ID1);

                PassportNumber1 = Row1.Substring(Row1.IndexOf(";") + 2, Row1.IndexOf(";") + 8);
                Console.WriteLine(PassportNumber1);

                string row1column3 = Row1.Substring(Row1.LastIndexOf(";") + 2);
                Payment1 = Convert.ToDecimal(row1column3);
                Console.WriteLine(Payment1);


                Row2 = sr.ReadLine();

                ID2 = Row2.Substring(0, Row2.IndexOf(";"));
                Console.WriteLine(ID2);

                PassportNumber2 = Row2.Substring(Row2.IndexOf(";") + 2, Row2.IndexOf(";") + 8);
                Console.WriteLine(PassportNumber2);

                string row2column3 = Row2.Substring(Row2.LastIndexOf(";") + 2);
                Payment2 = Convert.ToDecimal(row2column3);
                Console.WriteLine(Payment2);

                Row3 = sr.ReadLine();

                ID3 = Row3.Substring(0, Row3.IndexOf(";"));
                Console.WriteLine(ID3);

                PassportNumber3 = Row3.Substring(Row3.IndexOf(";") + 2, Row3.IndexOf(";") + 8);
                Console.WriteLine(PassportNumber3);

                string row3column3 = Row3.Substring(Row3.LastIndexOf(";") + 2);
                Payment3 = Convert.ToDecimal(row3column3);
                Console.WriteLine(Payment3);
            }
            Client FirstClient = new Client(ID1, PassportNumber1, Payment1);
            Client SecondClient = new Client(ID2, PassportNumber2, Payment2);
            Client ThirdClient = new Client(ID3, PassportNumber3, Payment3);

            //записываем в новый файл (базовые элементы + измененная версия элементов) 
            string WritePath = @"C:\SomeDir\ChangedDoc.txt";
            using (StreamWriter sw = new StreamWriter(WritePath, true, System.Text.Encoding.Default))
            {
                Console.WriteLine("\nВерсия после записи:\n");
                string[] a = new string[] { FirstClient.NewId(), FirstClient.Passport(), FirstClient.Sum() };
                foreach (string b in a)
                {
                    sw.WriteLine(b);
                    Console.WriteLine(b);
                }
                string[] c = new string[] { SecondClient.NewId(), SecondClient.Passport(), SecondClient.Sum() };
                foreach (string b in c)
                {
                    sw.WriteLine(b);
                    Console.WriteLine(b);
                }
                string[] d = new string[] { ThirdClient.NewId(), ThirdClient.Passport(), ThirdClient.Sum() };
                foreach (string b in d)
                {
                    sw.WriteLine(b);
                    Console.WriteLine(b);
                }
            }
            Console.WriteLine("\nКонец");
            Console.ReadKey();
        }
    }
    public class Client
    {
        public string ID { get; set; }
        public string PassportNumber { get; set; }
        public decimal Payment { get; set; }
        public Client() { }
        public Client(string id, string passportnumber, decimal payment)
        {
            ID = id;
            PassportNumber = passportnumber;
            Payment = payment;
        }
        public string Sum()
        {
            Payment = Payment + 16;
            return Convert.ToString(Payment);
        }
        public string NewId()
        {
            return ID;
        }
        public string Passport()
        {
            return PassportNumber;
        }
    }
}


