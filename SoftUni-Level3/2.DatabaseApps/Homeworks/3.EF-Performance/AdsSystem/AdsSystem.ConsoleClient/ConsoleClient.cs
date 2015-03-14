namespace AdsSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Data.Entity;

    public class ConsoleClient
    {
        public static void Main()
        {
            //// Problem 1
            //// Before Optimization

            //var adsDbContext = new AdsEntities();
            //var ads = adsDbContext.Ads;

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("Title: " + ad.Title + ", Status: " + ad.AdStatus.Status +
            //    ", Category: " + (ad.Category == null ? "(no category)" : ad.Category.Name) +
            //    ", Town: " + (ad.Town == null ? "(no town)" : ad.Town.Name) +
            //    ", User: " + ad.AspNetUser.Name);
            //}

            //// With Optimization
            //var adsDbContext2 = new AdsEntities();
            //var ads2 =
            //    adsDbContext2.Ads
            //        .Include(a => a.AdStatus)
            //        .Include(a => a.Category)
            //        .Include(a => a.Town)
            //        .Include(a => a.AspNetUser);

            //foreach (var ad in ads2)
            //{
            //    Console.WriteLine("Title: " + ad.Title + ", Status: " + ad.AdStatus.Status +
            //    ", Category: " + (ad.Category == null ? "(no category)" : ad.Category.Name) +
            //    ", Town: " + (ad.Town == null ? "(no town)" : ad.Town.Name) +
            //    ", User: " + ad.AspNetUser.Name);
            //}


            //// Problem 2
            //// Without optimization

            //var startTime = DateTime.Now;
            //var adsDbContext = new AdsEntities();
            //var ads =
            //    adsDbContext.Ads.ToList()
            //        .Where(a => a.AdStatus.Status.Equals("Published"))
            //        .Select(a => new { Title = a.Title, Category = a.Category, Town = a.Town, a.Date })
            //        .ToList()
            //        .OrderBy(a => a.Date);

            //var endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);

            //// With optimization
            //var adsDbContext = new AdsEntities();
            //var startTime = DateTime.Now;
            //var ads2 = adsDbContext.Ads
            //.Where(a => a.AdStatus.Status.Equals("Published"))
            //.Select(a => new
            //{
            //    a.Title,
            //    a.Category,
            //    a.Town
            //})
            //.ToList();
            //var endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);
            //Console.WriteLine(ads2.Count());

            //// Problem 3
            //// Without optimization

            //var startTime = DateTime.Now;
            //var adsDbContext = new AdsEntities();
            //var ads = adsDbContext.Ads;

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("Title: " + ad.Title);
            //}

            //var endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);


            //// With optimization
            //var startTime = DateTime.Now;
            //var adsDbContext = new AdsEntities();
            //var ads = adsDbContext.Ads.Select(a => a.Title);

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("Title: " + ad);
            //}

            //var endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);

        }
    }
}
