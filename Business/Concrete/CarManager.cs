using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddNewCar(Car car)
        {
            _carDal.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void PrintTheList()
        {
            List<Car> listToPrint = _carDal.GetAll();
            foreach (var item in listToPrint)
            {
                Console.WriteLine("Araç ID: " +item.Id + " || Desctiption: " + item.Description + " || Price: " + item.DailyPrice);
            }
        }

        public void UpdateCar(Car car)
        {
            _carDal.Update(car);
        }
    }
}
