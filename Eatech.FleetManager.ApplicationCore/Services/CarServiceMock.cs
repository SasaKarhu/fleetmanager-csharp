using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;

namespace Eatech.FleetManager.ApplicationCore.Services
{
    public class CarServiceMock : ICarService
    {

        /// <summary>
        ///     Remove this. Temporary car storage before proper data storage is implemented.
        /// </summary>
        private static readonly ImmutableList<Car> TempCars = new List<Car>
        {
            new Car
            {
                Id = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9"),
                Make = "Make 2",
                Model = "Malli 3",
                Registration = "XYZ-123",
                Year = 1998,
                InspectionDate = new DateTime(2017,3,12),
                EngineSize = 2789.2,
                EnginePower = 235
            },
            new Car
            {
                Id = Guid.NewGuid(),
                Make = "Make 1",
                Model = "Malli 2",
                Registration = "XYZ-124",
                Year = 2003,
                InspectionDate = new DateTime(2018,4,11),
                EngineSize = 2606.2,
                EnginePower = 222
            }
        }.ToImmutableList();

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await Task.FromResult(TempCars);
        }

        public async Task<Car> Get(Guid id)
        {
            return await Task.FromResult(TempCars.FirstOrDefault(c => c.Id == id));
        }

        public async Task<Car> Create(Car car)
        {
            //temporary
            return await Task.FromResult(TempCars.FirstOrDefault(c => c.Id == car.Id));
            /*
            await _context.Cars.AddAsync(car);

            if (_context.SaveChanges() == 0)
            {
                //nothing was saved, return nothing.
                return null;
            }
            else
            {
                //this should also have newly created id added by SaveChanges.
                return car;
            }
            */
        }

        public async Task<Car> Update(Car car)
        {
            //temporary
            return await Task.FromResult(TempCars.FirstOrDefault(c => c.Id == car.Id));

        }

        public async Task<bool> Delete(Car car)
        {
            //temporary
            await Task.FromResult(TempCars.FirstOrDefault(c => c.Id == car.Id));
            return true;
                

        }

        public async Task<IEnumerable<Car>> Search(CarFilter f)
        {
            return await Task.FromResult(TempCars);
        }
    }
}