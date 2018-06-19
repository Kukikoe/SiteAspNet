using System.Data.Entity;

namespace WebApplication.Models
{
    public class NewsContext : DbContext
    {
        public DbSet<Novelty> News { get; set; }

    }
    //public class NewsDbInitializer : DropCreateDatabaseAlways<NewsContext>
    //{
    //    protected override void Seed(NewsContext db)
    //    {
    //        db.News.Add(new Novelty { Title = "Lorem ipsum dolor", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ", Date = DateTime.Now });
    //        db.News.Add(new Novelty { Title = "Lorem ipsum", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ", Date = DateTime.Now });
    //        db.News.Add(new Novelty { Title = "Lorem ipsum dolor sit amet", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ", Date = DateTime.Now });
    //       // db.SaveChanges();
    //        base.Seed(db);
    //    }
    //}
}