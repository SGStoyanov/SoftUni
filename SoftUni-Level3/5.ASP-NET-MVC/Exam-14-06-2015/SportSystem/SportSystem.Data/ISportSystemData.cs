namespace SportSystem.Data
{
    using SportSystem.Data.Repositories;
    using SportSystem.Models;

    public interface ISportSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Bet> Bets { get; }
        
        IRepository<Match> Matches { get; }

        IRepository<Team> Teams { get; }

        IRepository<Player> Players { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
