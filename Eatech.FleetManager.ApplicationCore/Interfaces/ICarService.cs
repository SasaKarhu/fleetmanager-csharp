﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;

namespace Eatech.FleetManager.ApplicationCore.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAll();

        Task<Car> Get(Guid id);

        Task<Car> Create(Car c);

        Task<Car> Update(Car c);

        Task<bool> Delete(Car car);

        Task<IEnumerable<Car>> Search(CarFilter f);
    }
}