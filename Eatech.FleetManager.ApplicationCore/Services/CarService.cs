using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eatech.FleetManager.ApplicationCore.Services
{
    public class CarService : ICarService
    {
        private readonly FleetDbContext _context;

        public CarService(FleetDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            IEnumerable<Car> cars = await _context.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car> Get(Guid id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return car;
        }

        public async Task<Car> Create(Car car)
        {
            await _context.Cars.AddAsync(car);

            if(_context.SaveChanges() == 0)
            {
                //nothing was saved, return nothing.
                return null;
            }
            else
            {
                //this should also have newly created id added by SaveChanges.
                return car;
            }

        }

        public async Task<Car> Update(Car car)
        {
            var ExistingCar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id);

            if (_context.SaveChanges() == 0)
            {
                //nothing was saved, return nothing.
                return null;
            }
            else
            {
                //Updated car data.
                return car;
            }

        }

        public async Task<bool> Delete(Car car)
        {
            _context.Cars.Remove(car);

            if (_context.SaveChanges() == 0)
            {
                //nothing was saved, return nothing.
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}