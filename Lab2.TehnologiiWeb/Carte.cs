namespace Lab2.TehnologiiWeb
{
    public class Carte
    {
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public int AnPublicare { get; set; }
        public string Editura { get; set; }
        public string ISBN { get; set; }

        public Carte(string titlu, string autor, int anPublicare, string editura, string isbn)
        {
            Titlu = titlu;
            Autor = autor;
            AnPublicare = anPublicare;
            Editura = editura;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"{Titlu}, {Autor}, {AnPublicare}, {Editura}, {ISBN}";
        }
    }

}
