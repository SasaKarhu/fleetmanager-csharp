using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eatech.FleetManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        ///     Example HTTP GET: api/car
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get()
        {
            return (await _carService.GetAll()).Select(car => new CarDto
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Registration = car.Registration,
                Year = car.Year,
                InspectionDate = car.InspectionDate,
                EngineSize = car.EngineSize,
                EnginePower = car.EnginePower
            });
        }

        /// <summary>
        ///     Example HTTP GET: api/car/570890e2-8007-4e5c-a8d6-c3f670d8a9be
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var car = await _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(new CarDto
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Registration = car.Registration,
                Year = car.Year,
                InspectionDate = car.InspectionDate,
                EngineSize = car.EngineSize,
                EnginePower = car.EnginePower
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CarDto inputcar)
        {
            if(inputcar == null)
            {
                return BadRequest();
            }

            var car = await _carService.Create(new Car
            {
                Make = inputcar.Make,
                Model = inputcar.Model,
                Registration = inputcar.Registration,
                Year = inputcar.Year,
                InspectionDate = inputcar.InspectionDate,
                EngineSize = inputcar.EngineSize,
                EnginePower = inputcar.EnginePower
            });

            if (car == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new CarDto
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Registration = car.Registration,
                    Year = car.Year,
                    InspectionDate = car.InspectionDate,
                    EngineSize = car.EngineSize,
                    EnginePower = car.EnginePower
                });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody]CarDto inputcar)
        {
            if (inputcar == null || id == null)
            {
                return BadRequest();
            }

            Car car = await _carService.Get(id);

            if (car == null)
            {
                return NotFound();

            } else
            {
                car.Make = inputcar.Make;
                car.Model = inputcar.Model;
                car.Registration = inputcar.Registration;
                car.Year = inputcar.Year;
                car.InspectionDate = inputcar.InspectionDate;
                car.EngineSize = inputcar.EngineSize;
                car.EnginePower = inputcar.EnginePower;

                return Ok(await _carService.Update(car));
            }

            
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                await _carService.Delete(car);
                return Ok();
            }

        }

        [Route("Search")]
        [HttpGet]
        public async Task<IEnumerable<CarDto>> Search([FromQuery]CarFilter filter)
        {
            if(filter == null)
            {
                return (await _carService.GetAll()).Select(car => new CarDto
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Registration = car.Registration,
                    Year = car.Year,
                    InspectionDate = car.InspectionDate,
                    EngineSize = car.EngineSize,
                    EnginePower = car.EnginePower
                });
            }
            else
            {
                if(filter.YearMin == null)
                {
                    filter.YearMin = int.MinValue;
                }

                if(filter.YearMax == null)
                {
                    filter.YearMax = int.MaxValue;
                }

                return (await _carService.Search(filter)).Select(car => new CarDto
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Registration = car.Registration,
                    Year = car.Year,
                    InspectionDate = car.InspectionDate,
                    EngineSize = car.EngineSize,
                    EnginePower = car.EnginePower
                });
            }
        }


    }
}