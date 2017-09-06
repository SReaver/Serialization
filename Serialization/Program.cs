using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            List<Book> lb = new List<Book>();
            Random rnd = new Random();
            for (int i = 1; i <= 20; i++)
            {
                lb.Add(new Book("Book" + i, 3 + rnd.Next(10, 20), "Author" + i * 2, rnd.Next(1920, 2017)));
            }

            //foreach (var item in lb)
            //{
            //    Console.WriteLine(item.author+" "+item.title+ " " + item.year+ " " + item.price);
            //}
            Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\doc.bin");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, lb);
            stream.Close();

            List<Book> lbbin = null;
            FileStream fsbin = new FileStream(Environment.CurrentDirectory + "\\doc.bin", FileMode.Open);
            try
            {
                BinaryFormatter binformatter = new BinaryFormatter();
                lbbin = (List<Book>)formatter.Deserialize(fsbin);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Не получилось сериализовать. Причина: " + e.Message);
            }
            finally
            {
                fsbin.Close();
            }

            foreach (var item in lbbin)
            {
                Console.WriteLine($"Название книги: {item.title}\nАвтор: \t\t{item.author}\nГод книги: \t{item.year}\nЦена: \t\t{item.price}$\n------------------------\n");
            }

            #endregion

            string path = Environment.CurrentDirectory + @"\Persons.csv";
            Person[] persons = new Person[20];
            using (var reader = new StreamReader(path))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    persons[i++]=new Person(values[0], values[1], values[2], Int32.Parse(values[3]));

                }
            }

            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item.name);
            //}

            FileStream fssoap = new FileStream(Environment.CurrentDirectory+ @"\persons.soap", FileMode.Create);

        
            SoapFormatter formattersoap = new SoapFormatter();
            try
            {
                formattersoap.Serialize(fssoap, persons);
                Console.WriteLine("Данные из файла Persons.csv сохранены в формате SOAP в " + Environment.CurrentDirectory + @"\persons.soap");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Не получилось сериализовать. Причина: " + e.Message);
                throw;
            }
            finally
            {
                fssoap.Close();
            }

        }
    }
}
