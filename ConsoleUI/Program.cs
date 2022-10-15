using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(String[] args)
        {
            GetCarMethod();
            //GetBrandMethod();
        }

        private static void GetBrandMethod()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetCarMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "\t" + car.ColorName +"\t" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}