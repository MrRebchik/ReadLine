using Microsoft.EntityFrameworkCore;
using ReadLine.Models.People;

namespace ReadLine.Models
{
    public static class SeedModerateData
    {
        public static void SeedModerateDatabase(ModerateDataContext context)
        {
            context.Database.Migrate();
            if (context.Moderators.Count() == 0 && context.ModereteRequests.Count() == 0)
            {
                ModereteRequest m1 = new ModereteRequest() { BookTitle = "Внедрение зависимостей на платформе .NET", ApproveResourceLink = "https://habr.com/ru/companies/piter/articles/545252/" };
                context.Add(m1);
                context.SaveChanges();
            }
        }
    }
}
