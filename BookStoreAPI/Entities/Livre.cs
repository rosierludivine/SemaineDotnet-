namespace BookStoreAPI.Entities
{
    public class Livre
    {


        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }
        public required string Name { get; init; }
        public int Annee { get; set; }

    }
}