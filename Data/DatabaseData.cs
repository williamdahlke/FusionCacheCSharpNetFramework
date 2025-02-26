using FusionCacheCSharpNetFramework.Models;
using System.Collections.Generic;
using ZiggyCreatures.Caching.Fusion;


namespace FusionCacheCSharpNetFramework.Data
{
    public static class DatabaseData
    {
        public static List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car(){ Id = 1, Model = "C4 Lounge", Carmarker = "Citroen", Year = 2019 },
                //new Car(){ Id = 2, Model = "Prisma", Carmarker = "Chevrolet", Year = 2017 },
                //new Car(){ Id = 3, Model = "Creta", Carmarker = "Hyundai", Year = 2022 },
                //new Car(){ Id = 4, Model = "Duster", Carmarker = "Renault", Year = 2022 },
            };
        }
    }
}
