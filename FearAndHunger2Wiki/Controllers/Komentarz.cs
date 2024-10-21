namespace FearAndHunger2Wiki.Models
{
    public class Komentarz
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public int ArtykulId { get; set; }
        public Artykul Artykul { get; set; }
        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}
