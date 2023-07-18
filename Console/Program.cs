using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        Console.WriteLine("Default car list ----------------");
        carManager.PrintTheList();
        //Console.WriteLine("Adding a new car-----------------");
        //carManager.AddNewCar(new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 250000, Description = "Araba 1", ModelYear = 2023 });
        //carManager.PrintTheList();
        //Console.WriteLine("Updating a car-----------------");
        //carManager.UpdateCar(new Car { Id = 1, BrandId = 5, ColorId = 5, DailyPrice = 99999999, Description = "Araba 5", ModelYear = 2023 });
        //carManager.PrintTheList();
        Console.WriteLine("Deleting a car-----------------");
        List<Car> carlist = carManager.GetAll();
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 1));
        carManager.PrintTheList();
    }
}