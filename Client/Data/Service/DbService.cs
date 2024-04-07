using BeleskeBlazor.Client.Data.Model;
using BeleskeBlazor.Client.Util;
using Microsoft.EntityFrameworkCore;

namespace BeleskeBlazor.Client.Data.Service
{
    public class DbService
    {
        DBConnect db = new DBConnect(new DbContextOptions<DBConnect>());

        public DbService() { }

        public DbService(string connectionString) { }

        public List<Beleska> GetBeleske()
        {
            foreach (var d in db.Beleske.ToList())
                Console.WriteLine(d);
            return new List<Beleska>();
        }
    }
}
