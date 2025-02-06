using WebApplication1.models;
using System.IO;
using Newtonsoft.Json; // דורש התקנה של NuGet package: Newtonsoft.Json
using System.Collections.Generic;
using System.Linq;
namespace WebApplication1.Repository
{
    public class ClientRepository : IClientRepository
    {
        private static readonly List<Client> _clients;

        static ClientRepository()
        {
            // קריאת נתוני הלקוחות מקובץ JSON
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "clients.json");
            var jsonData = File.ReadAllText(filePath);
            _clients = JsonConvert.DeserializeObject<List<Client>>(jsonData);
        }

        public Client GetClientById(int id) => _clients.FirstOrDefault(c => c.Id == id);
    }
}
