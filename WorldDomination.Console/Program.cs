using WorldDomination.Core;

namespace WorldDomination.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = DBMysql.GetAccountId("1234", "676");
            System.Console.WriteLine(id);
            System.Console.ReadLine();
        }
    }
}
