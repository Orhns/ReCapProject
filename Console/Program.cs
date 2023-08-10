using Business.Concrete;
using Core.Utilities.Results;
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
        //UpdateCar(new Car { Id = 5, CarName = "Mustang", BrandId = 4, ColorId = 2, DailyPrice = 8000, Description = "Araba 5", ModelYear = 2019 });
        //DeleteCarList();
        DeleteCar(8);
        //GetDetailsTest();

        //BrandTest();
        //AddCar();

    }

    private static void DeleteCar(int id)
    {
        CarManager manager = new CarManager(new EfCarDal());
        Console.WriteLine("Deleting a car-----------------");
        var result = manager.DeleteCar(manager.GetAll().Data.SingleOrDefault(c=>c.Id == id));
        Console.WriteLine(result.Message);
        Console.WriteLine("///////////// Current List ///////////////");
        manager.PrintTheList();
    }

    private static void AddCar()
    {
        //Tablolara veri eklerken ID'leri manuel olarak set ettiğimiz için hata veriyor.
        CarManager carManager = new CarManager(new EfCarDal());
        var addingAct = carManager.AddNewCar(new Car { BrandId = 1, ColorId = 2, CarName = "TEST", DailyPrice = 1111111, ModelYear = 2020, Description = "TEST", Id = 8 });

        Console.WriteLine(addingAct.Message.ToString());

        Console.WriteLine("///////////// Current List ///////////////");
        carManager.PrintTheList();
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

        var result = carManager.GetCarDetails();
        
        if (result.Success)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }

    }

    private static void DeleteCarList()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        Console.WriteLine("Deleting a car-----------------");
        List<Car> carlist = carManager.GetAll().Data;
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 1));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 2));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 3));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 4));
        carManager.DeleteCar(carlist.SingleOrDefault(c => c.Id == 5));
        carManager.PrintTheList();
    }

    private static void UpdateCar(Car car)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        Console.WriteLine("Updating a car-----------------");
        var updateAct = carManager.UpdateCar(car);
        Console.WriteLine(updateAct.Message.ToString());

        Console.WriteLine("///////////// Current List ///////////////");
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
        carManager.AddNewCar(new Car { Id = 5, CarName = "Mustang", BrandId = 4, ColorId = 2, DailyPrice = 8000, Description = "Araba 5", ModelYear = 2019 });
        carManager.PrintTheList();
    }

}