namespace SportSystem.Data
{
    using System.Data.Entity;

    using SportSystem.Models;

    public interface ISportSystemDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Team> Teams { get; }

        IDbSet<Match> Matches { get; }

        IDbSet<Bet> Bets { get; }

        IDbSet<Player> Players { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Vote> Votes { get; }

        int SaveChanges();
    }
}