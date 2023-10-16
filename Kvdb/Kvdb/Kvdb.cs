using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Kvdb
{
    using DataBase = Dictionary<string, Dictionary<string, string>>;
    public class Kvdb
    {
        static DataBase? db = new DataBase();

        public static void Parse(string command)
        {
            string[] param = command.Split();
            switch (param[0])
            {
                case "put":
                    if (param.Length == 3)
                    {
                        Console.WriteLine($"{(db != null && db[""].ContainsKey(param[1]) ? db[""][param[1]] : "")}");
                        db[""][param[1]] = param[2];
                    }

                    if (param.Length == 4)
                    {
                        Console.WriteLine(
                            $"{(db != null && db[param[1]].ContainsKey(param[2]) ? db[param[1]][param[2]] : "")}");
                        db[param[1]][param[2]] = param[3];
                    }

                    break;
                case "get":
                    if (param.Length == 2)
                    {
                        Console.WriteLine($"{(db != null && db[""].ContainsKey(param[1]) ? db[""][param[1]] : "")}");
                    }

                    if (param.Length == 3)
                    {
                        Console.WriteLine(
                            $"{(db != null && db[param[1]].ContainsKey(param[2]) ? db[param[1]][param[2]] : "")}");
                    }

                    break;
                case "remove":
                    if (param.Length == 2)
                    {
                        if (db[""].ContainsKey(param[1]))
                        {
                            Console.WriteLine(db[""][param[1]]);
                            db[""].Remove(param[1]);
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                    }

                    if (param.Length == 3)
                    {
                        if (db[param[1]].ContainsKey(param[2]))
                        {
                            Console.WriteLine(db[param[1]][param[2]]);
                            db[param[1]].Remove(param[2]);
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                    }

                    break;
            }
        }

        public static void Deserialize()
        {
            if (!File.Exists("data.xml"))
            {
                db = new DataBase();
                db[""] = new Dictionary<string, string>();
                return;
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(DataBase));
            FileStream file = new FileStream("data.xml", FileMode.OpenOrCreate);
            var xmlReader = XmlDictionaryReader.CreateTextReader(file, new XmlDictionaryReaderQuotas());
            db = serializer.ReadObject(xmlReader) as DataBase;
            file.Close();
            xmlReader.Close();
        }

        public static void Serialize()
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(DataBase));
            FileStream file = new FileStream("data.xml", FileMode.Create);
            var xmlWriter = XmlDictionaryWriter.CreateTextWriter(file);
            serializer.WriteObject(xmlWriter, db);
            xmlWriter.Close();
            file.Close();
        }

        public static void Main(string[] args)
        {
            Deserialize();
            string input = Console.ReadLine()!;
            Parse(input);
            Serialize();
        }
    }
}