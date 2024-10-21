using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FearAndHunger2Wiki.Models;

namespace FearAndHunger2Wiki.Repositories
{
    public class JsonFileArtykulyRepository
    {
        private readonly string _filePath;

        public JsonFileArtykulyRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Artykul> GetArtykuly()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Artykul>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Artykul>>(json);
        }

        public void SaveArtykuly(List<Artykul> artykuly)
        {
            var json = JsonSerializer.Serialize(artykuly);
            File.WriteAllText(_filePath, json);
        }
    }
}
