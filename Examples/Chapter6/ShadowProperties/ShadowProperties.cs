namespace EfInAction.Examples.Chapter6.ShadowProperties
{
    public static class ShadowProperties
    {
        public static void Main()
        {
            using (var context = new Chapter6DbContext())
            {
                var book = context.Books.SingleOrDefault(x => x.Title == "Shadow Book");

                if (book == null)
                {
                    book = new Book
                    {
                        Title = "Shadow Book",
                        Price = 12.0m
                    };
                    context.Add(book);
                }

                context.Entry(book).Property("LastUpdateBy").CurrentValue = "Jhon Boom";
                context.SaveChanges();
            }

            using (var context = new Chapter6DbContext())
            {
                var book = context.Books
                    // .AsNoTracking() // can't read value without tracking
                    .Single(x => x.Title == "Shadow Book");

                var spValue = context.Entry(book)
                    .Property("LastUpdateBy")
                    .CurrentValue;

                Console.WriteLine($"LastUpdateBy: {spValue}");
            }
        }
    }
}

/*
    Shadow Properties - это способ получить доступ к колонке таблицы в базе данных БЕЗ появления её свойства в entity-классе.

    Устанавливать и читать значение можно через Entry(Entity).Property("...").CurrentValue.
    Для успешного чтения нужно получать его без .AsNoTracking()
*/