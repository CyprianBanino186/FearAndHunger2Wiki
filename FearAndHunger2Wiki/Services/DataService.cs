using FearAndHunger2Wiki.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FearAndHunger2Wiki.Services
{
    public class DataService
    {
        private const string FilePath = "Data/Articles.json";

        public List<Artykul> LoadArticles()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Artykul>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Artykul>>(json) ?? new List<Artykul>();
        }

        public void SaveArticles(List<Artykul> articles)
        {
            var json = JsonConvert.SerializeObject(articles, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
