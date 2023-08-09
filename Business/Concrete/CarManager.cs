using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult AddNewCar(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new Result(false, "The Car Name must have minimum 2 character.");
            }
            else if (car.DailyPrice <= 0)
            {
                return new Result(false, "Daily Price must be greater than zero.");
            }
            else
            {
                _carDal.Add(car);
                return new Result(true, "Car added");
            }
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Car deleted");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(), true);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new DataResult<Car>(_carDal.Get(c => c.Id == carId),true);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails().ToList(),true);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),true);
        }

        public void PrintTheList()
        {
            List<Car> listToPrint = _carDal.GetAll();
            foreach (var item in listToPrint)
            {
                Console.WriteLine("Araç ID: " + item.Id + " || Desctiption: " + item.Description + " || Price: " + item.DailyPrice);
            }
        }

        public IResult UpdateCar(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new Result(false, "The Car Name must have minimum 2 character.");
            }
            else if (car.DailyPrice <= 0)
            {
                return new Result(false, "Daily Price must be greater than zero.");
            }
            else
            {
                _carDal.Update(car);
                return new Result(true, "Car info updated successfully.");
            }
        }
    }
}
