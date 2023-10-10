using System.Runtime.CompilerServices;

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
                            Console.WriteLine("");
                        }
                        db[""][param[1]] = param[2];
                    }

                    if (param.Length == 4)
                    {
                        if (db.ContainsKey(param[1]))
                        {
                            
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
                    break;
            }
        }
        
        public static void Main(string[] args)
        {
            db[""] = new Dictionary<string, string>();
            Parse("put 25 100");
            Parse("get 27");
            Parse("remove 78");
            Parse("remove 25");
        }
    }
}
