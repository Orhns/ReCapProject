using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            if (car.CarName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Daily Price must be greater than zero.");
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails().ToList();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void PrintTheList()
        {
            List<Car> listToPrint = _carDal.GetAll();
            foreach (var item in listToPrint)
            {
                Console.WriteLine("Araç ID: " + item.Id + " || Desctiption: " + item.Description + " || Price: " + item.DailyPrice);
            }
        }

        public void UpdateCar(Car car)
        {
            if (car.CarName.Length < 2)
            {
                Console.WriteLine("The Car Name must have minimum 2 character.");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Daily Price must be greater than zero.");
            }
            else
            {
                _carDal.Update(car);
            }
        }
    }
}
