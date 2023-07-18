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
        Console.WriteLine("Adding new cars-----------------");
        carManager.AddNewCar(new Car { Id = 1, CarName = "Kia", BrandId = 2, ColorId = 1, DailyPrice = 2500, Description = "Araba 1", ModelYear = 2013 });
        carManager.AddNewCar(new Car { Id = 2, CarName = "Opel", BrandId = 1, ColorId = 3, DailyPrice = 10000, Description = "Araba 2", ModelYear = 2023 });
        carManager.AddNewCar(new Car { Id = 3, CarName = "Toyota", BrandId = 5, ColorId = 8, DailyPrice = 1500, Description = "Araba 3", ModelYear = 2015 });
        carManager.AddNewCar(new Car { Id = 4, CarName = "Toyota2", BrandId = 5, ColorId = 2, DailyPrice = 8000, Description = "Araba 4", ModelYear = 2019 });
        carManager.AddNewCar(new Car { Id = 5, CarName = "Mustang", BrandId = 3, ColorId = 2, DailyPrice = 8000, Description = "Araba 4", ModelYear = 2019 });
        carManager.PrintTheList();
        Console.WriteLine("Updating a car-----------------");
        carManager.UpdateCar(new Car { Id = 5, CarName = "Mst", DailyPrice = 99999999, Description = "Araba 5", ModelYear = 2023 });
        carManager.PrintTheList();
        //Console.WriteLine("Deleting a car-----------------");
        //List<Car> carlist = carManager.GetAll();
        //carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 1));
        //carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 2));
        //carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 3));
        //carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 4));
        //carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 5));
        //carManager.PrintTheList();
    }
}