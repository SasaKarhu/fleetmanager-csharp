using System;
using System.Linq;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Eatech.FleetManager.ApplicationCore.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Eatech.FleetManager.UnitTests.ApplicationCore.Services.CarServiceTests
{
    public class CarGet
    {
        [Fact]
        public async void AllCars()
        {
            var options = new DbContextOptionsBuilder<FleetDbContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;

            using (var context = new FleetDbContext(options))
            {
                context.Database.EnsureDeleted();
                ICarService carService = new CarService(context);
                context.Cars.AddRange(
                new Car
                {
                    Id = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9"),
                    Make = "Make 2",
                    Model = "Malli 3",
                    Registration = "XYZ-123",
                    Year = 1998,
                    InspectionDate = new DateTime(2017, 3, 12),
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
                    InspectionDate = new DateTime(2018, 4, 11),
                    EngineSize = 2606.2,
                    EnginePower = 222
                });
                context.SaveChanges();

                var cars = (await carService.GetAll()).ToList();

                Assert.NotNull(cars);
                //Assert.NotEmpty(cars);  should be 2 in this case
                Assert.Equal(2, cars.Count);
            }

        }

        [Fact]
        public async void ExistingCardWithId()
        {

            var options = new DbContextOptionsBuilder<FleetDbContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;

            using (var context = new FleetDbContext(options))
            {
                context.Database.EnsureDeleted();
                ICarService carService = new CarService(context);
                context.Cars.AddRange(
                new Car
                {
                    Id = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9"),
                    Make = "Make 2",
                    Model = "Malli 3",
                    Registration = "XYZ-123",
                    Year = 1998,
                    InspectionDate = new DateTime(2017, 3, 12),
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
                    InspectionDate = new DateTime(2018, 4, 11),
                    EngineSize = 2606.2,
                    EnginePower = 222
                });
                context.SaveChanges();

                var carId = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9");

                var car = await carService.Get(carId);

                Assert.NotNull(car);
                Assert.Equal(carId, car.Id);
            }
        }

        [Fact]
        public async void NonExistingCardWithId()
        {
            var options = new DbContextOptionsBuilder<FleetDbContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;

            using (var context = new FleetDbContext(options))
            {
                context.Database.EnsureDeleted();
                ICarService carService = new CarService(context);
                context.Cars.AddRange(
                new Car
                {
                    Id = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9"),
                    Make = "Make 2",
                    Model = "Malli 3",
                    Registration = "XYZ-123",
                    Year = 1998,
                    InspectionDate = new DateTime(2017, 3, 12),
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
                    InspectionDate = new DateTime(2018, 4, 11),
                    EngineSize = 2606.2,
                    EnginePower = 222
                });
                context.SaveChanges();

                var carId = Guid.Parse("d9417f10-1111-1111-1111-4eba914a82a9");

                var car = await carService.Get(carId);

                Assert.Null(car);
            }
        }

        [Fact]
        public async void UpdateCarRegistration()
        {
            var options = new DbContextOptionsBuilder<FleetDbContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;

            using (var context = new FleetDbContext(options))
            {
                context.Database.EnsureDeleted();
                ICarService carService = new CarService(context);
                context.Cars.AddRange(
                new Car
                {
                    Id = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9"),
                    Make = "Make 2",
                    Model = "Malli 3",
                    Registration = "XYZ-123",
                    Year = 1998,
                    InspectionDate = new DateTime(2017, 3, 12),
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
                    InspectionDate = new DateTime(2018, 4, 11),
                    EngineSize = 2606.2,
                    EnginePower = 222
                });
                context.SaveChanges();

                var carId = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9");

                var car = await carService.Get(carId);

                car.Registration = "ABC-123";
                car = await carService.Update(car);
                context.SaveChanges();

                var car2 = await carService.Get(carId);
                Assert.NotNull(car2);

                Assert.Equal("ABC-123", car2.Registration);
            }
        }

        [Fact]
        public async void FilterWithYearMin()
        {

            var options = new DbContextOptionsBuilder<FleetDbContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;

            using (var context = new FleetDbContext(options))
            {
                context.Database.EnsureDeleted();
                ICarService carService = new CarService(context);
                context.Cars.AddRange(
                new Car
                {
                    Id = Guid.Parse("d9417f10-5c79-44a0-9137-4eba914a82a9"),
                    Make = "Make 2",
                    Model = "Malli 3",
                    Registration = "XYZ-123",
                    Year = 1998,
                    InspectionDate = new DateTime(2017, 3, 12),
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
                    InspectionDate = new DateTime(2018, 4, 11),
                    EngineSize = 2606.2,
                    EnginePower = 222
                });
                context.SaveChanges();

                var filter = new CarFilter { YearMin = 2000, YearMax = int.MaxValue };
                var cars = await carService.Search(filter);

                Assert.NotNull(cars);
                Assert.Single(cars);
            }
        }
    }
}