namespace EfInAction.Examples.Chapter7.ConfigRelationshipsByConvention
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}