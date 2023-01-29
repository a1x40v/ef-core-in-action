namespace EfInAction.Examples.Chapter7.ConfigRelationshipsByConvention
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Text { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}