using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Kvdb
{
    public class Kvdb
    {
        static Dictionary<string,Dictionary<string,string>> db =new Dictionary<string,Dictionary<string,string>>();

        public static void Parse(string command)
        {
            string[] param = command.Split();
            switch (param[0])
            {
                case "put":
                    if (param.Length == 3 )
                    {
                        if (db[""].ContainsKey(param[1]))
                        {
                            Console.WriteLine(db[""][param[1]]);
                        }
                        else
                        {
                            Console.WriteLine("");// переписать
                        }
                        db[""][param[1]] = param[2];
                    }

                    if (param.Length == 4)
                    {
                        if (db.ContainsKey(param[1]))
                        {
                            if (db[param[1]].ContainsKey(param[2]))
                            {
                                Console.WriteLine(db[param[1]][param[2]]);
                            }
                            else
                            {
                                Console.WriteLine("");// переписать
                            }
                            db[param[1]][param[2]] = param[3];
                        }
                    }
                    
                    break;
                case "get":
                    if (param.Length == 2)
                    {
                        if (db[""].ContainsKey(param[1]))
                        {
                            Console.WriteLine(db[""][param[1]]);
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
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                        
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
            XmlSerializer formatter = new XmlSerializer(typeof(Dictionary<string, Dictionary<string, string>>));
            FileStream file = new FileStream("data.db", FileMode.OpenOrCreate);
            db = formatter.Deserialize(file) as Dictionary<string, Dictionary<string, string>> ;
            if (db == null)
            {
                db = new Dictionary<string, Dictionary<string, string>>();
                db[""] = new Dictionary<string, string>();
                
            }
            file.Close();
        }
        public static void Serialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Dictionary<string, Dictionary<string, string>>));
            FileStream file = new FileStream("data.db", FileMode.OpenOrCreate);
            formatter.Serialize(file, db);
            file.Close();
        }
        
        public static void Main(string[] args)
        {
            Deserialize();
            string input = Console.ReadLine();
            Parse(input);
            Serialize();
            
        }
    }
}
