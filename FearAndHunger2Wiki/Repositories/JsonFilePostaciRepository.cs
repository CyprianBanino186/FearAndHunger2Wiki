using FearAndHunger2Wiki.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FearAndHunger2Wiki.Repositories
{
    public class JsonFilePostaciRepository
    {
        private readonly string _filePath;

        public JsonFilePostaciRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Postac> GetPostaci()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Postac>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Postac>>(json) ?? new List<Postac>();
        }

        public void SavePostaci(List<Postac> postaci)
        {
            var json = JsonSerializer.Serialize(postaci);
            File.WriteAllText(_filePath, json);
        }
    }
}
