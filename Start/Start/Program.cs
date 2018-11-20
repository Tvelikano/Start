using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RecordList));
            RecordList records = new RecordList();

            
            using (FileStream fs = new FileStream("records.xml", FileMode.OpenOrCreate))
            {
                records = (RecordList)serializer.Deserialize(fs);
                
                foreach (Record rec in records.list.OrderByDescending(rc => rc.CreateDate).Take(3))
                {
                    Console.WriteLine($"{rec.Head}\n{rec.Content}\nДата создания записи {rec.CreateDate}\n");
                }
            }

            using (FileStream fs = new FileStream("records.xml", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Введите заголовок записи");
                string head = Console.ReadLine();
                Console.WriteLine("Введите содержимое записи");
                string content = Console.ReadLine();
                Record newRecord = new Record(head, content);
                records.list.Add(newRecord);
                serializer.Serialize(fs, records);
                Console.WriteLine("Запись добавлена");
            }

            Console.ReadKey();
        }
    }
}
