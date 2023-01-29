using Microsoft.EntityFrameworkCore;

namespace EfInAction.Examples.Chapter7.ConfigRelationshipsByConvention
{
    public static class ConfigRelationshipsByConvention
    {
        public static void Main()
        {
            // AuthorBookExample();
            BookReviewExample();
        }

        /* 1) Author(principal) - Book(dependent) */
        public static void AuthorBookExample()
        {
            RemoveData();
            SeedData();

            using (var context = new Chapter7DbContext())
            {
                var book = context.Books.First();

                var authorId = context.Entry(book).Property("AuthorId").CurrentValue; // (*)
                Console.WriteLine($"AuthorId: {authorId}");

                var author = context.Authors
                    .Include(x => x.Books) // (**)
                    .First();
                context.Remove(author);
                context.SaveChanges();
            }
        }

        /* 2) Book(principal) - Review(dependent) */
        public static void BookReviewExample()
        {
            RemoveData();
            SeedData();

            using (var context = new Chapter7DbContext())
            {
                var book = context.Books.First();
                context.Remove(book); // (!)
                context.SaveChanges();
            }
        }

        public static void SeedData()
        {
            using (var context = new Chapter7DbContext())
            {
                if (!context.Authors.Any() && !context.Books.Any())
                {
                    var author = new Author
                    {
                        Name = "Stephen King",
                        Books = new List<Book> {
                            new Book { Title = "It", Reviews = new List<Review>
                            {
                                new Review { Text = "Nice Book" },
                                new Review { Text = "Bored book"}
                            }},
                            new Book { Title = "The Shining", Reviews = new List<Review>
                            {
                                new Review { Text = "Not bad"}
                            }}
                        }
                    };
                    context.Add(author);
                    context.SaveChanges();
                }
            }
        }

        public static void RemoveData()
        {
            using (var context = new Chapter7DbContext())
            {
                var authors = context.Authors.ToList();

                foreach (var author in authors)
                {
                    context.Remove(author);
                }

                var books = context.Books.ToList();

                foreach (var book in books)
                {
                    context.Remove(book);
                }

                context.SaveChanges();
            }
        }
    }
}

/*
    Настройка действия OnDelete по-умолчанию:
        - Для required relationship устанавливается Cascade
        - Для optional relationship устанавливает ClientSetNull

    --- 1) Author(principal) - Book(dependent) ---
        Book.AuthorId не указано в entity-классе, поэтому оно доступно через Shadow Property (*)
        и является nullable (optional relationship)

        При удалении Author необходимо, чтобы связанные с ним Book были отслеживаемыми(tracked), например 
    загрузив их при помощи Include (**). В таком случае EFCore установит для их Book.AuthorId значение null (ClientSetNull).
        Если связанные Book не будут отслеживаемыми, то при удалении автора будут задействованы настройки базы данных, в которых
    установлено поведение Restrict.

    --- 2) Book(principal) - Review(dependent) ---
    Review.BookId указано в entity-классе и не может быть null (required relationship)
    Удаление (!) book происходит вместе со связанными Review
*/