namespace FearAndHunger2Wiki.Models
{
    public class Artykul
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string WygladUrl { get; set; } // Nazwa pliku w katalogu img lub pełny URL
        public string Tresc { get; set; }
    }
}
