namespace FearAndHunger2Wiki.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string WygladUrl { get; set; } // np. "rycerz.jpg"
        public string Wiek { get; set; }
        public string Alias { get; set; }
        public string Fabula { get; set; } // Opcjonalne
    }
}
