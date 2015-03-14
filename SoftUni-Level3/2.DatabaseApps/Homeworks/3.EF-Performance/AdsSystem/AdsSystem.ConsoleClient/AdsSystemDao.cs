namespace AdsSystem.Data
{
    using System;
    using System.Linq;

    public static class AdsSystemDao
    {
        private static readonly AdsEntities AdsDbContext = new AdsEntities();

        public static void GetAllAds()
        {
            var ads = from a in AdsDbContext.Ads 
                      select new
                      {
                         a.Title,
                         a.AdStatus,
                         a.Category,
                         a.Town,
                         a.AspNetUser
                      };

            foreach (var ad in ads)
            {
                Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", ad.Title, ad.AdStatus, ad.Category, ad.Town, ad.AspNetUser);
            }
        }


    }
}
