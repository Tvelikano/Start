using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RecordList));
            RecordList records = new RecordList();

            ReadRecords(ref records, serializer);
            WriteRecord(records, serializer);

            Console.ReadKey();
        }

        static void ReadRecords(ref RecordList records, XmlSerializer serializer)
        {
            using (FileStream fs = new FileStream("records.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    records = (RecordList) serializer.Deserialize(fs);
                    Console.WriteLine($"Всего записей: {records.list.Count()}");

                    foreach (Record rec in records.list.OrderByDescending(rc => rc.CreateDate).Take(3))
                    {
                        Console.WriteLine($"{rec.Head}\nДата создания записи: {rec.CreateDate}\n");
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("В списке нет записей");
                }
            }
        }

        static void WriteRecord(RecordList records, XmlSerializer serializer)
        {
            using (FileStream fs = new FileStream("records.xml", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Добавить новую запись\nВведите заголовок записи:");
                string head = Console.ReadLine();
                Console.WriteLine("Введите содержимое записи:");
                string content = Console.ReadLine();
                Record newRecord = new Record(head, content);
                records.list.Add(newRecord);
                serializer.Serialize(fs, records);
                Console.WriteLine("Запись добавлена");
            }
        }
    }
}
