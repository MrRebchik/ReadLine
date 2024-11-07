using Microsoft.EntityFrameworkCore;
using ReadLine.Models.People;

namespace ReadLine.Models
{
    public static class SeedMainData
    {
        public static void SeedMainDatabase(MainDataContext context)
        {
            context.Database.Migrate();
            if(context.Books.Count() == 0 && context.Authors.Count() == 0 && context.Categories.Count() == 0 && context.Tags.Count() == 0 && context.Users.Count() == 0)
            {
                Category c1 = new Category() { Name = "Художественная литература"};
                Category c2 = new Category() { Name = "Наука" };
                Category c3 = new Category() { Name = "Кулинария" };
                Tag t1 = new Tag() { Name = "Звезды" };
                Tag t2 = new Tag() { Name = "Спортивный роман" };
                Tag t3 = new Tag() { Name = "IT" };
                Author a1 = new Author() { Name = "Robin", Surname = "Martin" };
                Author a2 = new Author() { Name = "Сола", Surname = "Рэйн" };
                Author a3 = new Author() { Name = "Константин", Surname = "Ивлев", Patronymic ="Витальевич" };
                Book b1 = new Book
                {
                    Title = "Чистая архитектура. Исуусство разработки программного обеспечения.",
                    Category = c2,
                    Author = a1,
                    AgeLimit = AgeLimit.Age_16,
                    PublishFormat = PublishFormat.Paper | PublishFormat.EBook,
                    PagesCount = 352,
                    PublicationYear = 2018,
                    Publisher = "Питер"
                };
                Book b2 = new Book
                {
                    Title = "Тачдаун",
                    Category = c1,
                    Author = a2,
                    AgeLimit = AgeLimit.Age_18,
                    PublishFormat = PublishFormat.Paper | PublishFormat.EBook | PublishFormat.AudioBook,
                    PagesCount = 384,
                    PublicationYear = 2024,
                    Publisher = "АСТ"
                };
                Book b3 = new Book
                {
                    Title = "Первая кулинарная книга маленького шефа",
                    Category = c3,
                    Author = a3,
                    AgeLimit = AgeLimit.Age_12,
                    PublishFormat = PublishFormat.Paper | PublishFormat.EBook,
                    PagesCount = 104,
                    PublicationYear = 2024,
                    Publisher = "АСТ"
                };

                context.Books.AddRange(b1, b2, b3);
                context.Authors.AddRange(a1, a2, a3);
                context.Categories.AddRange(c1, c2, c3);
                context.Tags.AddRange(t1, t2, t3);
                context.BookTags.AddRange(
                    new BookTag
                    {
                        Book = b1,
                        Tag = t3
                    },
                    new BookTag
                    {
                        Book = b2,
                        Tag = t2
                    },
                    new BookTag
                    {
                        Book = b3,
                        Tag = t1
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
