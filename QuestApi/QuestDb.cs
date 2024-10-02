namespace QuestApi
{
    using Microsoft.EntityFrameworkCore;
    public class QuestDb : DbContext
    {
        public QuestDb(DbContextOptions options) : base(options){}

        public DbSet<Quest> Quests => Set<Quest>();
    }
}
