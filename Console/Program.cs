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
        //CreateCarList();
        //UpdateCars();
        //DeleteCarList();

        GetDetailsTest();

        //BrandTest();
    }

    private static void BrandTest()
    {
        EfBrandDal brandDal = new EfBrandDal();
        brandDal.Add(new Brand { Id = 7, Name = "Tesla" });
        List<Brand> brandlist = brandDal.GetAll().ToList();
        foreach (var item in brandlist)
        {
            Console.WriteLine(item.Id + " - " + item.Name);
        }
    }

    private static void GetDetailsTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
        }
    }

    private static void DeleteCarList()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        Console.WriteLine("Deleting a car-----------------");
        List<Car> carlist = carManager.GetAll();
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 1));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 2));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 3));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 4));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 5));
        carManager.PrintTheList();
    }

    private static void UpdateCars()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        Console.WriteLine("Updating a car-----------------");
        carManager.UpdateCar(new Car { Id = 5, CarName = "Mst", DailyPrice = 99999999, Description = "Araba 5", ModelYear = 2023 });
        carManager.PrintTheList();
    }

    private static void CreateCarList()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        Console.WriteLine("Adding new cars-----------------");
        carManager.AddNewCar(new Car { Id = 1, CarName = "Rio", BrandId = 2, ColorId = 1, DailyPrice = 2500, Description = "Araba 1", ModelYear = 2013 });
        carManager.AddNewCar(new Car { Id = 2, CarName = "Astra", BrandId = 1, ColorId = 3, DailyPrice = 10000, Description = "Araba 2", ModelYear = 2023 });
        carManager.AddNewCar(new Car { Id = 3, CarName = "Clio", BrandId = 5, ColorId = 8, DailyPrice = 1500, Description = "Araba 3", ModelYear = 2015 });
        carManager.AddNewCar(new Car { Id = 4, CarName = "R 5", BrandId = 5, ColorId = 2, DailyPrice = 8000, Description = "Araba 4", ModelYear = 2019 });
        carManager.AddNewCar(new Car { Id = 5, CarName = "Mustang", BrandId = 3, ColorId = 2, DailyPrice = 8000, Description = "Araba 5", ModelYear = 2019 });
        carManager.PrintTheList();
    }

}