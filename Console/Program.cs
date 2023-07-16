using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());
        List<Car> list1 = carManager.GetAll();
        foreach (var item in list1)
        {
            Console.WriteLine(item.BrandId + " " + item.Description + item.DailyPrice);
        }
    }
}