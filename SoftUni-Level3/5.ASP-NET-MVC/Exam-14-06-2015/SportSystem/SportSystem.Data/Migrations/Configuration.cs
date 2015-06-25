namespace SportSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using SportSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SportSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "SportSystem.Data.SportSystemDbContext";
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SportSystemDbContext context)
        {
            //var teams =
            //    new List<Team>
            //    {
            //        new Team
            //        {
            //            DateFounded = new DateTime(1878, 6, 1),
            //            Name = "Manchester United F.C.",
            //            NickName = "The Red Devils",
            //            WebSite = "http://www.manutd.com"
            //        },
            //        new Team
            //        {
            //            DateFounded = new DateTime(1902, 3, 6),
            //            Name = "Real Madrid",
            //            NickName = "The Whites",
            //            WebSite = "http://www.realmadrid.com"
            //        },
            //        new Team
            //        {
            //            DateFounded = new DateTime(1899, 11, 12),
            //            Name = "FC Barcelona",
            //            NickName = "Barca",
            //            WebSite = "http://www.fcbarcelona.com"
            //        },
            //        new Team
            //        {
            //            DateFounded = new DateTime(1900, 2, 13),
            //            Name = "Bayern Munich",
            //            NickName = "The Bavarians",
            //            WebSite = "http://www.fcbayern.de"
            //        },
            //        new Team
            //        {
            //            DateFounded = new DateTime(1880, 5, 1),
            //            Name = "Manchester City",
            //            NickName = "The Citizens",
            //            WebSite = "http://www.mcfc.com"
            //        },
            //        new Team
            //        {
            //            DateFounded = new DateTime(1905, 3, 10),
            //            Name = "Chelsea",
            //            NickName = "The Pensioners",
            //            WebSite = "https://www.chelseafc.com"
            //        },
            //        new Team
            //        {
            //            DateFounded = new DateTime(1886, 9, 1),
            //            Name = "Arsenal",
            //            NickName = "The Gunners",
            //            WebSite = "http://www.arsenal.com"
            //        }
            //    };

            //foreach (var team in teams)
            //{
            //    context.Teams.Add(team);
            //}

            //context.SaveChanges();

            //var matches =
            //    new List<Match>
            //    {
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 13),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Real Madrid"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Manchester United F.C.")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 14),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Bayern Munich"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Manchester United F.C.")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 15),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "FC Barcelona"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Manchester City")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 16),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Chelsea"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "FC Barcelona")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 17),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Real Madrid"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Manchester City")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 18),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Manchester United F.C."),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Chelsea")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 12),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Arsenal"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Bayern Munich")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 11),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Chelsea"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Real Madrid")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 10),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Chelsea"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Manchester City")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 19),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Chelsea"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "Arsenal")
            //        },
            //        new Match
            //        {
            //             MatchDate = new DateTime(2015, 6, 20),
            //             HomeTeam = context.Teams.FirstOrDefault(x => x.Name == "Arsenal"),
            //             AwayTeam = context.Teams.FirstOrDefault(x => x.Name == "FC Barcelona")
            //        }
            //    };

            //foreach (var match in matches)
            //{
            //    context.Matches.Add(match);
            //}

            //context.SaveChanges();

            //var players =
            //    new List<Player>
            //    {
            //        new Player
            //        {
            //            Name = "Alexis Sanchez",
            //            BirthDate = new DateTime(1982, 1, 3),
            //            Height = 1.65f,
            //            Team = context.Teams.FirstOrDefault(x => x.Name == "FC Barcelona")
            //        },
            //        new Player
            //        {
            //            Name = "Arjen Robben",
            //            BirthDate = new DateTime(1982, 1, 3),
            //            Height = 1.65f,
            //            Team = context.Teams.FirstOrDefault(x => x.Name == "Real Madrid")
            //        },
            //        new Player
            //        {
            //            Name = "Franck Ribery",
            //            BirthDate = new DateTime(1982, 1, 3),
            //            Height = 1.65f,
            //            Team = context.Teams.FirstOrDefault(x => x.Name == "Manchester United F.C.")
            //        },
            //        new Player
            //        {
            //            Name = "Wayne Rooney",
            //            BirthDate = new DateTime(1982, 1, 3),
            //            Height = 1.65f,
            //            Team = context.Teams.FirstOrDefault(x => x.Name == "Manchester United F.C.")
            //        },
            //        new Player
            //        {
            //            Name = "Lionel Messi",
            //            BirthDate = new DateTime(1982, 1, 13),
            //            Height = 1.65f
            //        },
            //        new Player
            //        {
            //            Name = "Theo Walcott",
            //            BirthDate = new DateTime(1983, 2, 17),
            //            Height = 1.75f
            //        },
            //        new Player
            //        {
            //            Name = "Cristiano Ronaldo",
            //            BirthDate = new DateTime(1984, 3, 16),
            //            Height = 1.85f
            //        },
            //        new Player
            //        {
            //            Name = "Aaron Lennon",
            //            BirthDate = new DateTime(1985, 4, 15),
            //            Height = 1.95f
            //        },
            //        new Player
            //        {
            //            Name = "Gareth Bale",
            //            BirthDate = new DateTime(1986, 5, 14),
            //            Height = 1.90f
            //        },
            //        new Player
            //        {
            //            Name = "Antonio Valencia",
            //            BirthDate = new DateTime(1987, 5, 23),
            //            Height = 1.82f
            //        },
            //        new Player
            //        {
            //            Name = "Robin van Persie",
            //            BirthDate = new DateTime(1988, 6, 13),
            //            Height = 1.84f
            //        },
            //        new Player
            //        {
            //            Name = "Ronaldinho",
            //            BirthDate = new DateTime(1989, 7, 30),
            //            Height = 1.87f
            //        },
            //    };

            //foreach (var player in players)
            //{
            //    context.Players.Add(player);
            //}

            //context.SaveChanges();

            //var passwordHash = new PasswordHasher();
            //var passwordForAlex = passwordHash.HashPassword("12qw!@QW");
            //var passwordForTanya = passwordHash.HashPassword("P@ssW0RD!123");

            //var users =
            //    new List<User>
            //    {
            //        new User
            //        {
            //            UserName = "alex@usa.net",
            //            Email = "alex@usa.net",
            //            PasswordHash =  passwordForAlex
            //        },
            //        new User
            //        {
            //            UserName = "tanya@gmail.com",
            //            Email = "tanya@gmail.com",
            //            PasswordHash = passwordForTanya
            //        }
            //    };

            //try
            //{
            //    //foreach (var user in users)
            //    //{
            //    //    context.Users.Add(user);
            //    //}

            //    //context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //        }
            //    }
            //}

            //var comments =
            //    new List<Comment>
            //    {
            //        new Comment
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Bayern Munich" && 
            //                x.AwayTeam.Name == "Manchester United F.C."),
            //            Content = "The best match this summer!",
            //            User = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net"),
            //            DateCommented = new DateTime(2016, 3, 5)
            //        },
            //        new Comment
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Bayern Munich" && 
            //                x.AwayTeam.Name == "Manchester United F.C."),
            //            Content = "The good football this evening.",
            //            User = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com"),
            //            DateCommented = new DateTime(2016, 3, 6)
            //        },
            //        new Comment
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "FC Barcelona" && 
            //                x.AwayTeam.Name == "Manchester City"),
            //            Content = "Barca!",
            //            User = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com"),
            //            DateCommented = new DateTime(2016, 3, 7)
            //        },
            //        new Comment
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Real Madrid" && 
            //                x.AwayTeam.Name == "Manchester City"),
            //            Content = "Real forever!",
            //            User = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net"),
            //            DateCommented = new DateTime(2016, 3, 8)
            //        },
            //        new Comment
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Real Madrid" && 
            //                x.AwayTeam.Name == "Manchester City"),
            //            Content = "Real, real, real",
            //            User = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net"),
            //            DateCommented = new DateTime(2016, 3, 9)
            //        },
            //        new Comment
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Real Madrid" && 
            //                x.AwayTeam.Name == "Manchester City"),
            //            Content = "Real again :)",
            //            User = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net"),
            //            DateCommented = new DateTime(2016, 3, 10)
            //        },
            //        new Comment
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Chelsea" && 
            //                x.AwayTeam.Name == "Real Madrid"),
            //            Content = "Chelsea champion!",
            //            User = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com"),
            //            DateCommented = new DateTime(2016, 3, 11)
            //        },
            //    };

            //foreach (var comment in comments)
            //{
            //    if (comment != null)
            //    {
            //        context.Comments.Add(comment);
            //    }
            //}

            //context.SaveChanges();

            //var bets =
            //    new List<Bet>
            //    {
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Chelsea" &&
            //            x.AwayTeam.Name == "FC Barcelona"),
            //            HomeTeamBet = 30.00m,
            //            AwayTeamBet = 0.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net").Id
            //        },
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Chelsea" &&
            //            x.AwayTeam.Name == "FC Barcelona"),
            //            HomeTeamBet = 0.00m,
            //            AwayTeamBet = 50.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net").Id
            //        },
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Chelsea" &&
            //            x.AwayTeam.Name == "FC Barcelona"),
            //            HomeTeamBet = 0.00m,
            //            AwayTeamBet = 120.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net").Id
            //        },
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "FC Barcelona" &&
            //            x.AwayTeam.Name == "Manchester City"),
            //            HomeTeamBet = 120.00m,
            //            AwayTeamBet = 0.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net").Id
            //        },
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Bayern Munich" &&
            //            x.AwayTeam.Name == "Manchester United F.C."),
            //            HomeTeamBet = 500.00m,
            //            AwayTeamBet = 0.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net").Id
            //        },
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Bayern Munich" &&
            //            x.AwayTeam.Name == "Manchester United F.C."),
            //            HomeTeamBet = 50.00m,
            //            AwayTeamBet = 0.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com").Id
            //        },
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Bayern Munich" &&
            //            x.AwayTeam.Name == "Manchester United F.C."),
            //            HomeTeamBet = 0.00m,
            //            AwayTeamBet = 20.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com").Id
            //        },
            //        new Bet
            //        {
            //            Match = context.Matches.FirstOrDefault(x => x.HomeTeam.Name == "Chelsea" &&
            //            x.AwayTeam.Name == "FC Barcelona"),
            //            HomeTeamBet = 0.00m,
            //            AwayTeamBet = 220.00m,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com").Id
            //        }
            //    };

            //foreach (var bet in bets)
            //{
            //    if (bet != null)
            //    {
            //        context.Bets.Add(bet);
            //    }
            //}

            //context.SaveChanges();

            //var votes =
            //    new List<Vote>
            //    {
            //        new Vote
            //        {
            //            TeamId = context.Teams.FirstOrDefault(x => x.Name == "Bayern Munich").Id,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com").Id
            //        },
            //        new Vote
            //        {
            //            TeamId = context.Teams.FirstOrDefault(x => x.Name == "Real Madrid").Id,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "tanya@gmail.com").Id
            //        },
            //        new Vote
            //        {
            //            TeamId = context.Teams.FirstOrDefault(x => x.Name == "Bayern Munich").Id,
            //            UserId = context.Users.FirstOrDefault(x => x.UserName == "alex@usa.net").Id
            //        }
            //    };

            //foreach (var vote in votes)
            //{
            //    if (vote != null)
            //    {
            //        context.Votes.Add(vote);
            //    }
            //}

            //context.SaveChanges();

        }
    }
}